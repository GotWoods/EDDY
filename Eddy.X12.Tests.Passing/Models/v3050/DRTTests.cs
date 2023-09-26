using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DRT*k*wx*7*5*r*g";

		var expected = new DRT_DeprescriptionRateDetail()
		{
			LoadEmptyStatusCode = "k",
			BilledRatedAsQualifier = "wx",
			MonetaryAmount = 7,
			Percent = 5,
			ChangeTypeCode = "r",
			YesNoConditionOrResponseCode = "g",
		};

		var actual = Map.MapObject<DRT_DeprescriptionRateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "wx", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "wx", true)]
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
	[InlineData(7, 5, false)]
	[InlineData(0, 5, true)]
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
			subject.BilledRatedAsQualifier = "wx";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "wx", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "wx", true)]
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
