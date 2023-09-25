using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class IDCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDC*3*4*4*W";

		var expected = new IDC_IdentificationCard()
		{
			PlanCoverageDescription = "3",
			IdentificationCardTypeCode = "4",
			Quantity = 4,
			ActionCode = "W",
		};

		var actual = Map.MapObject<IDC_IdentificationCard>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredPlanCoverageDescription(string planCoverageDescription, bool isValidExpected)
	{
		var subject = new IDC_IdentificationCard();
		//Required fields
		subject.IdentificationCardTypeCode = "4";
		//Test Parameters
		subject.PlanCoverageDescription = planCoverageDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredIdentificationCardTypeCode(string identificationCardTypeCode, bool isValidExpected)
	{
		var subject = new IDC_IdentificationCard();
		//Required fields
		subject.PlanCoverageDescription = "3";
		//Test Parameters
		subject.IdentificationCardTypeCode = identificationCardTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
