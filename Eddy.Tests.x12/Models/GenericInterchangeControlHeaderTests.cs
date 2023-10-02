using Eddy.x12.Models;

namespace Eddy.x12.Tests.Models
{

    public class GenericInterchangeControlHeaderTests
    {
        [Fact]
        public void Parse()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*:~";
            var header = GenericInterchangeControlHeader.FromString(data);

            Assert.Equal('*', header.DataElementSeparator);
            Assert.Equal("01", header.AuthorizationInformationQualifier);
            Assert.Equal("1234567890", header.AuthorizationInformation);
            Assert.Equal("02", header.SecurityInformationQualifier);
            Assert.Equal("1234567890", header.SecurityInformation);
            Assert.Equal("03", header.InterchangeSenderIDQualifier);
            Assert.Equal("ABCDEFGHIJKLMNO", header.InterchangeSenderID);
            Assert.Equal("04", header.InterchangeReceiverIDQualifier);
            Assert.Equal("ABCDEFGHIJKLMNO", header.InterchangeReceiverID);
            Assert.Equal("211019", header.InterchangeDate);
            Assert.Equal("1011", header.InterchangeTime);
            Assert.Equal("U", header.RepetitionSeparator);
            Assert.Equal("00401", header.InterchangeControlVersionNumberCode);
            Assert.Equal(21, header.InterchangeControlNumber);
            Assert.Equal("7", header.AcknowledgmentRequestedCode);
            Assert.Equal("P", header.InterchangeUsageIndicatorCode);
            Assert.Equal(":", header.ComponentDataElementSeparator);
            Assert.Equal('~', header.ElementSeparator);
        }

        [Fact]
        public void ToStringCheck()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*:~";
            var header = GenericInterchangeControlHeader.FromString(data);
            Assert.Equal(data, header.ToString());

        }
    }
}
