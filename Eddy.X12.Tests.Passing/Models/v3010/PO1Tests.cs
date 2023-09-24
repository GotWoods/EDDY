using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PO1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO1*b*3*VC*1*pR*gg*7*yC*1*pl*N*Ej*H*UJ*S*B0*s*gm*m*Nk*m*da*Q*wx*s";

		var expected = new PO1_PurchaseOrderBaselineItemData()
		{
			AssignedIdentification = "b",
			QuantityOrdered = 3,
			UnitOfMeasurementCode = "VC",
			UnitPrice = 1,
			BasisOfUnitPriceCode = "pR",
			ProductServiceIDQualifier = "gg",
			ProductServiceID = "7",
			ProductServiceIDQualifier2 = "yC",
			ProductServiceID2 = "1",
			ProductServiceIDQualifier3 = "pl",
			ProductServiceID3 = "N",
			ProductServiceIDQualifier4 = "Ej",
			ProductServiceID4 = "H",
			ProductServiceIDQualifier5 = "UJ",
			ProductServiceID5 = "S",
			ProductServiceIDQualifier6 = "B0",
			ProductServiceID6 = "s",
			ProductServiceIDQualifier7 = "gm",
			ProductServiceID7 = "m",
			ProductServiceIDQualifier8 = "Nk",
			ProductServiceID8 = "m",
			ProductServiceIDQualifier9 = "da",
			ProductServiceID9 = "Q",
			ProductServiceIDQualifier10 = "wx",
			ProductServiceID10 = "s",
		};

		var actual = Map.MapObject<PO1_PurchaseOrderBaselineItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.UnitOfMeasurementCode = "VC";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VC", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new PO1_PurchaseOrderBaselineItemData();
		subject.QuantityOrdered = 3;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
