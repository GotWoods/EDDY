using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class G83Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G83*2*2*sb*Pz4cymat8Qza*yG*x*dZHeY48djYbN*6*2*w*oD*2*4*J8*w";

		var expected = new G83_LineItemDetailDirectStoreDelivery()
		{
			DirectStoreDeliverySequenceNumber = 2,
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "sb",
			UPCEANConsumerPackageCode = "Pz4cymat8Qza",
			ProductServiceIDQualifier = "yG",
			ProductServiceID = "x",
			UPCCaseCode = "dZHeY48djYbN",
			ItemListCost = 6,
			Pack = 2,
			CashRegisterItemDescription = "w",
			ProductServiceIDQualifier2 = "oD",
			ProductServiceID2 = "2",
			InnerPack = 4,
			ProductServiceIDQualifier3 = "J8",
			ProductServiceID3 = "w",
		};

		var actual = Map.MapObject<G83_LineItemDetailDirectStoreDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "sb";
		//Test Parameters
		if (directStoreDeliverySequenceNumber > 0) 
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		//At Least one
		subject.UPCEANConsumerPackageCode = "Pz4cymat8Qza";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yG";
			subject.ProductServiceID = "x";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "oD";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "J8";
			subject.ProductServiceID3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 2;
		subject.UnitOrBasisForMeasurementCode = "sb";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.UPCEANConsumerPackageCode = "Pz4cymat8Qza";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yG";
			subject.ProductServiceID = "x";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "oD";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "J8";
			subject.ProductServiceID3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sb", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 2;
		subject.Quantity = 2;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCEANConsumerPackageCode = "Pz4cymat8Qza";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yG";
			subject.ProductServiceID = "x";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "oD";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "J8";
			subject.ProductServiceID3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Pz4cymat8Qza", "yG", true)]
	[InlineData("Pz4cymat8Qza", "", true)]
	[InlineData("", "yG", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 2;
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "sb";
		//Test Parameters
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yG";
			subject.ProductServiceID = "x";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "oD";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "J8";
			subject.ProductServiceID3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yG", "x", true)]
	[InlineData("yG", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 2;
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "sb";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCEANConsumerPackageCode = "Pz4cymat8Qza";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "oD";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "J8";
			subject.ProductServiceID3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("dZHeY48djYbN", 2, true)]
	[InlineData("dZHeY48djYbN", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBUPCCaseCode(string uPCCaseCode, int pack, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 2;
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "sb";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		if (pack > 0) 
			subject.Pack = pack;
		//At Least one
		subject.UPCEANConsumerPackageCode = "Pz4cymat8Qza";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yG";
			subject.ProductServiceID = "x";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "oD";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "J8";
			subject.ProductServiceID3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oD", "2", true)]
	[InlineData("oD", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 2;
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "sb";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCEANConsumerPackageCode = "Pz4cymat8Qza";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yG";
			subject.ProductServiceID = "x";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "J8";
			subject.ProductServiceID3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J8", "w", true)]
	[InlineData("J8", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 2;
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = "sb";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//At Least one
		subject.UPCEANConsumerPackageCode = "Pz4cymat8Qza";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "yG";
			subject.ProductServiceID = "x";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "oD";
			subject.ProductServiceID2 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
