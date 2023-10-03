using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070.Composites;

public class C003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "io*6*jA*d5*EZ*MC*0";

		var expected = new C003_CompositeMedicalProcedureIdentifier()
		{
			ProductServiceIDQualifier = "io",
			ProductServiceID = "6",
			ProcedureModifier = "jA",
			ProcedureModifier2 = "d5",
			ProcedureModifier3 = "EZ",
			ProcedureModifier4 = "MC",
			Description = "0",
		};

		var actual = Map.MapObject<C003_CompositeMedicalProcedureIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("io", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceID = "6";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceIDQualifier = "io";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
