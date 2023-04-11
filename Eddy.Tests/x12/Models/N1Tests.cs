using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using static System.String;

namespace Eddy.Tests.x12.Models;

public class N1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N1*Uz*A*y*yJ*o0*Xx*";

        var expected = new N1_PartyIdentification()
        {
            EntityIdentifierCode = "Uz",
            Name = "A",
            IdentificationCodeQualifier = "y",
            IdentificationCode = "yJ",
            EntityRelationshipCode = "o0",
            EntityIdentifierCode2 = "Xx",
            //CompositeIdentificationCodes = "",
        };

        var actual = Map.MapObject<N1_PartyIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
    {
        var subject = new N1_PartyIdentification();
        subject.EntityIdentifierCode = entityIdentifierCode;
        subject.Name = "A";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", false)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_AtLeastOneName(string name, string identificationCodeQualifier, bool isValidExpected)
    {
        var subject = new N1_PartyIdentification();
        subject.EntityIdentifierCode = "11";

        subject.Name = name;
        subject.IdentificationCodeQualifier = identificationCodeQualifier;

        if (!IsNullOrEmpty(identificationCodeQualifier))
            subject.IdentificationCode = "11"; //so other rule passes

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
    {
        var subject = new N1_PartyIdentification();
        subject.Name = "A";
        subject.EntityIdentifierCode = "11";

        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        subject.IdentificationCode = identificationCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}