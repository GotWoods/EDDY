using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAT*2*Z*M*irg*M0*Wp*b*p*N*3*dX*ec";

		var expected = new VAT_VehicleAttribute()
		{
			IndustryCode = "2",
			AmountQualifierCode = "Z",
			Amount = "M",
			CurrencyCode = "irg",
			ProductProcessCharacteristicCode = "M0",
			AgencyQualifierCode = "Wp",
			SourceSubqualifier = "b",
			IndustryCode2 = "p",
			Description = "N",
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "dX",
			SurfaceLayerPositionCode = "ec",
		};

		var actual = Map.MapObject<VAT_VehicleAttribute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Z", "M", true)]
	[InlineData("", "M", false)]
	[InlineData("Z", "", false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, string amount, bool isValidExpected)
	{
		var subject = new VAT_VehicleAttribute();
		subject.AmountQualifierCode = amountQualifierCode;
		subject.Amount = amount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "M0", true)]
	[InlineData("p", "", false)]
	public void Validation_ARequiresBIndustryCode2(string industryCode2, string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new VAT_VehicleAttribute();
		subject.IndustryCode2 = industryCode2;
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 3, true)]
	[InlineData("dX", 0, false)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new VAT_VehicleAttribute();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
