using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SBRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBR*x*Br*M*f*9*h*B*6t*q";

		var expected = new SBR_SubscriberInformation()
		{
			PayerResponsibilitySequenceNumberCode = "x",
			IndividualRelationshipCode = "Br",
			ReferenceIdentification = "M",
			Name = "f",
			InsuranceTypeCode = "9",
			CoordinationOfBenefitsCode = "h",
			YesNoConditionOrResponseCode = "B",
			EmploymentStatusCode = "6t",
			ClaimFilingIndicatorCode = "q",
		};

		var actual = Map.MapObject<SBR_SubscriberInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPayerResponsibilitySequenceNumberCode(string payerResponsibilitySequenceNumberCode, bool isValidExpected)
	{
		var subject = new SBR_SubscriberInformation();
		//Required fields
		//Test Parameters
		subject.PayerResponsibilitySequenceNumberCode = payerResponsibilitySequenceNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
