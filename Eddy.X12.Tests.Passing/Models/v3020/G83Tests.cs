using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G83Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G83*8*4*WO*tM6B8i3sa3Ch*6l*V*43IJVUtAwon7*7*1*Q";

		var expected = new G83_LineItemDetailDirectStoreDelivery()
		{
			DirectStoreDeliverySequenceNumber = 8,
			Quantity = 4,
			UnitOfMeasurementCode = "WO",
			UPCEANConsumerPackageCode = "tM6B8i3sa3Ch",
			ProductServiceIDQualifier = "6l",
			ProductServiceID = "V",
			UPCCaseCode = "43IJVUtAwon7",
			ItemListCost = 7,
			Pack = 1,
			CashRegisterItemDescription = "Q",
		};

		var actual = Map.MapObject<G83_LineItemDetailDirectStoreDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.Quantity = 4;
		subject.UnitOfMeasurementCode = "WO";
		//Test Parameters
		if (directStoreDeliverySequenceNumber > 0) 
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		//At Least one
		subject.UPCEANConsumerPackageCode = "tM6B8i3sa3Ch";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "6l";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 8;
		subject.UnitOfMeasurementCode = "WO";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.UPCEANConsumerPackageCode = "tM6B8i3sa3Ch";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "6l";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WO", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 8;
		subject.Quantity = 4;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//At Least one
		subject.UPCEANConsumerPackageCode = "tM6B8i3sa3Ch";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "6l";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("tM6B8i3sa3Ch", "6l", true)]
	[InlineData("tM6B8i3sa3Ch", "", true)]
	[InlineData("", "6l", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 8;
		subject.Quantity = 4;
		subject.UnitOfMeasurementCode = "WO";
		//Test Parameters
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "6l";
			subject.ProductServiceID = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6l", "V", true)]
	[InlineData("6l", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 8;
		subject.Quantity = 4;
		subject.UnitOfMeasurementCode = "WO";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCEANConsumerPackageCode = "tM6B8i3sa3Ch";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
