using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G19*4*au*4*Fc*a*yr*n58I91jI2mCO*UA*b";

		var expected = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences()
		{
			NumberOfUnitsShipped = 4,
			UnitOrBasisForMeasurementCode = "au",
			QuantityDifference = 4,
			ShipmentOrderStatusCode = "Fc",
			PriceReasonCode = "a",
			TermsExceptionCode = "yr",
			UPCCaseCode = "n58I91jI2mCO",
			ProductServiceIDQualifier = "UA",
			ProductServiceID = "b",
		};

		var actual = Map.MapObject<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "au", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "au", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 4;
			subject.ShipmentOrderStatusCode = "Fc";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "UA";
			subject.ProductServiceID = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Fc", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Fc", false)]
	public void Validation_AllAreRequiredQuantityDifference(decimal quantityDifference, string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 4;
			subject.UnitOrBasisForMeasurementCode = "au";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "UA";
			subject.ProductServiceID = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UA", "b", true)]
	[InlineData("UA", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 4;
			subject.UnitOrBasisForMeasurementCode = "au";
		}
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 4;
			subject.ShipmentOrderStatusCode = "Fc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
