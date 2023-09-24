using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TR*4*U*cv*5*UB*vxe5a*AP*8*BI*rdDBf*Zr*Yb*BM*hV*7734*N6N*1";

		var expected = new TR_TariffRate()
		{
			LineNumber = 4,
			FreeFormDescription = "U",
			QuantityQualifier = "cv",
			Quantity = 5,
			UnitOfMeasurementCode = "UB",
			PackagingCode = "vxe5a",
			QuantityQualifier2 = "AP",
			Quantity2 = 8,
			UnitOfMeasurementCode2 = "BI",
			PackagingCode2 = "rdDBf",
			TypeOfServiceCode = "Zr",
			StandardCarrierAlphaCode = "Yb",
			RateValueQualifier = "BM",
			EquipmentDescriptionCode = "hV",
			EquipmentLength = 7734,
			CurrencyCode = "N6N",
			FreightRate = 1,
		};

		var actual = Map.MapObject<TR_TariffRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredLineNumber(int lineNumber, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		if (lineNumber > 0)
			subject.LineNumber = lineNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "cv";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOfMeasurementCode = "UB";
			subject.PackagingCode = "vxe5a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "AP";
			subject.Quantity2 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOfMeasurementCode2 = "BI";
			subject.PackagingCode2 = "rdDBf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("cv", 5, true)]
	[InlineData("cv", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 4;
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOfMeasurementCode = "UB";
			subject.PackagingCode = "vxe5a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "AP";
			subject.Quantity2 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOfMeasurementCode2 = "BI";
			subject.PackagingCode2 = "rdDBf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UB", "vxe5a", true)]
	[InlineData("UB", "", false)]
	[InlineData("", "vxe5a", false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode(string unitOfMeasurementCode, string packagingCode, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 4;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		subject.PackagingCode = packagingCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "cv";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "AP";
			subject.Quantity2 = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOfMeasurementCode2 = "BI";
			subject.PackagingCode2 = "rdDBf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("AP", 8, true)]
	[InlineData("AP", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredQuantityQualifier2(string quantityQualifier2, decimal quantity2, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 4;
		subject.QuantityQualifier2 = quantityQualifier2;
		if (quantity2 > 0)
			subject.Quantity2 = quantity2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "cv";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOfMeasurementCode = "UB";
			subject.PackagingCode = "vxe5a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2) || !string.IsNullOrEmpty(subject.PackagingCode2))
		{
			subject.UnitOfMeasurementCode2 = "BI";
			subject.PackagingCode2 = "rdDBf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BI", "rdDBf", true)]
	[InlineData("BI", "", false)]
	[InlineData("", "rdDBf", false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, string packagingCode2, bool isValidExpected)
	{
		var subject = new TR_TariffRate();
		subject.LineNumber = 4;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		subject.PackagingCode2 = packagingCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "cv";
			subject.Quantity = 5;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.PackagingCode))
		{
			subject.UnitOfMeasurementCode = "UB";
			subject.PackagingCode = "vxe5a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier2) || !string.IsNullOrEmpty(subject.QuantityQualifier2) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier2 = "AP";
			subject.Quantity2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
