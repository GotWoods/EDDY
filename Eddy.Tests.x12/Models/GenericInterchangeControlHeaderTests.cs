using Eddy.Core;
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
            Assert.Equal("401", header.InterchangeControlVersionNumberCode);
            Assert.Equal(21, header.InterchangeControlNumber);
            Assert.Equal("7", header.AcknowledgmentRequestedCode);
            Assert.Equal("P", header.InterchangeUsageIndicatorCode);
            Assert.Equal(":", header.ComponentDataElementSeparator);
            Assert.Equal('~', header.ElementSeparator);
        }

        [Fact]
        
        public void Parse_Invalid_Length_Second_Position()
        {
            var data = "ISA*001*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA AuthorizationInformationQualifier must be 2 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Third_Position()
        {
            var data = "ISA*01*123456789*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA AuthorizationInformation must be 10 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Fourth_Position()
        {
            var data = "ISA*01*1234567890*023*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA SecurityInformationQualifier must be 2 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Fifth_Position()
        {
            var data = "ISA*01*1234567890*02*123456789*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA AuthorizationInformation must be 10 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Sixth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMN*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA AuthorizationInformation must be 15 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Seventh_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMN*211019*1011*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA InterchangeReceiverID must be 15 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Eighth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*21101*1011*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA InterchangeDate must be 6 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Ninth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*101*U*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA InterchangeTime must be 10 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Tenth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*UU*00401*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA Interchange Control Standards Identifier must be 10 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Eleventh_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*0040*000000021*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA InterchangeControlVersionNumberCode must be 5 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Twelfth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*00000002*7*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA InterchangeControlNumber must be 9 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Thirteenth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*77*P*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA AcknowledgmentRequestedCode must be 1 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Fourteenth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*PP*:~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA InterchangeUsageIndicatorCode must be 1 characters long", exception.Message);
        }

        [Fact]
        public void Parse_Invalid_Length_Fifteenth_Position()
        {
            var data = "ISA*01*1234567890*02*1234567890*03*ABCDEFGHIJKLMNO*04*ABCDEFGHIJKLMNO*211019*1011*U*00401*000000021*7*P*::~";
            var exception = Assert.Throws<InvalidFileFormatException>(() => GenericInterchangeControlHeader.FromString(data));
            Assert.Equal("ISA ComponentDataElementSeparator must be 1 characters long", exception.Message);
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
