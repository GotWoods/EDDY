using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class G89Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G89*7*6*qT*8aT7d8apJoMj*qi*X*Vp9pAOadz58v*4*9*9*8V*G";

		var expected = new G89_LineItemDetailAdjustment()
		{
			DirectStoreDeliverySequenceNumber = 7,
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "qT",
			UPCEANConsumerPackageCode = "8aT7d8apJoMj",
			ProductServiceIDQualifier = "qi",
			ProductServiceID = "X",
			UPCCaseCode = "Vp9pAOadz58v",
			ItemListCost = 4,
			Pack = 9,
			InnerPack = 9,
			ProductServiceIDQualifier2 = "8V",
			ProductServiceID2 = "G",
		};

		var actual = Map.MapObject<G89_LineItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		if (directStoreDeliverySequenceNumber > 0)
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "qi";
			subject.ProductServiceID = "X";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "8V";
			subject.ProductServiceID2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qi", "X", true)]
	[InlineData("qi", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 7;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "8V";
			subject.ProductServiceID2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8V", "G", true)]
	[InlineData("8V", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 7;
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "qi";
			subject.ProductServiceID = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
