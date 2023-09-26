using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class MICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIC*E*D*t*7*e*y**2*t*3*Bv*0*r*d*j*U*G*P";

		var expected = new MIC_MortgageInsuranceCoverage()
		{
			MortgageInsuranceApplicationType = "E",
			MortgageInsuranceCoverageTypeCode = "D",
			MortgageInsuranceCertificateTypeCode = "t",
			Percent = 7,
			PremiumRatePatternCode = "e",
			MortgageInsuranceDurationCode = "y",
			CompositeUnitOfMeasure = null,
			Quantity = 2,
			MortgageInsuranceRenewalOptionCode = "t",
			YesNoConditionOrResponseCode = "3",
			TermsTypeCode = "Bv",
			MortgageInsurancePremiumTypeCode = "0",
			Amount = "r",
			PremiumSourceEntityCode = "d",
			YesNoConditionOrResponseCode2 = "j",
			ProductServiceID = "U",
			YesNoConditionOrResponseCode3 = "G",
			YesNoConditionOrResponseCode4 = "P",
		};

		var actual = Map.MapObject<MIC_MortgageInsuranceCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIC_MortgageInsuranceCoverage();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
