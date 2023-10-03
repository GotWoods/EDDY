using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5010;
using Eddy.x12.Models.v5010.Composites;

namespace Eddy.x12.Tests.Models.v5010.Composites;

public class C003Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "3D*i*3f*Wh*wO*HG*e*X";

		var expected = new C003_CompositeMedicalProcedureIdentifier()
		{
			ProductServiceIDQualifier = "3D",
			ProductServiceID = "i",
			ProcedureModifier = "3f",
			ProcedureModifier2 = "Wh",
			ProcedureModifier3 = "wO",
			ProcedureModifier4 = "HG",
			Description = "e",
			ProductServiceID2 = "X",
		};

		var actual = Map.MapObject<C003_CompositeMedicalProcedureIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3D", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new C003_CompositeMedicalProcedureIdentifier();
		//Required fields
		subject.ProductServiceIDQualifier = "3D";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
