using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class LH6Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LH6*HWQ1be0GkPJwn4pOlgp2R66vs6dDr7bC5PIreo082eDxYSraMV4hZ2PAs2xN*8*MU6eKqh63ihkPIqkhTbxVHZX1*loMfeFy5nP0ucQuIneVhdmyWM";

        var expected = new LH6_HazardousCertification()
        {
            Name = "HWQ1be0GkPJwn4pOlgp2R66vs6dDr7bC5PIreo082eDxYSraMV4hZ2PAs2xN",
            HazardousCertificationCode = "8",
            HazardousCertificationDeclaration = "MU6eKqh63ihkPIqkhTbxVHZX1",
            HazardousCertificationDeclaration2 = "loMfeFy5nP0ucQuIneVhdmyWM",
        };

        var actual = Map.MapObject<LH6_HazardousCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("1", "", false)]
    public void Validation_AllAreRequiredHazardousCertificationCode(string hazardousCertificationCode, string hazardousCertificationDeclaration, bool isValidExpected)
    {
        var subject = new LH6_HazardousCertification();
        subject.HazardousCertificationCode = hazardousCertificationCode;
        subject.HazardousCertificationDeclaration = hazardousCertificationDeclaration;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}