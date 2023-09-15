using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G09*5*Lq*qj*rxp8kvAIGYkB*zc*Y*7";

		var expected = new G09_ShippedItemDetail()
		{
			QuantityReceived = 5,
			UnitOfMeasurementCode = "Lq",
			ReceivingConditionCode = "qj",
			UPCCaseCode = "rxp8kvAIGYkB",
			ProductServiceIDQualifier = "zc",
			ProductServiceID = "Y",
			NumberOfUnitsShipped = 7,
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
		subject.UnitOfMeasurementCode = "Lq";
		subject.ReceivingConditionCode = "qj";
		if (quantityReceived > 0)
			subject.QuantityReceived = quantityReceived;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lq", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 5;
		subject.ReceivingConditionCode = "qj";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qj", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new G09_ShippedItemDetail();
		subject.QuantityReceived = 5;
		subject.UnitOfMeasurementCode = "Lq";
		subject.ReceivingConditionCode = receivingConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
