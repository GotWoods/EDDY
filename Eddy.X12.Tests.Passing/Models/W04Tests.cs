using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W04*8*Cd*MCWmZNg5qqh6*PU*w*kT*l*bh*2*K*a*814788*NN*Br*w";

		var expected = new W04_ItemDetailTotal()
		{
			NumberOfUnitsShipped = 8,
			UnitOrBasisForMeasurementCode = "Cd",
			UPCCaseCode = "MCWmZNg5qqh6",
			ProductServiceIDQualifier = "PU",
			ProductServiceID = "w",
			ProductServiceIDQualifier2 = "kT",
			ProductServiceID2 = "l",
			FreightClassCode = "bh",
			RateClassCode = "2",
			CommodityCodeQualifier = "K",
			CommodityCode = "a",
			PalletBlockAndTiers = 814788,
			InboundConditionHoldCode = "NN",
			ProductServiceIDQualifier3 = "Br",
			ProductServiceID3 = "w",
		};

		var actual = Map.MapObject<W04_ItemDetailTotal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		subject.UnitOrBasisForMeasurementCode = "Cd";
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cd", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("MCWmZNg5qqh6","PU", true)]
	[InlineData("", "PU", true)]
	[InlineData("MCWmZNg5qqh6", "", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "Cd";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("PU", "w", true)]
	[InlineData("", "w", false)]
	[InlineData("PU", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "Cd";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("kT", "l", true)]
	[InlineData("", "l", false)]
	[InlineData("kT", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "Cd";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("K", "a", true)]
	[InlineData("", "a", false)]
	[InlineData("K", "", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "Cd";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Br", "w", true)]
	[InlineData("", "w", false)]
	[InlineData("Br", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W04_ItemDetailTotal();
		subject.NumberOfUnitsShipped = 8;
		subject.UnitOrBasisForMeasurementCode = "Cd";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
