using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C053Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "f*t*D*J*7";

        var expected = new C053_StandardsInformation()
        {
            ElectronicFormStandardsTypeCode = "f",
            ElectronicFormStandardsIdentifier = "t",
            ImplementationConventionReference = "D",
            VersionIdentifier = "J",
            RevisionValue = "7",
        };

        var actual = Map.MapObject<C053_StandardsInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("f", true)]
    public void Validatation_RequiredElectronicFormStandardsTypeCode(string electronicFormStandardsTypeCode, bool isValidExpected)
    {
        var subject = new C053_StandardsInformation();
        subject.ElectronicFormStandardsIdentifier = "t";
        subject.ImplementationConventionReference = "D";
        subject.ElectronicFormStandardsTypeCode = electronicFormStandardsTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("t", true)]
    public void Validatation_RequiredElectronicFormStandardsIdentifier(string electronicFormStandardsIdentifier, bool isValidExpected)
    {
        var subject = new C053_StandardsInformation();
        subject.ElectronicFormStandardsTypeCode = "f";
        subject.ImplementationConventionReference = "D";
        subject.ElectronicFormStandardsIdentifier = electronicFormStandardsIdentifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("D", true)]
    public void Validatation_RequiredImplementationConventionReference(string implementationConventionReference, bool isValidExpected)
    {
        var subject = new C053_StandardsInformation();
        subject.ElectronicFormStandardsTypeCode = "f";
        subject.ElectronicFormStandardsIdentifier = "t";
        subject.ImplementationConventionReference = implementationConventionReference;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}