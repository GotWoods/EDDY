using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class G31Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G31*4*DZ*7*h6*6*o1*6*R*Z*9*9";

		var expected = new G31_TotalInvoiceQuantity()
		{
			NumberOfUnitsShipped = 4,
			UnitOrBasisForMeasurementCode = "DZ",
			Weight = 7,
			UnitOrBasisForMeasurementCode2 = "h6",
			Volume = 6,
			UnitOrBasisForMeasurementCode3 = "o1",
			OrderSizingFactor = 6,
			PriceBracketIdentifier = "R",
			PaymentMethodTypeCode = "Z",
			Quantity = 9,
			Weight2 = 9,
		};

		var actual = Map.MapObject<G31_TotalInvoiceQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.UnitOrBasisForMeasurementCode = "DZ";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 7;
			subject.UnitOrBasisForMeasurementCode2 = "h6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "o1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DZ", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 7;
			subject.UnitOrBasisForMeasurementCode2 = "h6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "o1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "h6", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "h6", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 4;
		subject.UnitOrBasisForMeasurementCode = "DZ";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "o1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "o1", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "o1", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 4;
		subject.UnitOrBasisForMeasurementCode = "DZ";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 7;
			subject.UnitOrBasisForMeasurementCode2 = "h6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "h6", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "h6", true)]
	public void Validation_ARequiresBOrderSizingFactor(decimal orderSizingFactor, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 4;
		subject.UnitOrBasisForMeasurementCode = "DZ";
		if (orderSizingFactor > 0)
			subject.OrderSizingFactor = orderSizingFactor;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 7;
			subject.UnitOrBasisForMeasurementCode2 = "h6";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOrBasisForMeasurementCode3 = "o1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
