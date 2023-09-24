using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G09*2*RF*8c*9nAk8gCZjZUE*yU*f*8";

		var expected = new G09_ShippedItemDetail()
		{
			QuantityReceived = 2,
			UnitOrBasisForMeasurementCode = "RF",
			ReceivingConditionCode = "8c",
			UPCCaseCode = "9nAk8gCZjZUE",
			ProductServiceIDQualifier = "yU",
			ProductServiceID = "f",
			NumberOfUnitsShipped = 8,
		};

		var actual = Map.MapObject<G09_ShippedItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.UnitOrBasisForMeasurementCode = "RF";
		subject.ReceivingConditionCode = "8c";
		if (quantityReceived > 0)
			subject.QuantityReceived = quantityReceived;
			subject.UPCCaseCode = "9nAk8gCZjZUE";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yU";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RF", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 2;
		subject.ReceivingConditionCode = "8c";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "9nAk8gCZjZUE";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yU";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8c", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 2;
		subject.UnitOrBasisForMeasurementCode = "RF";
		subject.ReceivingConditionCode = receivingConditionCode;
			subject.UPCCaseCode = "9nAk8gCZjZUE";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yU";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9nAk8gCZjZUE", "yU", true)]
	[InlineData("9nAk8gCZjZUE", "", true)]
	[InlineData("", "yU", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 2;
		subject.UnitOrBasisForMeasurementCode = "RF";
		subject.ReceivingConditionCode = "8c";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yU";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yU", "f", true)]
	[InlineData("yU", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 2;
		subject.UnitOrBasisForMeasurementCode = "RF";
		subject.ReceivingConditionCode = "8c";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "9nAk8gCZjZUE";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
