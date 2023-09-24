using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G83Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G83*6*7*6p*ZnH4KRSZivCP*iH*N*opzmhoss7NsJ*5*2*W";

		var expected = new G83_LineItemDetailDirectStoreDelivery()
		{
			DirectStoreDeliverySequenceNumber = 6,
			Quantity = 7,
			UnitOrBasisForMeasurementCode = "6p",
			UPCEANConsumerPackageCode = "ZnH4KRSZivCP",
			ProductServiceIDQualifier = "iH",
			ProductServiceID = "N",
			UPCCaseCode = "opzmhoss7NsJ",
			ItemListCost = 5,
			Pack = 2,
			CashRegisterItemDescription = "W",
		};

		var actual = Map.MapObject<G83_LineItemDetailDirectStoreDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.Quantity = 7;
		subject.UnitOrBasisForMeasurementCode = "6p";
		//Test Parameters
		if (directStoreDeliverySequenceNumber > 0) 
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		//At Least one
		subject.UPCEANConsumerPackageCode = "ZnH4KRSZivCP";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iH";
			subject.ProductServiceID = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.UnitOrBasisForMeasurementCode = "6p";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.UPCEANConsumerPackageCode = "ZnH4KRSZivCP";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iH";
			subject.ProductServiceID = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6p", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 7;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCEANConsumerPackageCode = "ZnH4KRSZivCP";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iH";
			subject.ProductServiceID = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ZnH4KRSZivCP", "iH", true)]
	[InlineData("ZnH4KRSZivCP", "", true)]
	[InlineData("", "iH", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 7;
		subject.UnitOrBasisForMeasurementCode = "6p";
		//Test Parameters
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iH";
			subject.ProductServiceID = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iH", "N", true)]
	[InlineData("iH", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 7;
		subject.UnitOrBasisForMeasurementCode = "6p";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCEANConsumerPackageCode = "ZnH4KRSZivCP";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
