using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IDCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDC*o*P*4*0";

		var expected = new IDC_IdentificationCard()
		{
			PlanCoverageDescription = "o",
			IdentificationCardTypeCode = "P",
			Quantity = 4,
			ActionCode = "0",
		};

		var actual = Map.MapObject<IDC_IdentificationCard>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredPlanCoverageDescription(string planCoverageDescription, bool isValidExpected)
	{
		var subject = new IDC_IdentificationCard();
		subject.IdentificationCardTypeCode = "P";
		subject.PlanCoverageDescription = planCoverageDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredIdentificationCardTypeCode(string identificationCardTypeCode, bool isValidExpected)
	{
		var subject = new IDC_IdentificationCard();
		subject.PlanCoverageDescription = "o";
		subject.IdentificationCardTypeCode = identificationCardTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
