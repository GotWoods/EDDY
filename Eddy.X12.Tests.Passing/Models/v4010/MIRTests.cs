using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIR*0*c*P*A*1*u**2*1*4*o*o3hqF4DF";

		var expected = new MIR_MortgageInsuranceResponse()
		{
			MortgageInsuranceApplicationType = "0",
			UnderwritingDecisionCode = "c",
			MortgageInsuranceCertificateTypeCode = "P",
			ReferenceIdentification = "A",
			Percent = 1,
			Amount = "u",
			CompositeUnitOfMeasure = null,
			Quantity = 2,
			Percent2 = 1,
			Percent3 = 4,
			MortgageInsuranceRenewalOptionCode = "o",
			Date = "o3hqF4DF",
		};

		var actual = Map.MapObject<MIR_MortgageInsuranceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.UnderwritingDecisionCode = "c";
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredUnderwritingDecisionCode(string underwritingDecisionCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationType = "0";
		//Test Parameters
		subject.UnderwritingDecisionCode = underwritingDecisionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
