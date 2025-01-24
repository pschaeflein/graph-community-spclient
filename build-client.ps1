Write-Host "Building client..."

$openapiFolder = "../graph-community-metadata/docs"
$apiclientFolder = "./codegen/lib/apiclient"

# Generate client
kiota generate -l csharp -d "$openapiFolder/openapi.json" -c SPClient -n Graph.Community -o $apiclientFolder --cc --co --ebc

# Rename-Item -Path ../codegen/lib/apiclient/Item/_api/MicrosoftSharepointUtilitiesWebTemplateExtensionsSiteScriptUtilityGetSiteDesignMetadata -NewName SiteScriptUtilityGetSiteDesignMetadata
# Rename-Item -Path ../codegen/lib/apiclient/Item/_api/SiteScriptUtilityGetSiteDesignMetadata/MicrosoftSharepointUtilitiesWebTemplateExtensionsSiteScriptUtilityGetSiteDesignMetadataRequestBuilder.cs -NewName SiteScriptUtilityGetSiteDesignMetadataRequestBuilder.cs


# Remove the 'With___' bits from /web/GetFileBy...
$WebRequestBuilder = "$apiclientFolder/Item/_api/Web/WebRequestBuilder.cs"
(Get-Content $WebRequestBuilder) -replace "GetFileByIdWithId\(Guid\? id\)", "GetFileById(Guid? id)" | Set-Content $WebRequestBuilder
(Get-Content $WebRequestBuilder) -replace "public global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder GetFileByServerRelativePathWithPath", "public global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder GetFileByServerRelativePath" | Set-Content $WebRequestBuilder

# Update URL templates
$ListsItemRequestBuilder = "$apiclientFolder/Item/_api/Web/Lists/Item/ListsItemRequestBuilder.cs"
(Get-Content $ListsItemRequestBuilder) -replace "/_api/web/lists/{id}", "/_api/web/lists/getById('{id}')" | Set-Content $ListsItemRequestBuilder

$SitePagesRequestBuilder = "$apiclientFolder/Item/_api/SitePages/SitePagesRequestBuilder.cs"
(Get-Content $SitePagesRequestBuilder) -replace "/_api/SitePages", "/_api/SitePages/Pages" | Set-Content $SitePagesRequestBuilder
$SitePagesItemRequestBuilder = "..\codegen\lib\apiclient\Item\_api\SitePages\Item\SitePagesItemRequestBuilder.cs"
(Get-Content $SitePagesItemRequestBuilder) -replace "/_api/SitePages/{id}", "/_api/SitePages/Pages({id})" | Set-Content $SitePagesItemRequestBuilder

dotnet test ..\graph-community-spclient.sln

Write-Host "Complete."
