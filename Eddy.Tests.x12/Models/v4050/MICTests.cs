using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class MICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIC*o*y*A*5*h*m**8*B*r*Uu*z*r*p*g*X*a*l";

		var expected = new MIC_MortgageInsuranceCoverage()
		{
			MortgageInsuranceApplicationType = "o",
			MortgageInsuranceCoverageTypeCode = "y",
			MortgageInsuranceCertificateTypeCode = "A",
			PercentageAsDecimal = 5,
			PremiumRatePatternCode = "h",
			MortgageInsuranceDurationCode = "m",
			CompositeUnitOfMeasure = null,
			Quantity = 8,
			MortgageInsuranceRenewalOptionCode = "B",
			YesNoConditionOrResponseCode = "r",
			TermsTypeCode = "Uu",
			MortgageInsurancePremiumTypeCode = "z",
			Amount = "r",
			PremiumSourceEntityCode = "p",
			YesNoConditionOrResponseCode2 = "g",
			ProductServiceID = "X",
			YesNoConditionOrResponseCode3 = "a",
			YesNoConditionOrResponseCode4 = "l",
		};

		var actual = Map.MapObject<MIC_MortgageInsuranceCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIC_MortgageInsuranceCoverage();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
