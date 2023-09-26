using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class MICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIC*k*0*r*1*E*M**7*S*4*Gf*Z*5*k*i*g*9*L";

		var expected = new MIC_MortgageInsuranceCoverage()
		{
			MortgageInsuranceApplicationType = "k",
			MortgageInsuranceCoverageTypeCode = "0",
			MortgageInsuranceCertificateTypeCode = "r",
			PercentageAsDecimal = 1,
			PremiumRatePatternCode = "E",
			MortgageInsuranceDurationCode = "M",
			CompositeUnitOfMeasure = null,
			Quantity = 7,
			MortgageInsuranceRenewalOptionCode = "S",
			YesNoConditionOrResponseCode = "4",
			TermsTypeCode = "Gf",
			MortgageInsurancePremiumTypeCode = "Z",
			Amount = "5",
			PremiumSourceEntityCode = "k",
			YesNoConditionOrResponseCode2 = "i",
			ProductServiceID = "g",
			YesNoConditionOrResponseCode3 = "9",
			YesNoConditionOrResponseCode4 = "L",
		};

		var actual = Map.MapObject<MIC_MortgageInsuranceCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIC_MortgageInsuranceCoverage();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
