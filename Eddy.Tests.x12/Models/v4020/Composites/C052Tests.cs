using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4020;
using Eddy.x12.Models.v4020.Composites;

namespace Eddy.x12.Tests.Models.v4020.Composites;

public class C052Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "7*e*b*b";

		var expected = new C052_MedicareStatusCode()
		{
			MedicarePlanCode = "7",
			EligibilityReasonCode = "e",
			EligibilityReasonCode2 = "b",
			EligibilityReasonCode3 = "b",
		};

		var actual = Map.MapObject<C052_MedicareStatusCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredMedicarePlanCode(string medicarePlanCode, bool isValidExpected)
	{
		var subject = new C052_MedicareStatusCode();
		//Required fields
		//Test Parameters
		subject.MedicarePlanCode = medicarePlanCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
