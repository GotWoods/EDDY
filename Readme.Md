Formats
x12 - Partially Supported
EDIFACT - Partially Supported
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


EdiParser works on multiple levels

Standard Level Domain Model Based 
These are done per standard (e.g x12 has 214 for a location update and EDIFact has DESADV for a location update)
These will allow you to get an object that represents an EDI transaction. Internally this loads an x12Document and
interpets/interogates the data to create a representation of an EDI Transaciton type. E.g. Edi214.Parse() will take raw text and 
try it's best to create a 214 for you to use. 


Document Based
x12Document.Parse() allows you to load in an x12document and access the ISA/GS headers and the sections with the document. 
Each ST/SE pair becomes a section with a list of "lines" that have been parsed within it. Internally this uses the line based readers to 
parse data and assemble the document
*Mention Grouped Reader here?

Line Based
You can use our line parsers yourself to process the data yourself. If you know the document has an MS1 line you could call MS1.Parse()
to convert that line to an object.


Mapping
How do we handle where a business does any of the follwing:
1. Supplies a unique top level type (e.g. instead of using N1 for Party Identification, they use their own code of G55 with their own rules)
2. Uses their own qualifiers or mis-appropriates a qualifier for their own purpose (e.g. Rail shipment in the spec actually means Air shipment for this sender)
3. Uses a field to convey additional data


Validation
when reading a line some basic validations can be turned on using the Options:

Required: The field is required
ARequiresB: If A is specified, B is required. B can exist on its own without A though. If A and B are empty then this passes
IfOne_ThenAllRequired: If A or B is specified, then both must be filled in. If A and B are empty then this passes
AtLeastOneOf: A or B (or both) must be specified
OnlyOneOf: 
