using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W23Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W23*fy*8*8*6*FKsaRZE6GACL*Qw*2*Tp*V*7*2*7*5*1*3";

		var expected = new W23_DetailActivityInventory()
		{
			UnitOfMeasurementCode = "fy",
			BeginningBalanceQuantity = 8,
			QuantityAvailable = 8,
			EndingBalanceQuantity = 6,
			UPCCaseCode = "FKsaRZE6GACL",
			ProductServiceIDQualifier = "Qw",
			ProductServiceID = "2",
			ProductServiceIDQualifier2 = "Tp",
			ProductServiceID2 = "V",
			QuantityReceived = 7,
			NumberOfUnitsShipped = 2,
			QuantityDamagedOnHold = 7,
			QuantityCommitted = 5,
			QuantityInTransit = 1,
			QuantityAdjustment = 3,
		};

		var actual = Map.MapObject<W23_DetailActivityInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fy", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 8;
		subject.EndingBalanceQuantity = 6;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "FKsaRZE6GACL";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Qw";
			subject.ProductServiceID = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Tp";
			subject.ProductServiceID2 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "fy";
		subject.QuantityAvailable = 8;
		subject.EndingBalanceQuantity = 6;
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		//At Least one
		subject.UPCCaseCode = "FKsaRZE6GACL";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Qw";
			subject.ProductServiceID = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Tp";
			subject.ProductServiceID2 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "fy";
		subject.BeginningBalanceQuantity = 8;
		subject.EndingBalanceQuantity = 6;
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		//At Least one
		subject.UPCCaseCode = "FKsaRZE6GACL";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Qw";
			subject.ProductServiceID = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Tp";
			subject.ProductServiceID2 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "fy";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 8;
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		//At Least one
		subject.UPCCaseCode = "FKsaRZE6GACL";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Qw";
			subject.ProductServiceID = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Tp";
			subject.ProductServiceID2 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("FKsaRZE6GACL", "Qw", true)]
	[InlineData("FKsaRZE6GACL", "", true)]
	[InlineData("", "Qw", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "fy";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 8;
		subject.EndingBalanceQuantity = 6;
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Qw";
			subject.ProductServiceID = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Tp";
			subject.ProductServiceID2 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qw", "2", true)]
	[InlineData("Qw", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "fy";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 8;
		subject.EndingBalanceQuantity = 6;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "FKsaRZE6GACL";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Tp";
			subject.ProductServiceID2 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Tp", "V", true)]
	[InlineData("Tp", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "fy";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 8;
		subject.EndingBalanceQuantity = 6;
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "FKsaRZE6GACL";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Qw";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
