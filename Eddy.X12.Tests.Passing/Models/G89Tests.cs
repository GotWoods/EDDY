using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G89Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G89*6*1*dj*ibwdEA7tdSUs*lE*D*HSENbmCOsDDj*9*2*7*9k*J*mX*ed*4";

		var expected = new G89_LineItemDetailAdjustment()
		{
			DirectStoreDeliverySequenceNumber = 6,
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "dj",
			UPCEANConsumerPackageCode = "ibwdEA7tdSUs",
			ProductServiceIDQualifier = "lE",
			ProductServiceID = "D",
			UPCCaseCode = "HSENbmCOsDDj",
			ItemListCost = 9,
			Pack = 2,
			InnerPack = 7,
			ProductServiceIDQualifier2 = "9k",
			ProductServiceID2 = "J",
			AdjustmentReasonCode = "mX",
			UnitOrBasisForMeasurementCode2 = "ed",
			ItemListCost2 = 4,
		};

		var actual = Map.MapObject<G89_LineItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		if (directStoreDeliverySequenceNumber > 0)
		subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ibwdEA7tdSUs", "D", false)]
	[InlineData("", "D", true)]
	[InlineData("ibwdEA7tdSUs", "", true)]
	public void Validation_OnlyOneOfUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceID, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceID = productServiceID;

        if (productServiceID != "")
            subject.ProductServiceIDQualifier = "AB";


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("lE", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("lE", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HSENbmCOsDDj", "J", false)]
	[InlineData("", "J", true)]
	[InlineData("HSENbmCOsDDj", "", true)]
	public void Validation_OnlyOneOfUPCCaseCode(string uPCCaseCode, string productServiceID2, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceID2 = productServiceID2;

		if (productServiceID2 != "")
			subject.ProductServiceIDQualifier2 = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("9k", "J", true)]
	[InlineData("", "J", false)]
	[InlineData("9k", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("ed", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("ed", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal itemListCost2, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (itemListCost2 > 0)
		subject.ItemListCost2 = itemListCost2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
