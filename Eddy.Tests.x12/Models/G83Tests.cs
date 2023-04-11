using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G83Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G83*3*5*bh*rN9nh4kcjT0v*hR*W*n6SaMI0X4Nz7*8*3*y*mK*K*4*YD*n*ES*3";

		var expected = new G83_LineItemDetailDirectStoreDelivery()
		{
			DirectStoreDeliverySequenceNumber = 3,
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "bh",
			UPCEANConsumerPackageCode = "rN9nh4kcjT0v",
			ProductServiceIDQualifier = "hR",
			ProductServiceID = "W",
			UPCCaseCode = "n6SaMI0X4Nz7",
			ItemListCost = 8,
			Pack = 3,
			CashRegisterItemDescription = "y",
			ProductServiceIDQualifier2 = "mK",
			ProductServiceID2 = "K",
			InnerPack = 4,
			ProductServiceIDQualifier3 = "YD",
			ProductServiceID3 = "n",
			UnitOrBasisForMeasurementCode2 = "ES",
			ItemListCost2 = 3,
		};

		var actual = Map.MapObject<G83_LineItemDetailDirectStoreDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredDirectStoreDeliverySequenceNumber(int directStoreDeliverySequenceNumber, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
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
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.UnitOrBasisForMeasurementCode = "bh";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bh", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("rN9nh4kcjT0v","hR", true)]
	[InlineData("", "hR", true)]
	[InlineData("rN9nh4kcjT0v", "", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rN9nh4kcjT0v", "W", false)]
	[InlineData("", "W", true)]
	[InlineData("rN9nh4kcjT0v", "", true)]
	public void Validation_OnlyOneOfUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceID, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("hR", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("hR", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 3, true)]
	[InlineData("n6SaMI0X4Nz7", 0, false)]
	public void Validation_ARequiresBUPCCaseCode(string uPCCaseCode, int pack, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.UPCCaseCode = uPCCaseCode;
		if (pack > 0)
		subject.Pack = pack;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n6SaMI0X4Nz7", "K", false)]
	[InlineData("", "K", true)]
	[InlineData("n6SaMI0X4Nz7", "", true)]
	public void Validation_OnlyOneOfUPCCaseCode(string uPCCaseCode, string productServiceID2, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("mK", "K", true)]
	[InlineData("", "K", false)]
	[InlineData("mK", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("YD", "n", true)]
	[InlineData("", "n", false)]
	[InlineData("YD", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("ES", 3, true)]
	[InlineData("", 3, false)]
	[InlineData("ES", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal itemListCost2, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		subject.DirectStoreDeliverySequenceNumber = 3;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "bh";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (itemListCost2 > 0)
		subject.ItemListCost2 = itemListCost2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
