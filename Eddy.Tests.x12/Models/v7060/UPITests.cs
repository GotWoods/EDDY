using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class UPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UPI*A*Sg*q*5B*waV**u*O*fc*6*H*";

		var expected = new UPI_UniversalProductIdentification()
		{
			AssignedIdentification = "A",
			ProductServiceIDQualifier = "Sg",
			ProductServiceID = "q",
			UnitOrBasisForMeasurementCode = "5B",
			DisplayTypeCode = "waV",
			ProductUnitIndicator = null,
			StockIndicatorCode = "u",
			ActionCode = "O",
			ProductionType = "fc",
			Quantity = 6,
			LifeCycleStatusCode = "H",
			SellingOrOrderingProductBasisCode = null,
		};

		var actual = Map.MapObject<UPI_UniversalProductIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sg", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new UPI_UniversalProductIdentification();
		//Required fields
		subject.ProductServiceID = "q";
		subject.UnitOrBasisForMeasurementCode = "5B";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new UPI_UniversalProductIdentification();
		//Required fields
		subject.ProductServiceIDQualifier = "Sg";
		subject.UnitOrBasisForMeasurementCode = "5B";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5B", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new UPI_UniversalProductIdentification();
		//Required fields
		subject.ProductServiceIDQualifier = "Sg";
		subject.ProductServiceID = "q";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
