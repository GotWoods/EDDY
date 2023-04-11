using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C032Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "x*dE5*ztP*AmD*G*evD*L*y";

        var expected = new C032_EncryptionServiceInformation()
        {
            EncryptionServiceCode = "x",
            AlgorithmIDCode = "dE5",
            AlgorithmModeOfOperationCode = "ztP",
            FilterIDCode = "AmD",
            VersionIdentifier = "G",
            CompressionIDCode = "evD",
            VersionIdentifier2 = "L",
            LengthOfInitializationVector = "y",
        };

        var actual = Map.MapObject<C032_EncryptionServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("x", true)]
    public void Validatation_RequiredEncryptionServiceCode(string encryptionServiceCode, bool isValidExpected)
    {
        var subject = new C032_EncryptionServiceInformation();
        subject.EncryptionServiceCode = encryptionServiceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("AmD", "G", true)]
    [InlineData("", "G", false)]
    [InlineData("AmD", "", false)]
    public void Validation_AllAreRequiredFilterIDCode(string filterIDCode, string versionIdentifier, bool isValidExpected)
    {
        var subject = new C032_EncryptionServiceInformation();
        subject.EncryptionServiceCode = "x";
        subject.FilterIDCode = filterIDCode;
        subject.VersionIdentifier = versionIdentifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("evD", "L", true)]
    [InlineData("", "L", false)]
    [InlineData("evD", "", false)]
    public void Validation_AllAreRequiredCompressionIDCode(string compressionIDCode, string versionIdentifier2, bool isValidExpected)
    {
        var subject = new C032_EncryptionServiceInformation();
        subject.EncryptionServiceCode = "x";
        subject.CompressionIDCode = compressionIDCode;
        subject.VersionIdentifier2 = versionIdentifier2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}