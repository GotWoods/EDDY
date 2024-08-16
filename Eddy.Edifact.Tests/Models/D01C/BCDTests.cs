using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class BCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BCD+K+o+0+3++g+J+C+K+O+O";

		var expected = new BCD_BenefitAndCoverageDetail()
		{
			ServiceTypeCode = "K",
			BenefitAndCoverageCode = "o",
			BenefitCoverageConstituentsCode = "0",
			PeriodTypeCode = "3",
			MonetaryAmount = null,
			Percentage = "g",
			QuantityTypeCodeQualifier = "J",
			Quantity = "C",
			YesOrNoIndicatorCode = "K",
			InsuranceCoverTypeCode = "O",
			FreeText = "O",
		};

		var actual = Map.MapObject<BCD_BenefitAndCoverageDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredServiceTypeCode(string serviceTypeCode, bool isValidExpected)
	{
		var subject = new BCD_BenefitAndCoverageDetail();
		//Required fields
		subject.BenefitAndCoverageCode = "o";
		//Test Parameters
		subject.ServiceTypeCode = serviceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredBenefitAndCoverageCode(string benefitAndCoverageCode, bool isValidExpected)
	{
		var subject = new BCD_BenefitAndCoverageDetail();
		//Required fields
		subject.ServiceTypeCode = "K";
		//Test Parameters
		subject.BenefitAndCoverageCode = benefitAndCoverageCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
