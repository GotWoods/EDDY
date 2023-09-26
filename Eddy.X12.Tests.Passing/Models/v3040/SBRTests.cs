using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SBRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SBR*X*jr*c*M*e*W*T*eE*C";

		var expected = new SBR_SubscriberInformation()
		{
			PayerResponsibilitySequenceNumberCode = "X",
			IndividualRelationshipCode = "jr",
			ReferenceNumber = "c",
			Name = "M",
			InsuranceTypeCode = "e",
			CoordinationOfBenefitsCode = "W",
			YesNoConditionOrResponseCode = "T",
			EmploymentStatusCode = "eE",
			ClaimFilingIndicatorCode = "C",
		};

		var actual = Map.MapObject<SBR_SubscriberInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredPayerResponsibilitySequenceNumberCode(string payerResponsibilitySequenceNumberCode, bool isValidExpected)
	{
		var subject = new SBR_SubscriberInformation();
		//Required fields
		//Test Parameters
		subject.PayerResponsibilitySequenceNumberCode = payerResponsibilitySequenceNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
