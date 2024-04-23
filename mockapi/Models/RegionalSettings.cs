using System.Text.Json.Serialization;

namespace Graph.Community.MockApi.Models
{
  public class RegionalSettings
  {
    [JsonPropertyName("AdjustHijriDays")]
    public short AdjustHijriDays { get; set; }

    [JsonPropertyName("AlternateCalendarType")]
    public short AlternateCalendarType { get; set; }

    [JsonPropertyName("AM")]
    public string? AM { get; set; }

    [JsonPropertyName("CalendarType ")]
    public short CalendarType { get; set; }

    [JsonPropertyName("Collation")]
    public short Collation { get; set; }

    [JsonPropertyName("CollationLCID")]
    public uint CollationLCID { get; set; }

    [JsonPropertyName("DateFormat")]
    public uint DateFormat { get; set; }

    [JsonPropertyName("DateSeparator")]
    public string? DateSeparator { get; set; }

    [JsonPropertyName("DecimalSeparator")]
    public string? DecimalSeparator { get; set; }

    [JsonPropertyName("DigitGrouping")]
    public string? DigitGrouping { get; set; }

    [JsonPropertyName("FirstDayOfWeek")]
    public uint FirstDayOfWeek { get; set; }

    [JsonPropertyName("FirstWeekOfYear")]
    public short FirstWeekOfYear { get; set; }

    [JsonPropertyName("IsEastAsia")]
    public bool IsEastAsia { get; set; }

    [JsonPropertyName("IsRightToLeft")]
    public bool IsRightToLeft { get; set; }

    [JsonPropertyName("IsUIRightToLeft")]
    public bool IsUIRightToLeft { get; set; }

    [JsonPropertyName("ListSeparator")]
    public string? ListSeparator { get; set; }

    [JsonPropertyName("LocaleId")]
    public uint LocaleId { get; set; }

    [JsonPropertyName("NegativeSign")]
    public string? NegativeSign { get; set; }

    [JsonPropertyName("NegNumberMode")]
    public uint NegNumberMode { get; set; }

    [JsonPropertyName("PM")]
    public string? PM { get; set; }

    [JsonPropertyName("PositiveSign")]
    public string? PositiveSign { get; set; }

    [JsonPropertyName("ShowWeeks")]
    public bool ShowWeeks { get; set; }

    [JsonPropertyName("ThousandSeparator")]
    public string? ThousandSeparator { get; set; }

    [JsonPropertyName("Time24")]
    public bool Time24 { get; set; }

    [JsonPropertyName("TimeMarkerPosition")]
    public uint TimeMarkerPosition { get; set; }

    [JsonPropertyName("TimeSeparator")]
    public string? TimeSeparator { get; set; }

    [JsonPropertyName("TimeZone")]
    public TimeZone? TimeZone { get; set; }

    [JsonPropertyName("WorkDayEndHour")]
    public short WorkDayEndHour { get; set; }

    [JsonPropertyName("WorkDays")]
    public short WorkDays { get; set; }

    [JsonPropertyName("WorkDayStartHour")]
    public short WorkDayStartHour { get; set; }
  }

  public class TimeZone
  {
    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("TimeZoneInformation")]
    public TimeZoneInformation? Information { get; set; }
  }

  public class TimeZoneInformation
  {
    [JsonPropertyName("Bias")]
    public int Bias { get; set; }

    [JsonPropertyName("DaylightBias")]
    public int DaylightBias { get; set; }

    [JsonPropertyName("StandardBias")]
    public int StandardBias { get; set; }
  }
}
