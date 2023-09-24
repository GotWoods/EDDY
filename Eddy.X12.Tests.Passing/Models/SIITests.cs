using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class SIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SII*K5*h*2**6*8*1";

		var expected = new SII_SalesItemInformation()
		{
			ProductServiceIDQualifier = "K5",
			ProductServiceID = "h",
			Quantity = 2,
			CompositeUnitOfMeasure = null,
			UnitPrice = 6,
			UnitPrice2 = 8,
			MonetaryAmount = 1,
		};

		var actual = Map.MapObject<SII_SalesItemInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K5", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SII_SalesItemInformation();
		subject.ProductServiceID = "h";
		subject.Quantity = 2;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SII_SalesItemInformation();
		subject.ProductServiceIDQualifier = "K5";
		subject.Quantity = 2;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SII_SalesItemInformation();
		subject.ProductServiceIDQualifier = "K5";
		subject.ProductServiceID = "h";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new SII_SalesItemInformation();
		subject.ProductServiceIDQualifier = "K5";
		subject.ProductServiceID = "h";
		subject.Quantity = 2;
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
