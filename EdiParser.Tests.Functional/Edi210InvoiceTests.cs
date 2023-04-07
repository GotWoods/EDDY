using EdiParser.x12;
using EdiParser.x12.DomainModels._4010;
using EdiParser.x12.DomainModels._8020;
using EdiParser.x12.Internals;
using EdiParser.x12.Mapping;
using Xunit.Abstractions;
using Edi210_MotorCarrierFreightDetailsAndInvoice = EdiParser.x12.DomainModels._4010.Edi210_MotorCarrierFreightDetailsAndInvoice;

namespace EdiParser.Tests.x12.DomainTests;

public class Edi210InvoiceTests
{
    private readonly ITestOutputHelper _output;

    public Edi210InvoiceTests(ITestOutputHelper output)
    {
        _output = output;
        //Logging.LoggerFactory = new XUnitLoggingFactory(output);
    }

    [Theory]
    [InlineData(@"G:\EdiSamples\Holland\210\IN\2023\02", '*', '~')]
    [InlineData(@"G:\EdiSamples\CHRobinson\210\OUT\2023\02", '*', '~')]
    [InlineData(@"G:\EdiSamples\AmericanAxel\210\OUT\2023\02", '*', '~')]
    public void ToDocument(string path, char seperator, char lineSeperator)
    {
        foreach (var file in Directory.GetFiles(path))
        {
            var expectedLines = new string[] { };
            var actualLines = new string[] { };

            try
            {
                var data = File.ReadAllText(file);
                var document = x12Document.Parse(data);

                var documentSections = new List<Section>();
                foreach (var section in document.Sections)
                {
                    // var edi204 = new Edi204_MotorCarrierLoadTender();
                    // edi204.LoadFrom(section);
                    var mapper = new DomainMapper(section.Segments);
                    var edi = mapper.Map<Edi210_MotorCarrierFreightDetailsAndInvoice>();

                    documentSections.Add(edi.ToDocumentSection(section.TransactionSetControlNumber));
                }


                var newDocument = new x12Document();
                newDocument.IsaInterchangeControlHeader = document.IsaInterchangeControlHeader;
                newDocument.GsHeader = document.GsHeader;
                foreach (var documentSection in documentSections) newDocument.Sections.Add(documentSection);


                var outputOptions = new MapOptions();
                outputOptions.Separator = seperator.ToString();
                outputOptions.LineEnding = lineSeperator.ToString();

                var actual = newDocument.ToString(outputOptions);
                //actual = actual.Replace("~", "~\r\n"); //pretty formatting

                expectedLines = data.Replace("\r\n", "\n").Split(lineSeperator);
                actualLines = actual.Split(lineSeperator);


                for (var i = 0; i < expectedLines.Length; i++)
                {
                    if (expectedLines[i].StartsWith("SE")) //everyone implements the counts differently
                        continue;
                    //remove all whitespace for the comparison as some of the test EDI files have trailing whitespace which the library would not replicate
                    Assert.Equal(expectedLines[i].Trim().Replace(" ", ""), actualLines[i].Trim().Replace(" ", "")); //<object> shows more output if this is being truncated
                }
            }
            catch (Exception)
            {
                _output.WriteLine(file);
                for (var i = 0; i < Math.Min(expectedLines.Length, actualLines.Length); i++)
                {
                    if (i == 0) continue;
                    if (expectedLines[i].Trim().Replace(" ", "") != actualLines[i].Trim().Replace(" ", ""))
                    {
                        _output.WriteLine($"[{(i + 1).ToString().PadLeft(2, '0')}] {expectedLines[i].Trim().PadRight(50)} {actualLines[i].Trim()}");
                        break; //exit when the line does not match (but print the one that did not match
                    }

                    _output.WriteLine($"[{(i + 1).ToString().PadLeft(2, '0')}] {expectedLines[i].Trim().PadRight(50)} {actualLines[i].Trim()}");
                }

                throw;
            }
        }
    }
}