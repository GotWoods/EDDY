using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G83Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G83*1*5*V3*4V7G1kClbU87*8f*e*py1nV668RoGE*5*5*R";

		var expected = new G83_LineItemDetailDirectStoreDelivery()
		{
			DirectStoreDeliverySequenceNumber = 1,
			Quantity = 5,
			UnitOfMeasurementCode = "V3",
			UPCConsumerPackageCode = "4V7G1kClbU87",
			ProductServiceIDQualifier = "8f",
			ProductServiceID = "e",
			UPCCaseCode = "py1nV668RoGE",
			ItemListCost = 5,
			Pack = 5,
			CashRegisterItemDescription = "R",
		};

		var actual = Map.MapObject<G83_LineItemDetailDirectStoreDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOfMeasurementCode = "V3";
		//Test Parameters
		if (directStoreDeliverySequenceNumber > 0) 
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 1;
		subject.UnitOfMeasurementCode = "V3";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V3", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 1;
		subject.Quantity = 5;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
