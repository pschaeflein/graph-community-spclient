using Graph.Community.Utilities;

namespace Graph.Community.Tests
{
  public class DriveHelperTests
  {
    private readonly string DriveItemId = "01G2WBSBYMASJBGQ2VCZA3G43NJBVUORMY";
    private readonly string DriveId = "b!QDYe3nPe50Svtmbl9xuCpbif_1hvtTFCmFVmhsKN4jcFEwRjHtARSpIPCOJ1AqIf";
    private readonly Guid ListId = new("63041305-d01e-4a11-920f-08e27502a21f");
    private readonly int ListItemId = 1;
    private readonly Guid ListItemUniqueId = new("1392040c-5543-4116-b373-6d486b474598");
    private readonly Guid SiteId = new("de1e3640-de73-44e7-afb6-66e5f71b82a5");
    private readonly Guid WebId = new("58ff9fb8-b56f-4231-9855-6686c28de237");

    [Fact]
    public void EncodeDriveItemId_Demonstration()
    {
      // ARRANGE

      // ACT
      var driveItemId = DriveHelper.EncodeDriveItemId(SiteId, WebId, ListItemUniqueId);

      // ASSERT
      Assert.Equal(DriveItemId, driveItemId);

    }

    [Fact]
    public void DecodeDriveItemId__Demonstration()
    {
      // ARRANGE

      // ACT
      var guid = DriveHelper.DecodeDriveItemId(DriveItemId);

      // ASSERT
      Assert.Equal(ListItemUniqueId, guid);
    }

    [Fact]
    public void EncodeDriveId_Demonstration()
    {
      // ARRANGE

      // ACT
      var driveId = DriveHelper.EncodeDriveId(SiteId, WebId, ListId);

      // ASSERT
      Assert.Equal(DriveId, driveId);
    }

    [Fact]
    public void DecodeDriveId_Demonstration()
    {
      // ARRANGE

      // ACT
      var (siteId, webId, docLibId) = DriveHelper.DecodeDriveId(DriveId);

      // ASSERT
      Assert.Equal(SiteId, siteId);
      Assert.Equal(WebId, webId);
      Assert.Equal(ListId, docLibId);
    }
  }
}
