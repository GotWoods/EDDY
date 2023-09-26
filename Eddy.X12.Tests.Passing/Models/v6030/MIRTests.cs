using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class MIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIR*D*Z*A*P*7*3**3*1*3*a*5EBy3R30";

		var expected = new MIR_MortgageInsuranceResponse()
		{
			MortgageInsuranceApplicationTypeCode = "D",
			UnderwritingDecisionCode = "Z",
			MortgageInsuranceCertificateTypeCode = "A",
			ReferenceIdentification = "P",
			PercentageAsDecimal = 7,
			Amount = "3",
			CompositeUnitOfMeasure = null,
			Quantity = 3,
			PercentageAsDecimal2 = 1,
			PercentageAsDecimal3 = 3,
			MortgageInsuranceRenewalOptionCode = "a",
			Date = "5EBy3R30",
		};

		var actual = Map.MapObject<MIR_MortgageInsuranceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredMortgageInsuranceApplicationTypeCode(string mortgageInsuranceApplicationTypeCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.UnderwritingDecisionCode = "Z";
		//Test Parameters
		subject.MortgageInsuranceApplicationTypeCode = mortgageInsuranceApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredUnderwritingDecisionCode(string underwritingDecisionCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationTypeCode = "D";
		//Test Parameters
		subject.UnderwritingDecisionCode = underwritingDecisionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
