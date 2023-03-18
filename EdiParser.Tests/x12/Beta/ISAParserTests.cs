using System.Text;
using EdiParser.x12;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using Xunit.Abstractions;

namespace EdiParser.Tests.x12.Beta
{
    public class IsaParserTests
    {
        [Fact]
        public void Parse_X12_ISA_Line_Should_Populate_Properties()
        {
            var isa = Map.MapObject<ISA_InterchangeControlHeader>("ISA*00* *00* *02*ReferenceIdentification *01*006922827HUH1 *080903*1132*U*00401*000010067*0*P*>", MapOptionsForTesting.x12DefaultEndsWithNewline);
            Assert.Equal("00", isa.AuthorizationInformationQualifier); //1
            Assert.Null(isa.AuthorizationInformation); //2
            Assert.Equal("00", isa.SecurityInformationQualifier); //3
            Assert.Null(isa.SecurityInformation); //4
            Assert.Equal("02", isa.InterchangeSenderIdQualifier); //5
            Assert.Equal("ReferenceIdentification", isa.InterchangeSenderId); //6
            Assert.Equal("01", isa.InterchangeReceiverIdQualifier); //7
            Assert.Equal("006922827HUH1", isa.InterchangeReceiverId); //8
            Assert.Equal("080903", isa.InterchangeDate); //9
            Assert.Equal("1132", isa.InterchangeTime); //10
            //Assert.Equal(new DateTime(2008, 09, 03, 11, 32, 00), isa.CreationDate); //9
            Assert.Equal("U", isa.RepetitionSeparator); //11
            Assert.Equal(401, isa.InterchangeControlVersionNumberCode); //12
            Assert.Equal("000010067", isa.InterchangeControlNumber); //13
            Assert.Equal("0", isa.AcknowledgmentRequestedCode); //14
            Assert.Equal("P", isa.InterchangeUsageIndicatorCode); //15
            Assert.Equal(">", isa.ComponentElementSeparator); //16
        }
    }
}