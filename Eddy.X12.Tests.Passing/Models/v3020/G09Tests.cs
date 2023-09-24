using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G09*5*vK*eA*pevdzpiP9y7M*Lj*2*6";

		var expected = new G09_ShippedItemDetail()
		{
			QuantityReceived = 5,
			UnitOfMeasurementCode = "vK",
			ReceivingConditionCode = "eA",
			UPCCaseCode = "pevdzpiP9y7M",
			ProductServiceIDQualifier = "Lj",
			ProductServiceID = "2",
			NumberOfUnitsShipped = 6,
		};

		var actual = Map.MapObject<G09_ShippedItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.UnitOfMeasurementCode = "vK";
		subject.ReceivingConditionCode = "eA";
		if (quantityReceived > 0)
			subject.QuantityReceived = quantityReceived;
			subject.UPCCaseCode = "pevdzpiP9y7M";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Lj";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vK", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 5;
		subject.ReceivingConditionCode = "eA";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UPCCaseCode = "pevdzpiP9y7M";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Lj";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eA", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 5;
		subject.UnitOfMeasurementCode = "vK";
		subject.ReceivingConditionCode = receivingConditionCode;
			subject.UPCCaseCode = "pevdzpiP9y7M";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Lj";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("pevdzpiP9y7M", "Lj", true)]
	[InlineData("pevdzpiP9y7M", "", true)]
	[InlineData("", "Lj", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 5;
		subject.UnitOfMeasurementCode = "vK";
		subject.ReceivingConditionCode = "eA";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Lj";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lj", "2", true)]
	[InlineData("Lj", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 5;
		subject.UnitOfMeasurementCode = "vK";
		subject.ReceivingConditionCode = "eA";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "pevdzpiP9y7M";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
