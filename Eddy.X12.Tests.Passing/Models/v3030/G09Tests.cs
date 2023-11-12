using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G09*1*Ku*lp*aRuVuE7KKPfo*8E*V*6";

		var expected = new G09_ShippedItemDetail()
		{
			QuantityReceived = 1,
			UnitOrBasisForMeasurementCode = "Ku",
			ReceivingConditionCode = "lp",
			UPCCaseCode = "aRuVuE7KKPfo",
			ProductServiceIDQualifier = "8E",
			ProductServiceID = "V",
			NumberOfUnitsShipped = 6,
		};

		var actual = Map.MapObject<G09_ShippedItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.UnitOrBasisForMeasurementCode = "Ku";
		subject.ReceivingConditionCode = "lp";
		if (quantityReceived > 0)
			subject.QuantityReceived = quantityReceived;
			subject.UPCCaseCode = "aRuVuE7KKPfo";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8E";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ku", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 1;
		subject.ReceivingConditionCode = "lp";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "aRuVuE7KKPfo";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8E";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lp", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 1;
		subject.UnitOrBasisForMeasurementCode = "Ku";
		subject.ReceivingConditionCode = receivingConditionCode;
			subject.UPCCaseCode = "aRuVuE7KKPfo";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8E";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("aRuVuE7KKPfo", "8E", true)]
	[InlineData("aRuVuE7KKPfo", "", true)]
	[InlineData("", "8E", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 1;
		subject.UnitOrBasisForMeasurementCode = "Ku";
		subject.ReceivingConditionCode = "lp";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8E";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8E", "V", true)]
	[InlineData("8E", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 1;
		subject.UnitOrBasisForMeasurementCode = "Ku";
		subject.ReceivingConditionCode = "lp";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "aRuVuE7KKPfo";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
