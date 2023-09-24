using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class POCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POC*m*h2*3***1*q5*3y*D*d2*B*wK*x*w7*7*PJ*t*I9*7*er*W*FK*z*84*u*2R*c";

		var expected = new POC_LineItemChange()
		{
			AssignedIdentification = "m",
			ChangeOrResponseTypeCode = "h2",
			Quantity = 3,
			ChangeQuantities = null,
			CompositeUnitOfMeasure = null,
			UnitPrice = 1,
			BasisOfUnitPriceCode = "q5",
			ProductServiceIDQualifier = "3y",
			ProductServiceID = "D",
			ProductServiceIDQualifier2 = "d2",
			ProductServiceID2 = "B",
			ProductServiceIDQualifier3 = "wK",
			ProductServiceID3 = "x",
			ProductServiceIDQualifier4 = "w7",
			ProductServiceID4 = "7",
			ProductServiceIDQualifier5 = "PJ",
			ProductServiceID5 = "t",
			ProductServiceIDQualifier6 = "I9",
			ProductServiceID6 = "7",
			ProductServiceIDQualifier7 = "er",
			ProductServiceID7 = "W",
			ProductServiceIDQualifier8 = "FK",
			ProductServiceID8 = "z",
			ProductServiceIDQualifier9 = "84",
			ProductServiceID9 = "u",
			ProductServiceIDQualifier10 = "2R",
			ProductServiceID10 = "c",
		};

		var actual = Map.MapObject<POC_LineItemChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h2", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "AA", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBQuantity(decimal quantity, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		if (quantity > 0)
		subject.Quantity = quantity;
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 1, true)]
	[InlineData("q5", 0, false)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0)
		subject.UnitPrice = unitPrice;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3y", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("3y", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("d2", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("d2", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wK", "x", true)]
	[InlineData("", "x", false)]
	[InlineData("wK", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("w7", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("w7", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("PJ", "t", true)]
	[InlineData("", "t", false)]
	[InlineData("PJ", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("I9", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("I9", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("er", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("er", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("FK", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("FK", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("84", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("84", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("2R", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("2R", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		subject.ChangeOrResponseTypeCode = "h2";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
