using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G19*9*fR*8*L0*a*P7*lpZKIIUWietx*ZH*G";

		var expected = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences()
		{
			NumberOfUnitsShipped = 9,
			UnitOrBasisForMeasurementCode = "fR",
			QuantityDifference = 8,
			ShipmentOrderStatusCode = "L0",
			PriceReasonCode = "a",
			TermsExceptionCode = "P7",
			UPCCaseCode = "lpZKIIUWietx",
			ProductServiceIDQualifier = "ZH",
			ProductServiceID = "G",
		};

		var actual = Map.MapObject<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "fR", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "fR", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 8;
			subject.ShipmentOrderStatusCode = "L0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ZH";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "L0", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "L0", false)]
	public void Validation_AllAreRequiredQuantityDifference(decimal quantityDifference, string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode = "fR";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "ZH";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZH", "G", true)]
	[InlineData("ZH", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode = "fR";
		}
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 8;
			subject.ShipmentOrderStatusCode = "L0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
