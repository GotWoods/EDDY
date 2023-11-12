using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class DRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DRT*N*2S*8*3*e*M";

		var expected = new DRT_DeprescriptionRateDetail()
		{
			LoadEmptyStatusCode = "N",
			BilledRatedAsQualifier = "2S",
			MonetaryAmount = 8,
			PercentageAsDecimal = 3,
			ChangeTypeCode = "e",
			YesNoConditionOrResponseCode = "M",
		};

		var actual = Map.MapObject<DRT_DeprescriptionRateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "2S", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "2S", true)]
	public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new DRT_DeprescriptionRateDetail();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 3, false)]
	[InlineData(0, 3, true)]
	public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new DRT_DeprescriptionRateDetail();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		//A Requires B
		if (percentageAsDecimal > 0)
			subject.BilledRatedAsQualifier = "2S";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "2S", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "2S", true)]
	public void Validation_ARequiresBPercentageAsDecimal(decimal percentageAsDecimal, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new DRT_DeprescriptionRateDetail();
		//Required fields
		//Test Parameters
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
