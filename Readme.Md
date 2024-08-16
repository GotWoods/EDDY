EDDY 

Eddy is a strongly typed representation of EDI document formats consisting of the following components

- Eddy.Core: Contains the basic logic for parsing/attributes/validation
- Eddy.x12: Parsing and data elements (e.g. ISA, GS, B2, N1, etc.) across all versions of the x12 spec
- Eddy.x12.DomainModels.[domain]: This contains transaction sets for various formats (e.g. 204_MotorCarrierLoadTender)
- Eddy.Edifact: Parsing and data elements (e.g. UNH, BGM, DTM, NAD, etc.) across all versions of the Edifact spec
- Eddy.Edifact.DomainModels.[domain]: This contains transaction sets for various formats (e.g. APERAK)

Formats
- x12: All element/composite types supported. Transportation and Communications And Control document types are implemented
- EDIFACT: started
- TradaCOMS: Not Supported (mostly used in the UK)
- UBL: Not Supported (XML format)
- VDA: Not Supported (fixed length format)
- Odette: not supported
- EANCOM: not supported
- VICS: not supported
- VDA: not supported
- HIPAA: not supported
- RosettaNet: not supported
- SWIFT: not supported

Parsing an x12Document
```
var data = File.ReadAllText(fileName);
var document = x12Document.Parse(data);

var date = document.InterchangeControlHeader.InterchangeDate
var sender = document.GsHeader.ApplicationSendersCode;

var segments = document.Sections[0].Segments //Sections are all data contained between a ST/SE element pair
foreach (var segment in segments)
{
   if (segment.GetType() == typeof(N1_Name)) 
   {
		var name = ((N1_Name)segment).Name
   }
}
```

Pasing an x12 Document into a Transaction Set

```
var data = File.ReadAllText(fileName);
var document = x12Document.Parse(data);
var mapper = new DomainMapper(document.Sections[0].Segments);
var edi204 = mapper.Map<Eddy.x12.DomainModels.Transportation.v4010.Edi204_MotorCarrierLoadTender>();
```

Validation
when reading a line some basic validations can be turned on using the Options:

Required: The field is required
ARequiresB: If A is specified, B is required. B can exist on its own without A though. If A and B are empty then this passes
IfOne_ThenAllRequired: If A or B is specified, then both must be filled in. If A and B are empty then this passes
AtLeastOneOf: A or B (or both) must be specified
OnlyOneOf: 

Caching and Startup
The first time a map operation is called. All the maps will be determined and cached

x12Dates and Times

Dates and times follow different formats depending on the version of the spec and which line type you are parsing. Some line types support 
calling GetDateTime() which will return a DateTime object (ISA / GS / G62).

For other places you can specify if you expect a 4 or 6 digit (or use All for both) format for the date. For the time it can be a 4,6,7, or 8 digit format. 

```
x12DateTimeParser.Parse("210101", "0730", SupportedDateFormats.SixDigit, SupportedTimeFormats.FourDigit | SupportedTimeFormats.SixDigit)
```

Time zones can roughly be determined as well using the ConvertToTimeZon method which will create a DateTimeOffset object with the correct offset:

```
var result = x12DateTimeParser.ConvertToTimeZone(testDate, "ET");
```

This will take into account Daylight Savings Time if the date falls into the DST date range. This is not perfect as some regions switch time zones on certain dates (e.g. Britan changes from GMT to BST in the summer) and other locations can have some complex rules as well.

The use of the LT time code will cause an exception in the ConvertToTimeZone as we don't know if that is the local timezone of the sender, the recipient, or the timezone of the data the line is refering to (e.g. a location update from a company based in LA, reporting to a company based in New York, with the location update happening in Colorado)

