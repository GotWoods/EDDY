using Eddy.Edifact.Mapping;
using Xunit.Abstractions;

namespace Eddy.Edifact.Tests.Functional;



public class AperakTests
{
    [Fact]
    public void GetOne()
    {
        var file = "G:\\EdiSamples\\BMW\\APERAK\\2023\\02\\APERAK_0a358e44-9295-48fa-a7bd-9256074805cb.txt";
        var data = File.ReadAllText(file);
        var document = EdiFactDocument.Parse(data);
        foreach (var group in document.FunctionalGroups)
        {
            foreach (var message in group.Messages)
            {
                var mapper = new DomainMapper(message.Segments);
                var aperakDoc = mapper.Map<APERAK>();
                var results = aperakDoc.Validate();
                if (!results.IsValid)
                {
                    Assert.Fail(results.ToString());
                }

                Assert.Equal(0, aperakDoc.Group1.Count);
                Assert.Equal(2, aperakDoc.Group2.Count);
            }
            
            //documentSections.Add(edi204.ToDocumentSection(section.TransactionSetControlNumber));
        }
    }
}
public class IFTSTATests
{
    private readonly ITestOutputHelper _output;

    public IFTSTATests(ITestOutputHelper output)
    {
        _output = output;
    
    }


    private void ReadFile(string file)
    {
        var expectedLines = new string[] { };
        var actualLines = new string[] { };

        try
        {
            var data = File.ReadAllText(file);
            var document = EdiFactDocument.Parse(data);
            // var documentSections = new List<Section>();
            // foreach (var section in document.Sections)
            // {
            //     var mapper = new DomainMapper(section.Segments);
            //     var edi204 = mapper.Map<x12.DomainModels.Transportation.v4010.Edi204_MotorCarrierLoadTender>();
            //     var results = edi204.Validate();
            //     if (!results.IsValid)
            //     {
            //         Assert.Fail(results.ToString());
            //     }
            //     //documentSections.Add(edi204.ToDocumentSection(section.TransactionSetControlNumber));
            // }
            //
            // var newDocument = new x12Document();
            // newDocument.InterchangeControlHeader = document.InterchangeControlHeader;
            // newDocument.GsHeader = document.GsHeader;
            // foreach (var documentSection in documentSections) newDocument.Sections.Add(documentSection);
            //
            //
            // var outputOptions = new MapOptions();
            // outputOptions.Separator = seperator.ToString();
            // outputOptions.LineEnding = lineSeparator.ToString();
            //
            // var actual = newDocument.ToString(outputOptions);
            // //actual = actual.Replace("~", "~\r\n"); //pretty formatting
            //
            // expectedLines = data.Replace("\r\n", "\n").Split(lineSeparator);
            // actualLines = actual.Split(lineSeparator);
            //
            //
            // for (var i = 0; i < expectedLines.Length; i++)
            // {
            //     if (expectedLines[i].StartsWith("SE")) //everyone implements the counts differently
            //         continue;
            //     //remove all whitespace for the comparison as some of the test EDI files have trailing whitespace which the library would not replicate
            //     Assert.Equal(expectedLines[i].Trim().Replace(" ", ""), actualLines[i].Trim().Replace(" ", "")); //<object> shows more output if this is being truncated
            // }
        }
        catch (Exception)
        {
            _output.WriteLine(file);
            // for (var i = 0; i < Math.Min(expectedLines.Length, actualLines.Length); i++)
            // {
            //     if (i == 0) continue;
            //     if (expectedLines[i].Trim().Replace(" ", "") != actualLines[i].Trim().Replace(" ", ""))
            //     {
            //         _output.WriteLine($"[{(i + 1).ToString().PadLeft(2, '0')}] {expectedLines[i].Trim().PadRight(50)} {actualLines[i].Trim()}");
            //         break; //exit when the line does not match (but print the one that did not match
            //     }
            //
            //     _output.WriteLine($"[{(i + 1).ToString().PadLeft(2, '0')}] {expectedLines[i].Trim().PadRight(50)} {actualLines[i].Trim()}");
            // }

            throw;
        }
    }

    [Theory]
    [InlineData(@"G:\EdiSamples\BMW\IFTSTA075\2023\03", '*', '~')]
    public void ToDocument(string path, char separator, char lineSeparator)
    {
        ReadFile("G:\\EdiSamples\\BMW\\IFTSTA075\\2023\\03\\VDA4945_0b0f9d79-beac-4288-aa34-3a897043304f.txt");
        // foreach (var file in Directory.GetFiles(path))
        // {
        //     ReadFile(file);
        // }
    }


   

    // [Fact]
    // public void ToDocumentSection()
    // {
    //     var sourceModel = new Edi204_MotorCarrierLoadTender();
    //     sourceModel.ShipmentInformation = new B2_BeginningSegmentForShipmentInformationTransaction
    //     {
    //         StandardCarrierAlphaCode = "XXXX",
    //         ShipmentIdentificationNumber = "32523432",
    //         ShipmentMethodOfPaymentCode = "PP"
    //     };
    //     sourceModel.SetPurpose = new B2A_SetPurpose() { TransactionSetPurposeCode = "04" };
    //     sourceModel.Entities.Add(new Entity
    //     {
    //         
    //             PartyIdentification = new N1_PartyIdentification() { Name = "123 Company", EntityIdentifierCode = "5334532" },
    //             PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "123 street" } },
    //             GeographicLocation = new N4_GeographicLocation() { CityName = "City", StateOrProvinceCode = "PS", PostalCode = "H0H0H0" }
    //     });
    //     sourceModel.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "OTH", ReferenceIdentification = "1st type" });
    //     sourceModel.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "ZZZ", ReferenceIdentification = "2nd type" });
    //     sourceModel.Notes.Add(new NTE_NoteSpecialInstruction { NoteReferenceCode = "ABC", Description = "Note1" });
    //     sourceModel.Notes.Add(new NTE_NoteSpecialInstruction { NoteReferenceCode = "123", Description = "Note2" });
    //     sourceModel.Stops.Add(new StopOffDetails
    //     {
    //         Detail = new S5_StopOffDetails()
    //         {
    //             StopSequenceNumber = 1,
    //             StopReasonCode = "AB"
    //         }
    //     });
    //
    //
    //     var expected = new Section();
    //     expected.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { StandardCarrierAlphaCode = sourceModel.ShipmentInformation.StandardCarrierAlphaCode, ShipmentIdentificationNumber = sourceModel.ShipmentInformation.ShipmentIdentificationNumber, ShipmentMethodOfPaymentCode = sourceModel.ShipmentInformation.ShipmentMethodOfPaymentCode });
    //     expected.Segments.Add(new B2A_SetPurpose { TransactionSetPurposeCode = sourceModel.SetPurpose.TransactionSetPurposeCode });
    //     expected.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = sourceModel.ReferenceNumbers[0].ReferenceIdentification, ReferenceIdentificationQualifier = sourceModel.ReferenceNumbers[0].ReferenceIdentificationQualifier });
    //     expected.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = sourceModel.ReferenceNumbers[1].ReferenceIdentification, ReferenceIdentificationQualifier = sourceModel.ReferenceNumbers[1].ReferenceIdentificationQualifier });
    //     expected.Segments.Add(new NTE_NoteSpecialInstruction { Description = sourceModel.Notes[0].Description, NoteReferenceCode = sourceModel.Notes[0].NoteReferenceCode });
    //     expected.Segments.Add(new NTE_NoteSpecialInstruction { Description = sourceModel.Notes[1].Description, NoteReferenceCode = sourceModel.Notes[1].NoteReferenceCode });
    //     expected.Segments.Add(new N1_PartyIdentification
    //     {
    //         EntityIdentifierCode = sourceModel.Entities[0].PartyIdentification.EntityIdentifierCode,
    //         Name = sourceModel.Entities[0].PartyIdentification.Name
    //     });
    //
    //     expected.Segments.Add(new N3_PartyLocation
    //     {
    //         AddressInformation = sourceModel.Entities[0].PartyLocation[0].AddressInformation
    //     });
    //
    //     expected.Segments.Add(new N4_GeographicLocation
    //     {
    //         CityName = sourceModel.Entities[0].GeographicLocation.CityName,
    //         StateOrProvinceCode = sourceModel.Entities[0].GeographicLocation.StateOrProvinceCode,
    //         PostalCode = sourceModel.Entities[0].GeographicLocation.PostalCode
    //     });
    //
    //     expected.Segments.Add(new S5_StopOffDetails
    //     {
    //         StopSequenceNumber = sourceModel.Stops[0].Detail.StopSequenceNumber,
    //         StopReasonCode = sourceModel.Stops[0].Detail.StopReasonCode,
    //         
    //     });
    //
    //     var actual = sourceModel.ToDocumentSection("0001");
    //     for (var i = 0; i < Math.Max(actual.Segments.Count, expected.Segments.Count); i++) 
    //         Assert.Equivalent(expected.Segments[i], actual.Segments[i], true);
    // }

    // [Fact]
    // public void LoadDocument()
    // {
    //     var data = @"ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00401*000003438*0*P*>~
	   //                  GS*SM*4405197800*999999999*20111219*1747*2100*X*004010~
	   //                  ST*204*0001~
	   //                  B2**XXXX**9999955559**PP~
	   //                  B2A*04~
	   //                  L11*NONPRIMARY*OK~
	   //                  MS3*XXXX*B**M~
	   //                  NTE**FROZEN GOODS SET TO -10d F~
	   //                  N1*PF*XYZ CORP*9*9995555500000~
	   //                  N3*31875 SOLON RD~
	   //                  N4*SOLON*OH*44139~
	   //                  N7**NONE*********FF****5300~
	   //                  S5*1*CL*27800*L*2444*CA*1016*E~
	   //                  L11*9999001947*DO~
	   //                  L11*9999670098*CR~
	   //                  L11*9999001866*DO~
	   //                  L11*9999669887*CR~";
    //
    //     var document = x12Document.Parse(data);
    //
    //     // var edi204 = new Edi204_MotorCarrierLoadTender();
    //     // edi204.LoadFrom(document.Sections[0]);
    //     var mapper = new DomainMapper(document.Sections[0].Segments);
    //     var edi204 = mapper.Map<x12.DomainModels.Transportation.v4010.Edi204_MotorCarrierLoadTender>();
    //
    //     var expected = new Eddy.x12.DomainModels.Transportation.v4010.Edi204_MotorCarrierLoadTender();
    //     expected.ShipmentInformation.StandardCarrierAlphaCode = "XXXX";
    //     expected.ShipmentInformation.ShipmentIdentificationNumber = "9999955559";
    //     expected.ShipmentInformation.ShipmentMethodOfPayment = "PP";
    //     expected.SetPurpose = new Eddy.x12.Models.v4010.B2A_SetPurpose() { TransactionSetPurposeCode = "04" };
    //     expected.InterlineInformation = new MS3_InterlineInformation { StandardCarrierAlphaCode = "XXXX", TransportationMethodTypeCode = "M", RoutingSequenceCode = "B" };
    //     // expected.Receiver = "123456789012345";
    //     // expected.Sender = "ABCDEFGHIJKLMNO";
    //     //MS3 should be SCAC XXXX
    //     //Any Mode
    //     //Transit Method M
    //     //expected.Notes.Add("FROZEN GOODS SET TO -10d F")
    //
    //
    //     expected.StopOffDetails.Add(new Eddy.x12.DomainModels.Transportation.v4010._204.StopOffDetails());
    //     expected.StopOffDetails[0].Detail = new S5_StopOffDetails()
    //     {
    //         StopSequenceNumber = 1,
    //         StopReasonCode = "CL",
    //         Weight = 27800,
    //         WeightUnitCode = "L",
    //         NumberOfUnitsShipped = 2444,
    //         UnitOrBasisForMeasurementCode = "CA",
    //         Volume = 1016,
    //         VolumeUnitQualifier = "E"
    //     };
    //     expected.StopOffDetails[0].ReferenceNumbers.Add(new Eddy.x12.Models.v4010.L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "DO", ReferenceIdentification = "9999001947" });
    //     expected.StopOffDetails[0].ReferenceNumbers.Add(new Eddy.x12.Models.v4010.L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "CR", ReferenceIdentification = "9999670098" });
    //     expected.StopOffDetails[0].ReferenceNumbers.Add(new Eddy.x12.Models.v4010.L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "DO", ReferenceIdentification = "9999001866" });
    //     expected.StopOffDetails[0].ReferenceNumbers.Add(new Eddy.x12.Models.v4010.L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "CR", ReferenceIdentification = "9999669887" });
    //
    //     //checking the stop first gives easier to read failures then when a collection compare fails
    //     Assert.Equivalent(expected.StopOffDetails[0], edi204.StopOffDetails[0]);
    //     Assert.Equivalent(expected, edi204);
    // }
}