using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5020;
using Eddy.x12.Models.v5020.Composites;

namespace Eddy.x12.Tests.Models.v5020.Composites;

public class C003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Be*W*8g*Ee*G6*3q*Z*Y*Gf*xT*tM*wR";

		var expected = new C003_CompositeMedicalProcedureIdentifier()
		{
			ProductServiceIDQualifier = "Be",
			ProductServiceID = "W",
			ProcedureModifier = "8g",
			ProcedureModifier2 = "Ee",
			ProcedureModifier3 = "G6",
			ProcedureModifier4 = "3q",
			Description = "Z",
			ProductServiceID2 = "Y",
			ProcedureModifier5 = "Gf",
			ProcedureModifier6 = "xT",
			ProcedureModifier7 = "tM",
			ProcedureModifier8 = "wR",
		};

		var actual = Map.MapObject<C003_CompositeMedicalProcedureIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Be", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceID = "W";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceIDQualifier = "Be";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
