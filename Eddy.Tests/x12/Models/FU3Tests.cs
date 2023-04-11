using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FU3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU3*2*Hv*Y*wc*g*J*V*U*J*3*VG*2*nb*9*uD*5*vb*3";

		var expected = new FU3_ProductDetail()
		{
			ProductName = "2",
			UnitOrBasisForMeasurementCode = "Hv",
			BrandName = "Y",
			EntityIdentifierCode = "wc",
			Name = "g",
			ProductLabel = "J",
			Description = "V",
			WeightQualifier = "U",
			WeightUnitCode = "J",
			UnitWeight = 3,
			UnitOrBasisForMeasurementCode2 = "VG",
			Height = 2,
			UnitOrBasisForMeasurementCode3 = "nb",
			Width = 9,
			UnitOrBasisForMeasurementCode4 = "uD",
			ItemDepth = 5,
			UnitOrBasisForMeasurementCode5 = "vb",
			Volume = 3,
		};

		var actual = Map.MapObject<FU3_ProductDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredProductName(string productName, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		subject.ProductName = productName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wc", "g", true)]
	[InlineData("", "g", false)]
	[InlineData("wc", "", false)]
	public void Validation_AllAreRequiredEntityIdentifierCode(string entityIdentifierCode, string name, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		subject.ProductName = "2";
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.Name = name;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("VG", 2, true)]
	[InlineData("", 2, false)]
	[InlineData("VG", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		subject.ProductName = "2";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (height > 0)
		subject.Height = height;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("nb", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("nb", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal width, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		subject.ProductName = "2";
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (width > 0)
		subject.Width = width;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("uD", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("uD", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal itemDepth, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		subject.ProductName = "2";
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (itemDepth > 0)
		subject.ItemDepth = itemDepth;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("vb", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("vb", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal volume, bool isValidExpected)
	{
		var subject = new FU3_ProductDetail();
		subject.ProductName = "2";
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (volume > 0)
		subject.Volume = volume;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
