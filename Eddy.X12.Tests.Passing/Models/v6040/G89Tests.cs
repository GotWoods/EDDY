using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.Tests.Models.v6040;

public class G89Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G89*7*2*vF*nc19YUGzpcsj*M4*6*nhp0L3AwNKEA*2*6*4*ap*p*bT*Tz*8";

		var expected = new G89_LineItemDetailAdjustment()
		{
			DirectStoreDeliverySequenceNumber = 7,
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "vF",
			UPCEANConsumerPackageCode = "nc19YUGzpcsj",
			ProductServiceIDQualifier = "M4",
			ProductServiceID = "6",
			UPCCaseCode = "nhp0L3AwNKEA",
			ItemListCost = 2,
			Pack = 6,
			InnerPack = 4,
			ProductServiceIDQualifier2 = "ap",
			ProductServiceID2 = "p",
			AdjustmentReasonCode = "bT",
			UnitOrBasisForMeasurementCode2 = "Tz",
			ItemListCost2 = 8,
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
			subject.ProductServiceIDQualifier = "M4";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ap";
			subject.ProductServiceID2 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.ItemListCost2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Tz";
			subject.ItemListCost2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nc19YUGzpcsj", "6", false)]
	[InlineData("nc19YUGzpcsj", "", true)]
	[InlineData("", "6", true)]
	public void Validation_OnlyOneOfUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceID, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 7;
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "M4";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ap";
			subject.ProductServiceID2 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.ItemListCost2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Tz";
			subject.ItemListCost2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M4", "6", true)]
	[InlineData("M4", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 7;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ap";
			subject.ProductServiceID2 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.ItemListCost2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Tz";
			subject.ItemListCost2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nhp0L3AwNKEA", "p", false)]
	[InlineData("nhp0L3AwNKEA", "", true)]
	[InlineData("", "p", true)]
	public void Validation_OnlyOneOfUPCCaseCode(string uPCCaseCode, string productServiceID2, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 7;
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "M4";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ap";
			subject.ProductServiceID2 = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.ItemListCost2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Tz";
			subject.ItemListCost2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ap", "p", true)]
	[InlineData("ap", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 7;
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "M4";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.ItemListCost2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Tz";
			subject.ItemListCost2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Tz", 8, true)]
	[InlineData("Tz", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal itemListCost2, bool isValidExpected)
	{
		var subject = new G89_LineItemDetailAdjustment();
		subject.DirectStoreDeliverySequenceNumber = 7;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (itemListCost2 > 0)
			subject.ItemListCost2 = itemListCost2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "M4";
			subject.ProductServiceID = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "ap";
			subject.ProductServiceID2 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
