using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G31Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G31*8*U4*1*nT*5*oi*7*z*v*5*5";

		var expected = new G31_TotalInvoiceQuantity()
		{
			NumberOfUnitsShipped = 8,
			UnitOrBasisForMeasurementCode = "U4",
			Weight = 1,
			UnitOrBasisForMeasurementCode2 = "nT",
			Volume = 5,
			UnitOrBasisForMeasurementCode3 = "oi",
			OrderSizingFactor = 7,
			PriceBracketIdentifier = "z",
			PaymentMethodCode = "v",
			Quantity = 5,
			Weight2 = 5,
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
		subject.UnitOrBasisForMeasurementCode = "U4";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "nT";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "oi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U4", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "nT";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "oi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "nT", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "nT", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "U4";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "oi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "oi", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "oi", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "U4";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "nT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "nT", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "nT", true)]
	public void Validation_ARequiresBOrderSizingFactor(decimal orderSizingFactor, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "U4";
		if (orderSizingFactor > 0)
			subject.OrderSizingFactor = orderSizingFactor;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "nT";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 5;
			subject.UnitOrBasisForMeasurementCode3 = "oi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
