using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SBRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBR*E*AZ*i*U*5*w*X*wp*c*eP";

		var expected = new SBR_SubscriberInformation()
		{
			PayerResponsibilitySequenceNumberCode = "E",
			IndividualRelationshipCode = "AZ",
			ReferenceIdentification = "i",
			Name = "U",
			InsuranceTypeCode = "5",
			CoordinationOfBenefitsCode = "w",
			YesNoConditionOrResponseCode = "X",
			EmploymentStatusCode = "wp",
			ClaimFilingIndicatorCode = "c",
			SourceOfPaymentTypologyCode = "eP",
		};

		var actual = Map.MapObject<SBR_SubscriberInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredPayerResponsibilitySequenceNumberCode(string payerResponsibilitySequenceNumberCode, bool isValidExpected)
	{
		var subject = new SBR_SubscriberInformation();
		subject.PayerResponsibilitySequenceNumberCode = payerResponsibilitySequenceNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
