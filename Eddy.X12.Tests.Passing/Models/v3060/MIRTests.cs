using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIR*7*N*c*R*8*h**4*6*9*3*gfZQaF";

		var expected = new MIR_MortgageInsuranceResponse()
		{
			MortgageInsuranceApplicationType = "7",
			UnderwritingDecisionCode = "N",
			MortgageInsuranceCertificateTypeCode = "c",
			ReferenceIdentification = "R",
			Percent = 8,
			Amount = "h",
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			Percent2 = 6,
			Percent3 = 9,
			MortgageInsuranceRenewalOptionCode = "3",
			Date = "gfZQaF",
		};

		var actual = Map.MapObject<MIR_MortgageInsuranceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.UnderwritingDecisionCode = "N";
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredUnderwritingDecisionCode(string underwritingDecisionCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationType = "7";
		//Test Parameters
		subject.UnderwritingDecisionCode = underwritingDecisionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
