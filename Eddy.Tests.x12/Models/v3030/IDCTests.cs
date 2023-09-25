using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class IDCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDC*P*P";

		var expected = new IDC_IdentificationCard()
		{
			PlanCoverageDescription = "P",
			IdentificationCardTypeCode = "P",
		};

		var actual = Map.MapObject<IDC_IdentificationCard>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredPlanCoverageDescription(string planCoverageDescription, bool isValidExpected)
	{
		var subject = new IDC_IdentificationCard();
		//Required fields
		subject.IdentificationCardTypeCode = "P";
		//Test Parameters
		subject.PlanCoverageDescription = planCoverageDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredIdentificationCardTypeCode(string identificationCardTypeCode, bool isValidExpected)
	{
		var subject = new IDC_IdentificationCard();
		//Required fields
		subject.PlanCoverageDescription = "P";
		//Test Parameters
		subject.IdentificationCardTypeCode = identificationCardTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
