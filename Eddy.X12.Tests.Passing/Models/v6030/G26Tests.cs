using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class G26Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G26*PT*AN*w4OdrAyp*ZGt*1*c1";

		var expected = new G26_PricingConditions()
		{
			PriceConditionCode = "PT",
			DateQualifier = "AN",
			Date = "w4OdrAyp",
			QuantityBasisCode = "ZGt",
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "c1",
		};

		var actual = Map.MapObject<G26_PricingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PT", true)]
	public void Validation_RequiredPriceConditionCode(string priceConditionCode, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = priceConditionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "AN";
			subject.Date = "w4OdrAyp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AN", "w4OdrAyp", true)]
	[InlineData("AN", "", false)]
	[InlineData("", "w4OdrAyp", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G26_PricingConditions();
		subject.PriceConditionCode = "PT";
		subject.DateQualifier = dateQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
