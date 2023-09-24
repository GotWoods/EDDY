using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIC*x*P*6*1*a*7**4*q*o*1W*m*X*J*p*i*P*G";

		var expected = new MIC_MortgageInsuranceCoverage()
		{
			MortgageInsuranceApplicationTypeCode = "x",
			MortgageInsuranceCoverageTypeCode = "P",
			MortgageInsuranceCertificateTypeCode = "6",
			PercentageAsDecimal = 1,
			PremiumRatePatternCode = "a",
			MortgageInsuranceDurationCode = "7",
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			MortgageInsuranceRenewalOptionCode = "q",
			YesNoConditionOrResponseCode = "o",
			TermsTypeCode = "1W",
			MortgageInsurancePremiumTypeCode = "m",
			Amount = "X",
			PremiumSourceEntityCode = "J",
			YesNoConditionOrResponseCode2 = "p",
			ProductServiceID = "i",
			YesNoConditionOrResponseCode3 = "P",
			YesNoConditionOrResponseCode4 = "G",
		};

		var actual = Map.MapObject<MIC_MortgageInsuranceCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredMortgageInsuranceApplicationTypeCode(string mortgageInsuranceApplicationTypeCode, bool isValidExpected)
	{
		var subject = new MIC_MortgageInsuranceCoverage();
		subject.MortgageInsuranceApplicationTypeCode = mortgageInsuranceApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
