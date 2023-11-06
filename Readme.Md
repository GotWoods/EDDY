EDDY 

Eddy is a strongly typed representation of EDI document formats consisting of the following components

-Eddy.Core: Contains the basic logic for parsing/attributes/validation
-Eddy.x12: This is used to part the data elements (e.g. ISA, GS, B2, N1, etc.) across all versions of the spec
-Eddy.x12.DomainModels.[domain]: This contains transaction sets for various formats (e.g. 204_MotorCarrierLoadTender)


Formats
x12 - All element/composite types supported. Transaction types are limited 
EDIFACT - started
TradaCOMS - Not Supported (mostly used in the UK)
UBL - Not Supported (XML format)
VDA - Not Supported (fixed length format)
Odette - not supported
EANCOM - not supported
VICS - not supported
VDA - not supported
HIPAA - not supported
RosettaNet - not supported
SWIFT - not supported


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


