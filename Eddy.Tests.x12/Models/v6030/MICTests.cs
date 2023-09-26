using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class MICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIC*a*9*l*7*9*9**3*G*x*n7*y*Q*Y*z*f*7*m";

		var expected = new MIC_MortgageInsuranceCoverage()
		{
			MortgageInsuranceApplicationTypeCode = "a",
			MortgageInsuranceCoverageTypeCode = "9",
			MortgageInsuranceCertificateTypeCode = "l",
			PercentageAsDecimal = 7,
			PremiumRatePatternCode = "9",
			MortgageInsuranceDurationCode = "9",
			CompositeUnitOfMeasure = null,
			Quantity = 3,
			MortgageInsuranceRenewalOptionCode = "G",
			YesNoConditionOrResponseCode = "x",
			TermsTypeCode = "n7",
			MortgageInsurancePremiumTypeCode = "y",
			Amount = "Q",
			PremiumSourceEntityCode = "Y",
			YesNoConditionOrResponseCode2 = "z",
			ProductServiceID = "f",
			YesNoConditionOrResponseCode3 = "7",
			YesNoConditionOrResponseCode4 = "m",
		};

		var actual = Map.MapObject<MIC_MortgageInsuranceCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredMortgageInsuranceApplicationTypeCode(string mortgageInsuranceApplicationTypeCode, bool isValidExpected)
	{
		var subject = new MIC_MortgageInsuranceCoverage();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationTypeCode = mortgageInsuranceApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
