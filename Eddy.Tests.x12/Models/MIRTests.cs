using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIR*6*L*u*5*8*Y**6*4*3*O*o9vK7E08";

		var expected = new MIR_MortgageInsuranceResponse()
		{
			MortgageInsuranceApplicationTypeCode = "6",
			UnderwritingDecisionCode = "L",
			MortgageInsuranceCertificateTypeCode = "u",
			ReferenceIdentification = "5",
			PercentageAsDecimal = 8,
			Amount = "Y",
			CompositeUnitOfMeasure = null,
			Quantity = 6,
			PercentageAsDecimal2 = 4,
			PercentageAsDecimal3 = 3,
			MortgageInsuranceRenewalOptionCode = "O",
			Date = "o9vK7E08",
		};

		var actual = Map.MapObject<MIR_MortgageInsuranceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredMortgageInsuranceApplicationTypeCode(string mortgageInsuranceApplicationTypeCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		subject.UnderwritingDecisionCode = "L";
		subject.MortgageInsuranceApplicationTypeCode = mortgageInsuranceApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredUnderwritingDecisionCode(string underwritingDecisionCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		subject.MortgageInsuranceApplicationTypeCode = "6";
		subject.UnderwritingDecisionCode = underwritingDecisionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
