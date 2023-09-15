using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G19Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G19*2*Pp*1*dn*D*W1*4cORNPe6ejay*DF*F";

		var expected = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences()
		{
			NumberOfUnitsShipped = 2,
			UnitOfMeasurementCode = "Pp",
			QuantityDifference = 1,
			ShipmentOrderStatusCode = "dn",
			PriceReasonCode = "D",
			TermsExceptionCode = "W1",
			UPCCaseCode = "4cORNPe6ejay",
			ProductServiceIDQualifier = "DF",
			ProductServiceID = "F",
		};

		var actual = Map.MapObject<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Pp", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Pp", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 1;
			subject.ShipmentOrderStatusCode = "dn";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "DF";
			subject.ProductServiceID = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "dn", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "dn", false)]
	public void Validation_AllAreRequiredQuantityDifference(decimal quantityDifference, string shipmentOrderStatusCode, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		if (quantityDifference > 0)
			subject.QuantityDifference = quantityDifference;
		subject.ShipmentOrderStatusCode = shipmentOrderStatusCode;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOfMeasurementCode = "Pp";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "DF";
			subject.ProductServiceID = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DF", "F", true)]
	[InlineData("DF", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOfMeasurementCode = "Pp";
		}
		//If one is filled, all are required
		if(subject.QuantityDifference > 0 || subject.QuantityDifference > 0 || !string.IsNullOrEmpty(subject.ShipmentOrderStatusCode))
		{
			subject.QuantityDifference = 1;
			subject.ShipmentOrderStatusCode = "dn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
