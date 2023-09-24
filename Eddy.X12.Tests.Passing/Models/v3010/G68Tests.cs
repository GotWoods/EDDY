using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G68Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G68*6*yo*2*IezWpt25SJN5*ud*m*jI*g*M*h*YO*f*E*o*4";

		var expected = new G68_LineItemDetailProduct()
		{
			QuantityOrdered = 6,
			UnitOfMeasurementCode = "yo",
			ItemListCost = 2,
			UPCCaseCode = "IezWpt25SJN5",
			ProductServiceIDQualifier = "ud",
			ProductServiceID = "m",
			ProductServiceIDQualifier2 = "jI",
			ProductServiceID2 = "g",
			PriceBracketIdentifier = "M",
			QuantityCost = "h",
			UnitOfMeasurementCode2 = "YO",
			PriceListNumber = "f",
			PriceListIssueNumber = "E",
			PrePriceQuantityDesignator = "o",
			RetailPrePrice = 4,
		};

		var actual = Map.MapObject<G68_LineItemDetailProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.UnitOfMeasurementCode = "yo";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yo", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 6;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
