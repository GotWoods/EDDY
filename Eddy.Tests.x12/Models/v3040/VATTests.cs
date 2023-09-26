using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class VATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAT*2*6*Y*Y6q*uf*qR*y*k*i*7*hm";

		var expected = new VAT_VehicleAttribute()
		{
			IndustryCode = "2",
			AmountQualifierCode = "6",
			Amount = "Y",
			CurrencyCode = "Y6q",
			ProductProcessCharacteristicCode = "uf",
			AgencyQualifierCode = "qR",
			SourceSubqualifier = "y",
			IndustryCode2 = "k",
			Description = "i",
			Quantity = 7,
			UnitOrBasisForMeasurementCode = "hm",
		};

		var actual = Map.MapObject<VAT_VehicleAttribute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "Y", true)]
	[InlineData("6", "", false)]
	[InlineData("", "Y", false)]
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
	[InlineData("k", "uf", true)]
	[InlineData("k", "", false)]
	[InlineData("", "uf", true)]
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
	[InlineData("hm", 7, true)]
	[InlineData("hm", 0, false)]
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
