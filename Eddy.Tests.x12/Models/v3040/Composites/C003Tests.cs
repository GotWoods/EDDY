using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3040;
using Eddy.x12.Models.v3040.Composites;

namespace Eddy.x12.Tests.Models.v3040.Composites;

public class C003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "g3*7*Ve*ht*0i*eJ*v";

		var expected = new C003_CompositeMedicalProcedureIdentifier()
		{
			ProductServiceIDQualifier = "g3",
			ProductServiceID = "7",
			ProcedureModifier = "Ve",
			ProcedureModifier2 = "ht",
			ProcedureModifier3 = "0i",
			ProcedureModifier4 = "eJ",
			Description = "v",
		};

		var actual = Map.MapObject<C003_CompositeMedicalProcedureIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g3", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceID = "7";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceIDQualifier = "g3";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
