using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class VATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAT*1*9*m*hzt*5O*Xf*e*4*W*7*mj";

		var expected = new VAT_VehicleAttribute()
		{
			IndustryCode = "1",
			AmountQualifierCode = "9",
			Amount = "m",
			CurrencyCode = "hzt",
			ProductProcessCharacteristicCode = "5O",
			AgencyQualifierCode = "Xf",
			SourceSubqualifier = "e",
			IndustryCode2 = "4",
			Description = "W",
			Quantity = 7,
			UnitOrBasisForMeasurementCode = "mj",
		};

		var actual = Map.MapObject<VAT_VehicleAttribute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "m", true)]
	[InlineData("9", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredAmount(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new VAT_VehicleAttribute();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "5O", true)]
	[InlineData("4", "", false)]
	[InlineData("", "5O", true)]
	public void Validation_ARequiresBIndustryCode2(string industryCode2, string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new VAT_VehicleAttribute();
		//Required fields
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("mj", 7, true)]
	[InlineData("mj", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new VAT_VehicleAttribute();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
