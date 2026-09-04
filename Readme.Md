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

The Interchanges structure
A file can contain more than one ISA...IEA interchange, and an interchange can contain more than one GS...GE
functional group. document.Interchanges holds all of them, in file order:

```
foreach (var interchange in document.Interchanges)
{
    foreach (var group in interchange.FunctionalGroups)
    {
        foreach (var section in group.Sections)
        {
            // section.Segments, same as before
        }
    }
}
```

document.InterchangeControlHeader, document.GsHeader and document.Sections still work exactly as before -
after Parse() they point at the first interchange's header, the first group's header, and every Section in
the document (flattened, in file order), so existing code that only ever expected one interchange and one
group does not need to change.

Lenient parsing
By default, Parse throws InvalidFileFormatException as soon as it hits something it cannot make sense of
(a malformed ISA, a missing GS, a segment code it doesn't recognize, and so on) - the same as it always has.
Pass an x12ParseOptions with Lenient set to true to keep going instead: problems are recorded on
document.ValidationErrors and parsing continues as far as it can.

```
var document = x12Document.Parse(data, new x12ParseOptions { Lenient = true });
if (!document.IsValid)
{
    foreach (var error in document.ValidationErrors)
        Console.WriteLine($"line {error.LineNumber} [{error.SegmentCode}]: {error}");
}
```

In lenient mode: a segment code that isn't registered for the document's version becomes an Unknown_Segment
(SegmentId, Elements) instead of failing the parse; a missing GS record leaves a functional group with a
null Header; a segment appearing outside of an ST/SE pair is filed under the nearest open group or
interchange's OrphanSegments; and a missing SE, GE or IEA at the end of the input is recorded rather than
silently losing data. GE/GS and IEA/ISA counts and control numbers are always validated (in both modes) the
same way they always were - they are recorded as validation errors, never thrown.

Source spans
Every parsed segment - including the ISA header, and the ST/SE/GS/GE/IEA records - implements
Eddy.Core.ISourceTracked, so it carries a Source property (SegmentSource) pointing back at the exact spot
in the original text it came from: LineNumber (matching ValidationResult.LineNumber), StartOffset and
Length (character positions into the string you passed to Parse, not counting the terminator or
surrounding whitespace), and RawText. ValidationResult also carries SegmentCode and Source for the segment
it concerns, so a viewer can jump straight from an error to the offending text:

```
var raw = data.Substring(segment.Source.StartOffset, segment.Source.Length); // == segment.Source.RawText
```

Transaction set registry
TransactionSetRegistry resolves the generated model type for a transaction set code and version, so you
don't have to know which Eddy.x12.DomainModels.* assembly or namespace it lives in:

```
var type = TransactionSetRegistry.Resolve("997", "004010"); // Edi997_FunctionalAcknowledgment
```

Version can be given as "004010", "4010" or the raw ISA-style "00401" - all normalise to the four-digit
form the v#### namespaces use. If the exact version isn't registered, it falls back to the highest
registered version below the one you asked for. Domain model assemblies already loaded into the process
are picked up automatically the first time you call Resolve or All; call TransactionSetRegistry.Register
for an assembly that hasn't been loaded yet (or that doesn't follow the standard Eddy.x12.DomainModels.*
naming).

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

Getting a document structure
If you want to get a programatic representation of the document structure you can use the following code:
```
var structure= Structure.Of<Edi214_TransportationCarrierShipmentStatusMessage>();
```

This will return a list of objects that represent the document. Each item can be a:
Segment - This is a single line in the EDI document, e.g. AT7_AppointmentInformation
RepeatingSegment - This is a segment that can repeat multiple times, e.g. L11_BusinessInstructionsAndReferenceNumber_
RepeatingComplexType - This is a grouping of lines that can repeat (e.g. N1 + N2 + N3 is a group with the next N1 starting the next group)

If it is a segment then the Segments array will be filled in
If it is a repeating segment / complex type then the Sections array will be filled in