using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AT6Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AT6*5n*o*Fds";

        var expected = new AT6_InternationalManifestInformation
        {
            InternationalDutiableStatusCode = "5n",
            ImportExportCode = "o",
            TransportationTermsCode = "Fds"
        };

        var actual = Map.MapObject<AT6_InternationalManifestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("5n", true)]
    public void Validatation_RequiredInternationalDutiableStatusCode(string internationalDutiableStatusCode, bool isValidExpected)
    {
        var subject = new AT6_InternationalManifestInformation();
        subject.ImportExportCode = "o";
        subject.InternationalDutiableStatusCode = internationalDutiableStatusCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("o", true)]
    public void Validatation_RequiredImportExportCode(string importExportCode, bool isValidExpected)
    {
        var subject = new AT6_InternationalManifestInformation();
        subject.InternationalDutiableStatusCode = "5n";
        subject.ImportExportCode = importExportCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}