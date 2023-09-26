using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class MIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIR*N*U*P*1*1*0**7*8*6*h*TMIKsrEb";

		var expected = new MIR_MortgageInsuranceResponse()
		{
			MortgageInsuranceApplicationType = "N",
			UnderwritingDecisionCode = "U",
			MortgageInsuranceCertificateTypeCode = "P",
			ReferenceIdentification = "1",
			Percent = 1,
			Amount = "0",
			CompositeUnitOfMeasure = null,
			Quantity = 7,
			Percent2 = 8,
			Percent3 = 6,
			MortgageInsuranceRenewalOptionCode = "h",
			Date = "TMIKsrEb",
		};

		var actual = Map.MapObject<MIR_MortgageInsuranceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.UnderwritingDecisionCode = "U";
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredUnderwritingDecisionCode(string underwritingDecisionCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationType = "N";
		//Test Parameters
		subject.UnderwritingDecisionCode = underwritingDecisionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
