using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class VATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAT*T*K*s*Geg*25*3R*b*4*b*1*Fw";

		var expected = new VAT_VehicleAttribute()
		{
			IndustryCode = "T",
			AmountQualifierCode = "K",
			Amount = "s",
			CurrencyCode = "Geg",
			ProductProcessCharacteristicCode = "25",
			AgencyQualifierCode = "3R",
			SourceSubqualifier = "b",
			IndustryCode2 = "4",
			Description = "b",
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "Fw",
		};

		var actual = Map.MapObject<VAT_VehicleAttribute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "s", true)]
	[InlineData("K", "", false)]
	[InlineData("", "s", false)]
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
	[InlineData("4", "25", true)]
	[InlineData("4", "", false)]
	[InlineData("", "25", true)]
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
	[InlineData("Fw", 1, true)]
	[InlineData("Fw", 0, false)]
	[InlineData("", 1, true)]
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
