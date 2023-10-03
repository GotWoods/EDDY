using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010;
using Eddy.x12.Models.v6010.Composites;

namespace Eddy.x12.Tests.Models.v6010.Composites;

public class C003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "NP*M*FQ*28*W7*8d*i*m*qw*y5*O7*gC";

		var expected = new C003_CompositeMedicalProcedureIdentifier()
		{
			ProductServiceIDQualifier = "NP",
			ProductServiceID = "M",
			ProcedureModifier = "FQ",
			ProcedureModifier2 = "28",
			ProcedureModifier3 = "W7",
			ProcedureModifier4 = "8d",
			Description = "i",
			ProductServiceID2 = "m",
			ProcedureModifier5 = "qw",
			ProcedureModifier6 = "y5",
			ProcedureModifier7 = "O7",
			ProcedureModifier8 = "gC",
		};

		var actual = Map.MapObject<C003_CompositeMedicalProcedureIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NP", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceID = "M";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceIDQualifier = "NP";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
