using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class VATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAT*b*6*U*Tvi*b4*1t*N*Q*R*8*PC*el";

		var expected = new VAT_VehicleAttribute()
		{
			IndustryCode = "b",
			AmountQualifierCode = "6",
			Amount = "U",
			CurrencyCode = "Tvi",
			ProductProcessCharacteristicCode = "b4",
			AgencyQualifierCode = "1t",
			SourceSubqualifier = "N",
			IndustryCode2 = "Q",
			Description = "R",
			Quantity = 8,
			UnitOrBasisForMeasurementCode = "PC",
			SurfaceLayerPositionCode = "el",
		};

		var actual = Map.MapObject<VAT_VehicleAttribute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "U", true)]
	[InlineData("6", "", false)]
	[InlineData("", "U", false)]
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
	[InlineData("Q", "b4", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "b4", true)]
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
	[InlineData("PC", 8, true)]
	[InlineData("PC", 0, false)]
	[InlineData("", 8, true)]
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
