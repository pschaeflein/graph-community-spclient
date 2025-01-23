Write-Host "Building client..."

tsp compile src/main.tsp --emit @typespec/openapi3

# Fix nested allOf for Group/Owner
$openApiFile = "./dist/@typespec/openapi3/openapi.json"
$json = Get-Content -Raw -Path $openApiFile | ConvertFrom-Json
$mapping = $json.components.schemas.Principal.discriminator.mapping
if (Get-Member -InputObject $mapping -Name "#SP.Group" -MemberType Properties) {}
else { Add-Member -InputObject $mapping -MemberType NoteProperty -Name "#SP.Group" -Value "#/components/schemas/Group" }
if (Get-Member -InputObject $mapping -Name "#SP.User" -MemberType Properties) {}
else { Add-Member -InputObject $mapping -MemberType NoteProperty -Name "#SP.User" -Value "#/components/schemas/User" }
$json | ConvertTo-Json -Depth 100 | Set-Content -Path $openApiFile

# Generate client
kiota generate -l csharp -d ./dist/@typespec/openapi3/openapi.json -c SPClient -n Graph.Community -o ../codegen/lib/apiclient --cc --co --ebc

# Rename-Item -Path ../codegen/lib/apiclient/Item/_api/MicrosoftSharepointUtilitiesWebTemplateExtensionsSiteScriptUtilityGetSiteDesignMetadata -NewName SiteScriptUtilityGetSiteDesignMetadata
# Rename-Item -Path ../codegen/lib/apiclient/Item/_api/SiteScriptUtilityGetSiteDesignMetadata/MicrosoftSharepointUtilitiesWebTemplateExtensionsSiteScriptUtilityGetSiteDesignMetadataRequestBuilder.cs -NewName SiteScriptUtilityGetSiteDesignMetadataRequestBuilder.cs


# Remove the 'With___' bits from /web/GetFileBy...
$WebRequestBuilder = "../codegen/lib/apiclient/Item/_api/Web/WebRequestBuilder.cs"
(Get-Content $WebRequestBuilder) -replace "GetFileByIdWithId\(Guid\? id\)", "GetFileById(Guid? id)" | Set-Content $WebRequestBuilder
(Get-Content $WebRequestBuilder) -replace "public global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder GetFileByServerRelativePathWithPath", "public global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder GetFileByServerRelativePath" | Set-Content $WebRequestBuilder

# $GetFileByServerRelativePathWithPathRequestBuilder = "../codegen/lib/apiclient/Item/_api/Web/GetFileByServerRelativePathWithPath/GetFileByServerRelativePathWithPathRequestBuilder.cs"
# (Get-Content $GetFileByServerRelativePathWithPathRequestBuilder) -replace "/_api/web/GetFileByServerRelativePath\(DecodedUrl='{path}'\){\?%24expand", "/_api/web/GetFileByServerRelativePath(DecodedUrl=@path)?@path={%40path}{&%24expand" | Set-Content $GetFileByServerRelativePathWithPathRequestBuilder

# Update URL templates
$ListsItemRequestBuilder = "..\codegen\lib\apiclient\Item\_api\Web\Lists\Item\ListsItemRequestBuilder.cs"
(Get-Content $ListsItemRequestBuilder) -replace "/_api/web/lists/{id}", "/_api/web/lists/getById('{id}')" | Set-Content $ListsItemRequestBuilder

$SitePagesRequestBuilder = "..\codegen\lib\apiclient\Item\_api\SitePages\SitePagesRequestBuilder.cs"
(Get-Content $SitePagesRequestBuilder) -replace "/_api/SitePages", "/_api/SitePages/Pages" | Set-Content $SitePagesRequestBuilder
$SitePagesItemRequestBuilder = "..\codegen\lib\apiclient\Item\_api\SitePages\Item\SitePagesItemRequestBuilder.cs"
(Get-Content $SitePagesItemRequestBuilder) -replace "/_api/SitePages/{id}", "/_api/SitePages/Pages({id})" | Set-Content $SitePagesItemRequestBuilder

dotnet test ..\graph-community-spclient.sln

Write-Host "Complete."
