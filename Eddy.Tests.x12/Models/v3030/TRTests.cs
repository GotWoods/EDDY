using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TR*1*7*fu*8*3c*Za1n8*iH*5*ih*zcfqr*1v*g0*j6*R8*5494*kIY*4";

		var expected = new TR_TariffRate()
		{
			LineNumber = 1,
			FreeFormDescription = "7",
			QuantityQualifier = "fu",
			Quantity = 8,
			UnitOrBasisForMeasurementCode = "3c",
			PackagingCode = "Za1n8",
			QuantityQualifier2 = "iH",
			Quantity2 = 5,
			UnitOrBasisForMeasurementCode2 = "ih",
			PackagingCode2 = "zcfqr",
			TypeOfServiceCode = "1v",
			StandardCarrierAlphaCode = "g0",
			RateValueQualifier = "j6",
			EquipmentDescriptionCode = "R8",
			EquipmentLength = 5494,
			CurrencyCode = "kIY",
			FreightRate = 4,
		};

		var actual = Map.MapObject<TR_TariffRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredLineNumber(int lineNumber, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		if (lineNumber > 0)
			subject.LineNumber = lineNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "fu";
			subject.Quantity = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOrBasisForMeasurementCode = "3c";
			subject.PackagingCode = "Za1n8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "iH";
			subject.Quantity2 = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOrBasisForMeasurementCode2 = "ih";
			subject.PackagingCode2 = "zcfqr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("fu", 8, true)]
	[InlineData("fu", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 1;
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOrBasisForMeasurementCode = "3c";
			subject.PackagingCode = "Za1n8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "iH";
			subject.Quantity2 = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOrBasisForMeasurementCode2 = "ih";
			subject.PackagingCode2 = "zcfqr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3c", "Za1n8", true)]
	[InlineData("3c", "", false)]
	[InlineData("", "Za1n8", false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, string packagingCode, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 1;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		subject.PackagingCode = packagingCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "fu";
			subject.Quantity = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "iH";
			subject.Quantity2 = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOrBasisForMeasurementCode2 = "ih";
			subject.PackagingCode2 = "zcfqr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("iH", 5, true)]
	[InlineData("iH", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 1;
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "fu";
			subject.Quantity = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOrBasisForMeasurementCode = "3c";
			subject.PackagingCode = "Za1n8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOrBasisForMeasurementCode2 = "ih";
			subject.PackagingCode2 = "zcfqr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ih", "zcfqr", true)]
	[InlineData("ih", "", false)]
	[InlineData("", "zcfqr", false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, string packagingCode2, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 1;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		subject.PackagingCode2 = packagingCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "fu";
			subject.Quantity = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOrBasisForMeasurementCode = "3c";
			subject.PackagingCode = "Za1n8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "iH";
			subject.Quantity2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
