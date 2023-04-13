using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class UPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UPI*7*md*d*DD*iTZ**1*0*TK*4*h*";

		var expected = new UPI_UniversalProductIdentification()
		{
			AssignedIdentification = "7",
			ProductServiceIDQualifier = "md",
			ProductServiceID = "d",
			UnitOrBasisForMeasurementCode = "DD",
			DisplayTypeCode = "iTZ",
			ProductUnitIndicator = null,
			StockIndicatorCode = "1",
			ActionCode = "0",
			ProductionType = "TK",
			Quantity = 4,
			LifeCycleStatusCode = "h",
			//SellingOrOrderingProductBasisCode = "",
		};

		var actual = Map.MapObject<UPI_UniversalProductIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("md", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new UPI_UniversalProductIdentification();
		subject.ProductServiceID = "d";
		subject.UnitOrBasisForMeasurementCode = "DD";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new UPI_UniversalProductIdentification();
		subject.ProductServiceIDQualifier = "md";
		subject.UnitOrBasisForMeasurementCode = "DD";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DD", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new UPI_UniversalProductIdentification();
		subject.ProductServiceIDQualifier = "md";
		subject.ProductServiceID = "d";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
