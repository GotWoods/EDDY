using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SBRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBR*e*Z7*K*U*3*o*g*Q9*h";

		var expected = new SBR_SubscriberInformation()
		{
			PayorResponsibilitySequenceNumberCode = "e",
			IndividualRelationshipCode = "Z7",
			ReferenceNumber = "K",
			Name = "U",
			InsuranceTypeCode = "3",
			CoordinationOfBenefitsCode = "o",
			YesNoConditionOrResponseCode = "g",
			EmploymentStatusCode = "Q9",
			ClaimFilingIndicatorCode = "h",
		};

		var actual = Map.MapObject<SBR_SubscriberInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPayorResponsibilitySequenceNumberCode(string payorResponsibilitySequenceNumberCode, bool isValidExpected)
	{
		var subject = new SBR_SubscriberInformation();
		//Required fields
		//Test Parameters
		subject.PayorResponsibilitySequenceNumberCode = payorResponsibilitySequenceNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
