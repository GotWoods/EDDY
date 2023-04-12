using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C003Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "xf*u*J7*IE*N8*Cq*w*i*SW*fi*v6*3T";

        var expected = new C003_CompositeMedicalProcedureIdentifier()
        {
            ProductServiceIDQualifier = "xf",
            ProductServiceID = "u",
            ProcedureModifier = "J7",
            ProcedureModifier2 = "IE",
            ProcedureModifier3 = "N8",
            ProcedureModifier4 = "Cq",
            Description = "w",
            ProductServiceID2 = "i",
            ProcedureModifier5 = "SW",
            ProcedureModifier6 = "fi",
            ProcedureModifier7 = "v6",
            ProcedureModifier8 = "3T",
        };

        var actual = Map.MapObject<C003_CompositeMedicalProcedureIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("xf", true)]
    public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
    {
        var subject = new C003_CompositeMedicalProcedureIdentifier();
        subject.ProductServiceID = "u";
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("u", true)]
    public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
    {
        var subject = new C003_CompositeMedicalProcedureIdentifier();
        subject.ProductServiceIDQualifier = "xf";
        subject.ProductServiceID = productServiceID;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}
