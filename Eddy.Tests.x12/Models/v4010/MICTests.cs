using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIC*Q*I*6*6*C*J**9*h*g*Sm*a*7*Y*G*U*S";

		var expected = new MIC_MortgageInsuranceCoverage()
		{
			MortgageInsuranceApplicationType = "Q",
			MortgageInsuranceCoverageTypeCode = "I",
			MortgageInsuranceCertificateTypeCode = "6",
			Percent = 6,
			PremiumRatePatternCode = "C",
			MortgageInsuranceDurationCode = "J",
			CompositeUnitOfMeasure = null,
			Quantity = 9,
			MortgageInsuranceRenewalOptionCode = "h",
			YesNoConditionOrResponseCode = "g",
			TermsTypeCode = "Sm",
			MortgageInsurancePremiumTypeCode = "a",
			Amount = "7",
			PremiumSourceEntityCode = "Y",
			YesNoConditionOrResponseCode2 = "G",
			ProductServiceID = "U",
			YesNoConditionOrResponseCode3 = "S",
		};

		var actual = Map.MapObject<MIC_MortgageInsuranceCoverage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIC_MortgageInsuranceCoverage();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
