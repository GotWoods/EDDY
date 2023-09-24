using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G17*7*PV*1*ysPZFZkCTcrL*bl*6*uO*r*0*6*tp*z*2";

		var expected = new G17_ItemDetailInvoice()
		{
			QuantityInvoiced = 7,
			UnitOfMeasurementCode = "PV",
			ItemListCost = 1,
			UPCCaseCode = "ysPZFZkCTcrL",
			ProductServiceIDQualifier = "bl",
			ProductServiceID = "6",
			ProductServiceIDQualifier2 = "uO",
			ProductServiceID2 = "r",
			PriceBracketIdentifier = "0",
			NumberOfUnitsShipped = 6,
			UnitOfMeasurementCode2 = "tp",
			PriceListNumber = "z",
			PriceListIssueNumber = "2",
		};

		var actual = Map.MapObject<G17_ItemDetailInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.UnitOfMeasurementCode = "PV";
		subject.ItemListCost = 1;
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PV", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.ItemListCost = 1;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredItemListCost(decimal itemListCost, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.UnitOfMeasurementCode = "PV";
		if (itemListCost > 0)
			subject.ItemListCost = itemListCost;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
