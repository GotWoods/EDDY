using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class G19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G19*7*pB*6*5J*1*Xt*4M3NhZzi5Rc4*KU*H";

		var expected = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences()
		{
			NumberOfUnitsShipped = 7,
			UnitOrBasisForMeasurementCode = "pB",
			QuantityDifference = 6,
			ShipmentOrderStatusCode = "5J",
			PriceReasonCode = "1",
			TermsExceptionCode = "Xt",
			UPCCaseCode = "4M3NhZzi5Rc4",
			ProductServiceIDQualifier = "KU",
			ProductServiceID = "H",
		};

		var actual = Map.MapObject<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "pB", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "pB", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 6;
			subject.ShipmentOrderStatusCode = "5J";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "KU";
			subject.ProductServiceID = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "5J", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "5J", false)]
	public void Validation_AllAreRequiredQuantityDifference(decimal quantityDifference, string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "pB";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "KU";
			subject.ProductServiceID = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KU", "H", true)]
	[InlineData("KU", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode = "pB";
		}
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 6;
			subject.ShipmentOrderStatusCode = "5J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
