using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G83Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G83*6*5*hH*gtst7hIUICL0*X1*G*I5YC2EQv7aqH*9*4*W*r2*R";

		var expected = new G83_LineItemDetailDirectStoreDelivery()
		{
			DirectStoreDeliverySequenceNumber = 6,
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "hH",
			UPCEANConsumerPackageCode = "gtst7hIUICL0",
			ProductServiceIDQualifier = "X1",
			ProductServiceID = "G",
			UPCCaseCode = "I5YC2EQv7aqH",
			ItemListCost = 9,
			Pack = 4,
			CashRegisterItemDescription = "W",
			ProductServiceIDQualifier2 = "r2",
			ProductServiceID2 = "R",
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
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "hH";
		//Test Parameters
		if (directStoreDeliverySequenceNumber > 0) 
			subject.DirectStoreDeliverySequenceNumber = directStoreDeliverySequenceNumber;
		//At Least one
		subject.UPCEANConsumerPackageCode = "gtst7hIUICL0";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "X1";
			subject.ProductServiceID = "G";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "r2";
			subject.ProductServiceID2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.UnitOrBasisForMeasurementCode = "hH";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.UPCEANConsumerPackageCode = "gtst7hIUICL0";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "X1";
			subject.ProductServiceID = "G";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "r2";
			subject.ProductServiceID2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hH", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCEANConsumerPackageCode = "gtst7hIUICL0";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "X1";
			subject.ProductServiceID = "G";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "r2";
			subject.ProductServiceID2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("gtst7hIUICL0", "X1", true)]
	[InlineData("gtst7hIUICL0", "", true)]
	[InlineData("", "X1", true)]
	public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "hH";
		//Test Parameters
		subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "X1";
			subject.ProductServiceID = "G";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "r2";
			subject.ProductServiceID2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X1", "G", true)]
	[InlineData("X1", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "hH";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCEANConsumerPackageCode = "gtst7hIUICL0";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "r2";
			subject.ProductServiceID2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("I5YC2EQv7aqH", 4, true)]
	[InlineData("I5YC2EQv7aqH", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBUPCCaseCode(string uPCCaseCode, int pack, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "hH";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		if (pack > 0) 
			subject.Pack = pack;
		//At Least one
		subject.UPCEANConsumerPackageCode = "gtst7hIUICL0";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "X1";
			subject.ProductServiceID = "G";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "r2";
			subject.ProductServiceID2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r2", "R", true)]
	[InlineData("r2", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G83_LineItemDetailDirectStoreDelivery();
		//Required fields
		subject.DirectStoreDeliverySequenceNumber = 6;
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "hH";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCEANConsumerPackageCode = "gtst7hIUICL0";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "X1";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
