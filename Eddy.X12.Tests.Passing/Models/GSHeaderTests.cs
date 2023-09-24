using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models
{
    public class GSHeaderTests
    {
        [Fact]
        public void Parse_X12_GS_Line_Should_Populate_Properties()
        {
            // Arrange
            var expected = new GS_FunctionalGroupHeader
            {
                FunctionalIdentifierCode = "HC",
                ApplicationSendersCode = "SENDER",
                ApplicationReceiversCode = "RECEIVER",
                Date = "20210101",
                Time = "1201",
                GroupControlNumber = "123456",
                ResponsibleAgencyCode = "X",
                VersionReleaseIndustryIdentifierCode = "005010X222A1"
            };

            // Act
            var actual = Map.MapObject<GS_FunctionalGroupHeader>("GS*HC*SENDER*RECEIVER*20210101*1201*123456*X*005010X222A1", MapOptionsForTesting.x12DefaultEndsWithNewline);

            // Assert
            Assert.Equal(expected.FunctionalIdentifierCode, actual.FunctionalIdentifierCode);
            Assert.Equal(expected.ApplicationSendersCode, actual.ApplicationSendersCode);
            Assert.Equal(expected.ApplicationReceiversCode, actual.ApplicationReceiversCode);
            Assert.Equal(expected.Date, actual.Date);
            Assert.Equal(expected.Time, actual.Time);
            Assert.Equal(expected.GroupControlNumber, actual.GroupControlNumber);
            Assert.Equal(expected.ResponsibleAgencyCode, actual.ResponsibleAgencyCode);
            Assert.Equal(expected.VersionReleaseIndustryIdentifierCode, actual.VersionReleaseIndustryIdentifierCode);
        }

        [Fact]
        public void Validate()
        {
            // Arrange
            var subject = new GS_FunctionalGroupHeader();

            var validationResult = subject.Validate();
            Assert.False(validationResult.IsValid);
            Assert.Equal(8, validationResult.Errors.Count); //all fields are required



        }
    }

}
