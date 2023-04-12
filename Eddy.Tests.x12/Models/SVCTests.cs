using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class SVCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SVC**9*5*k*3**5";

		var expected = new SVC_ServiceInformation()
		{
			CompositeMedicalProcedureIdentifier = "",
			MonetaryAmount = 9,
			MonetaryAmount2 = 5,
			ProductServiceID = "k",
			Quantity = 3,
			CompositeMedicalProcedureIdentifier2 = "",
			Quantity2 = 5,
		};

		var actual = Map.MapObject<SVC_ServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(C003_CompositeMedicalProcedureIdentifier compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SVC_ServiceInformation();
		subject.CompositeMedicalProcedureIdentifier = compositeMedicalProcedureIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
