using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W02*8*q5*IUmah81mRYWK*rv*g*d*7*j*k*2*W*j*1*5*5*7*9*4*1";

		var expected = new W02_ItemSummaryInventory()
		{
			QuantityOnHand = 8,
			UnitOrBasisForMeasurementCode = "q5",
			UPCCaseCode = "IUmah81mRYWK",
			ProductServiceIDQualifier = "rv",
			ProductServiceID = "g",
			WarehouseLotNumber = "d",
			Weight = 7,
			WeightQualifier = "j",
			WeightUnitCode = "k",
			Weight2 = 2,
			WeightQualifier2 = "W",
			WeightUnitCode2 = "j",
			QuantityCommitted = 1,
			QuantityAvailable = 5,
			QuantityInTransit = 5,
			QuantityDamaged = 7,
			QuantityOnHold = 9,
			QuantityBackordered = 4,
			QuantityDeferred = 1,
		};

		var actual = Map.MapObject<W02_ItemSummaryInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantityOnHand(decimal quantityOnHand, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "q5";
		//Test Parameters
		if (quantityOnHand > 0) 
			subject.QuantityOnHand = quantityOnHand;
		//At Least one
		subject.UPCCaseCode = "IUmah81mRYWK";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rv";
			subject.ProductServiceID = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q5", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.QuantityOnHand = 8;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "IUmah81mRYWK";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rv";
			subject.ProductServiceID = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("IUmah81mRYWK", "rv", true)]
	[InlineData("IUmah81mRYWK", "", true)]
	[InlineData("", "rv", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.QuantityOnHand = 8;
		subject.UnitOrBasisForMeasurementCode = "q5";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rv";
			subject.ProductServiceID = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rv", "g", true)]
	[InlineData("rv", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.QuantityOnHand = 8;
		subject.UnitOrBasisForMeasurementCode = "q5";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "IUmah81mRYWK";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
