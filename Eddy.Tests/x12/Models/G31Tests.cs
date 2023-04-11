using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G31Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G31*9*ye*2*7V*1*a1*2*J*V*6*2";

		var expected = new G31_TotalInvoiceQuantity()
		{
			NumberOfUnitsShipped = 9,
			UnitOrBasisForMeasurementCode = "ye",
			Weight = 2,
			UnitOrBasisForMeasurementCode2 = "7V",
			Volume = 1,
			UnitOrBasisForMeasurementCode3 = "a1",
			OrderSizingFactor = 2,
			PriceBracketIdentifier = "J",
			PaymentMethodTypeCode = "V",
			Quantity = 6,
			Weight2 = 2,
		};

		var actual = Map.MapObject<G31_TotalInvoiceQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.UnitOrBasisForMeasurementCode = "ye";
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ye", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "7V", true)]
	[InlineData(0, "7V", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = "ye";
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "a1", true)]
	[InlineData(0, "a1", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = "ye";
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "7V", true)]
	[InlineData(2, "", false)]
	public void Validation_ARequiresBOrderSizingFactor(decimal orderSizingFactor, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 9;
		subject.UnitOrBasisForMeasurementCode = "ye";
		if (orderSizingFactor > 0)
		subject.OrderSizingFactor = orderSizingFactor;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
