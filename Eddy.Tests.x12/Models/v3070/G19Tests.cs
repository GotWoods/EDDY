using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G19*3*nA*5*3f*E*lr*mj1IWTkkRrjh*V5*H";

		var expected = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences()
		{
			NumberOfUnitsShipped = 3,
			UnitOrBasisForMeasurementCode = "nA",
			QuantityDifference = 5,
			ShipmentOrderStatusCode = "3f",
			PriceReasonCode = "E",
			TermsExceptionCode = "lr",
			UPCCaseCode = "mj1IWTkkRrjh",
			ProductServiceIDQualifier = "V5",
			ProductServiceID = "H",
		};

		var actual = Map.MapObject<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "nA", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "nA", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 5;
			subject.ShipmentOrderStatusCode = "3f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "V5";
			subject.ProductServiceID = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "3f", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "3f", false)]
	public void Validation_AllAreRequiredQuantityDifference(decimal quantityDifference, string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode = "nA";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "V5";
			subject.ProductServiceID = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V5", "H", true)]
	[InlineData("V5", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode = "nA";
		}
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 5;
			subject.ShipmentOrderStatusCode = "3f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
