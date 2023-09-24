using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G55Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G55*lk*S*BR*7*7*09*2*Uy*4*v2*5*YP*1*5*qh*4*R*iZu*1*2*k*y*3*6*0*7*r*a*ge*z*w*4*nmt";

		var expected = new G55_ItemCharacteristicsConsumerUnit()
		{
			ProductServiceIDQualifier = "lk",
			ProductServiceID = "S",
			ProductServiceIDQualifier2 = "BR",
			ProductServiceID2 = "7",
			Height = 7,
			UnitOrBasisForMeasurementCode = "09",
			Width = 2,
			UnitOrBasisForMeasurementCode2 = "Uy",
			Length = 4,
			UnitOrBasisForMeasurementCode3 = "v2",
			Volume = 5,
			UnitOrBasisForMeasurementCode4 = "YP",
			Pack = 1,
			Size = 5,
			UnitOrBasisForMeasurementCode5 = "qh",
			CashRegisterItemDescription = "4",
			CashRegisterItemDescription2 = "R",
			CouponFamilyCode = "iZu",
			DatedProductNumberOfDays = 1,
			DepositValue = 2,
			YesNoConditionOrResponseCode = "k",
			Color = "y",
			UnitWeight = 3,
			WeightQualifier = "6",
			WeightUnitCode = "0",
			UnitWeight2 = 7,
			WeightQualifier2 = "r",
			WeightUnitCode2 = "a",
			ProductServiceIDQualifier3 = "ge",
			ProductServiceID3 = "z",
			FreeFormDescription = "w",
			InnerPack = 4,
			PackagingCode = "nmt",
		};

		var actual = Map.MapObject<G55_ItemCharacteristicsConsumerUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lk", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceID = "S";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("BR", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("BR", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = "S";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "09", true)]
	[InlineData(0, "09", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = "S";
		if (height > 0)
		subject.Height = height;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "Uy", true)]
	[InlineData(0, "Uy", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = "S";
		if (width > 0)
		subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "v2", true)]
	[InlineData(0, "v2", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = "S";
		if (length > 0)
		subject.Length = length;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "YP", true)]
	[InlineData(0, "YP", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = "S";
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "qh", true)]
	[InlineData(0, "qh", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = "S";
		if (size > 0)
		subject.Size = size;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ge", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("ge", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new G55_ItemCharacteristicsConsumerUnit();
		subject.ProductServiceIDQualifier = "lk";
		subject.ProductServiceID = "S";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
