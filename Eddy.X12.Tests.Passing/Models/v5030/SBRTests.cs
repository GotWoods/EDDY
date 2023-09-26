using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SBRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBR*w*WG*Y*8*c*r*e*G7*w";

		var expected = new SBR_SubscriberInformation()
		{
			PayerResponsibilitySequenceNumberCode = "w",
			IndividualRelationshipCode = "WG",
			ReferenceIdentification = "Y",
			Name = "8",
			InsuranceTypeCode = "c",
			CoordinationOfBenefitsCode = "r",
			YesNoConditionOrResponseCode = "e",
			EmploymentStatusCode = "G7",
			ClaimFilingIndicatorCode = "w",
		};

		var actual = Map.MapObject<SBR_SubscriberInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredPayerResponsibilitySequenceNumberCode(string payerResponsibilitySequenceNumberCode, bool isValidExpected)
	{
		var subject = new SBR_SubscriberInformation();
		//Required fields
		//Test Parameters
		subject.PayerResponsibilitySequenceNumberCode = payerResponsibilitySequenceNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
