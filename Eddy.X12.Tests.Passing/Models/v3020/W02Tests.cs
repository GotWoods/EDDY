using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W02*4*22*YtXhbrbSSKzs*sH*u*E*1*9*D*2*h*c*6*1*9*8*1*2*7";

		var expected = new W02_ItemSummaryInventory()
		{
			QuantityOnHand = 4,
			UnitOfMeasurementCode = "22",
			UPCCaseCode = "YtXhbrbSSKzs",
			ProductServiceIDQualifier = "sH",
			ProductServiceID = "u",
			WarehouseLotNumber = "E",
			Weight = 1,
			WeightQualifier = "9",
			WeightUnitQualifier = "D",
			Weight2 = 2,
			WeightQualifier2 = "h",
			WeightUnitQualifier2 = "c",
			QuantityCommitted = 6,
			QuantityAvailable = 1,
			QuantityInTransit = 9,
			QuantityDamaged = 8,
			QuantityOnHold = 1,
			QuantityBackordered = 2,
			QuantityDeferred = 7,
		};

		var actual = Map.MapObject<W02_ItemSummaryInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityOnHand(decimal quantityOnHand, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "22";
		//Test Parameters
		if (quantityOnHand > 0) 
			subject.QuantityOnHand = quantityOnHand;
		//At Least one
		subject.UPCCaseCode = "YtXhbrbSSKzs";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sH";
			subject.ProductServiceID = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("22", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.QuantityOnHand = 4;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "YtXhbrbSSKzs";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sH";
			subject.ProductServiceID = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("YtXhbrbSSKzs", "sH", true)]
	[InlineData("YtXhbrbSSKzs", "", true)]
	[InlineData("", "sH", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.QuantityOnHand = 4;
		subject.UnitOfMeasurementCode = "22";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sH";
			subject.ProductServiceID = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sH", "u", true)]
	[InlineData("sH", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.QuantityOnHand = 4;
		subject.UnitOfMeasurementCode = "22";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "YtXhbrbSSKzs";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
