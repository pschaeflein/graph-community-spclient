Write-Host "Building client..."

tsp compile src/main.tsp --emit @typespec/openapi3

# Fix nested allOf for Group/Owner
$openApiFile = "./dist/@typespec/openapi3/openapi.json"
$json = Get-Content -Raw -Path $openApiFile | ConvertFrom-Json
$mapping = $json.components.schemas.Principal.discriminator.mapping
Add-Member -InputObject $mapping -MemberType NoteProperty -Name "#SP.Group" -Value "#/components/schemas/Group"
$json | ConvertTo-Json -Depth 100 | Set-Content -Path $openApiFile

kiota generate -l csharp -d ./dist/@typespec/openapi3/openapi.json -c SPClient -n Graph.Community -o ../codegen/lib/apiclient --cc --co --ebc

# Rename-Item -Path ../codegen/lib/apiclient/Item/_api/MicrosoftSharepointUtilitiesWebTemplateExtensionsSiteScriptUtilityGetSiteDesignMetadata -NewName SiteScriptUtilityGetSiteDesignMetadata
# Rename-Item -Path ../codegen/lib/apiclient/Item/_api/SiteScriptUtilityGetSiteDesignMetadata/MicrosoftSharepointUtilitiesWebTemplateExtensionsSiteScriptUtilityGetSiteDesignMetadataRequestBuilder.cs -NewName SiteScriptUtilityGetSiteDesignMetadataRequestBuilder.cs

$ListsItemRequestBuilder = "..\codegen\lib\apiclient\Item\_api\Web\Lists\Item\ListsItemRequestBuilder.cs"
(Get-Content $ListsItemRequestBuilder) -replace "/_api/web/lists/{id}", "/_api/web/lists/getById('{id}')" | Set-Content $ListsItemRequestBuilder

$SitePagesRequestBuilder = "..\codegen\lib\apiclient\Item\_api\SitePages\SitePagesRequestBuilder.cs"
(Get-Content $SitePagesRequestBuilder) -replace "/_api/SitePages", "/_api/SitePages/Pages" | Set-Content $SitePagesRequestBuilder
$SitePagesItemRequestBuilder = "..\codegen\lib\apiclient\Item\_api\SitePages\Item\SitePagesItemRequestBuilder.cs"
(Get-Content $SitePagesItemRequestBuilder) -replace "/_api/SitePages/{id}", "/_api/SitePages/Pages({id})" | Set-Content $SitePagesItemRequestBuilder

dotnet test ..\graph-community-spclient.sln

Write-Host "Complete."
