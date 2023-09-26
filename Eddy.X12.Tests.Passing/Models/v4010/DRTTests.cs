using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DRT*b*vS*2*2*6*6";

		var expected = new DRT_DeprescriptionRateDetail()
		{
			LoadEmptyStatusCode = "b",
			BilledRatedAsQualifier = "vS",
			MonetaryAmount = 2,
			Percent = 2,
			ChangeTypeCode = "6",
			YesNoConditionOrResponseCode = "6",
		};

		var actual = Map.MapObject<DRT_DeprescriptionRateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "vS", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "vS", true)]
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
	[InlineData(2, 2, false)]
	[InlineData(0, 2, true)]
	public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, decimal percent, bool isValidExpected)
	{
		var subject = new DRT_DeprescriptionRateDetail();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percent > 0) 
			subject.Percent = percent;
		//A Requires B
		if (percent > 0)
			subject.BilledRatedAsQualifier = "vS";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "vS", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "vS", true)]
	public void Validation_ARequiresBPercent(decimal percent, string billedRatedAsQualifier, bool isValidExpected)
	{
		var subject = new DRT_DeprescriptionRateDetail();
		//Required fields
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		subject.BilledRatedAsQualifier = billedRatedAsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
