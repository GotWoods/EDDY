using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G31Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G31*8*KG*4*f6*6*bN*3*7*6*7*6";

		var expected = new G31_TotalInvoiceQuantity()
		{
			NumberOfUnitsShipped = 8,
			UnitOrBasisForMeasurementCode = "KG",
			Weight = 4,
			UnitOrBasisForMeasurementCode2 = "f6",
			Volume = 6,
			UnitOrBasisForMeasurementCode3 = "bN",
			OrderSizingFactor = 3,
			PriceBracketIdentifier = "7",
			PaymentMethodCode = "6",
			Quantity = 7,
			Weight2 = 6,
		};

		var actual = Map.MapObject<G31_TotalInvoiceQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.UnitOrBasisForMeasurementCode = "KG";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "f6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "bN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KG", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "f6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "bN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "f6", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "f6", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "KG";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "bN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "bN", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "bN", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "KG";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "f6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "f6", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "f6", true)]
	public void Validation_ARequiresBOrderSizingFactor(decimal orderSizingFactor, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "KG";
		if (orderSizingFactor > 0)
			subject.OrderSizingFactor = orderSizingFactor;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "f6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "bN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
