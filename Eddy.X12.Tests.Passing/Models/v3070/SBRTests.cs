using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SBRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBR*n*70*n*R*O*y*s*3T*L";

		var expected = new SBR_SubscriberInformation()
		{
			PayerResponsibilitySequenceNumberCode = "n",
			IndividualRelationshipCode = "70",
			ReferenceIdentification = "n",
			Name = "R",
			InsuranceTypeCode = "O",
			CoordinationOfBenefitsCode = "y",
			YesNoConditionOrResponseCode = "s",
			EmploymentStatusCode = "3T",
			ClaimFilingIndicatorCode = "L",
		};

		var actual = Map.MapObject<SBR_SubscriberInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredPayerResponsibilitySequenceNumberCode(string payerResponsibilitySequenceNumberCode, bool isValidExpected)
	{
		var subject = new SBR_SubscriberInformation();
		//Required fields
		//Test Parameters
		subject.PayerResponsibilitySequenceNumberCode = payerResponsibilitySequenceNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
