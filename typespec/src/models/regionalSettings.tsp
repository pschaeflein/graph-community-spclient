namespace Graph.Community;

model RegionalSettings {
  AdjustHijriDays: int16;
  AlternateCalendarType: int16;

  /**
   * The string that is used to represent A.M. on the server.
   */
  AM: string;

  CalendarType: int16;
  Collation: int16;
  CollationLCID: int32;
  DateFormat: int32;
  DateSeparator: string;
  DecimalSeparator: string;
  DigitGrouping: string;

  /**
   * The first day of the week. 0 = Sunday
   */
  FirstDayOfWeek: int32;

  FirstWeekOfYear: int16;
  IsEastAsia: boolean;
  IsRightToLeft: boolean;
  IsUIRightToLeft: boolean;
  ListSeparator: string;
  LocaleId:int32;
  NegativeSign: string;
  NegNumberMode:int32;

  /**
   * The string that is used to represent P.M. on the server.
   */
  PM: string;

  PositiveSign: string;
  ShowWeeks: boolean;
  ThousandSeparator: string;
  Time24: boolean;
  TimeMarkerPosition: int32;
  TimeSeparator: string;
  TimeZone:TimeZone;
  WorkDayEndHour: int16;
  WorkDays: int16;
  WorkDayStartHour: int16;
}

model TimeZone {
  Description: string;
  Id: int32;
  Information: TimeZoneInformation;
}

model TimeZoneInformation {
  Bias: int32;
  DaylightBias: int32;
  StandardBias: int32;
}
