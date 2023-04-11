using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EFITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "EFI*ZZ*NAME";

        var expected = new EFI_ElectronicFormatIdentification
        {
            SecurityLevelCode = "ZZ",
            FreeFormMessageText = "NAME"
        };

        var actual = Map.MapObject<EFI_ElectronicFormatIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("ZZ", true)]
    public void Validation_SecurityLevelCodeRequired(string securityLevelCode, bool isValidExpected)
    {
        var subject = new EFI_ElectronicFormatIdentification();
        subject.SecurityLevelCode = securityLevelCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("P1", "V1", "I1", "V1", "C1", "V1", true)]
    [InlineData("P1", null, "I1", "V1", "C1", "V1", false)]
    [InlineData("P1", "V1", "I1", null, "C1", "V1", false)]
    [InlineData("P1", "V1", "I1", "V1", "C1", null, false)]
    [InlineData(null, "V1", null, "V1", null, "V1", true)] //versions can be filled in without related data
    //[InlineData("P1", "V1", "I1", "V1", "C1", "V1", "FI1", null, false)] FilterIdCode works a bit different (if one is specified, both are required)
    public void Validation_IdentifiersRequireVersions(string programIdentifier, string programIdentifierVersion, string interchangeFormat
        , string interchangeFormatVersionIdentifier, string compressionTechnique, string compressionTechniqueVersionIdentifier, bool isValidExpected)
    {
        var subject = new EFI_ElectronicFormatIdentification();
        subject.SecurityLevelCode = "ZZ";
        subject.ProgramIdentifier = programIdentifier;
        subject.ProgramVersionIdentifier = programIdentifierVersion;

        subject.InterchangeFormat = interchangeFormat;
        subject.InterchangeVersionIdentifier = interchangeFormatVersionIdentifier;

        subject.CompressionTechnique = compressionTechnique;
        subject.CompressionTechniqueVersionIdentifier = compressionTechniqueVersionIdentifier;


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("FI1", "V1", true)]
    [InlineData(null, "V1", false)]
    [InlineData("FI1", null, false)]
    [InlineData(null, null, true)]
    public void Validation_FilterIdCode(string filterIdCode, string filterIdCodeVersionIdentifier, bool isValidExpected)
    {
        var subject = new EFI_ElectronicFormatIdentification();
        subject.SecurityLevelCode = "ZZ";

        subject.FilterIdCode = filterIdCode;
        subject.FilterIdCodeVersionIdentifier = filterIdCodeVersionIdentifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}