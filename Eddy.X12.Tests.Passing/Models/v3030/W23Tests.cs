using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W23Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W23*8k*1*9*8*NTpWyZ2dTq2h*Sr*9*vZ*a*4*3*2*6*5*5";

		var expected = new W23_DetailActivityInventory()
		{
			UnitOrBasisForMeasurementCode = "8k",
			BeginningBalanceQuantity = 1,
			QuantityAvailable = 9,
			EndingBalanceQuantity = 8,
			UPCCaseCode = "NTpWyZ2dTq2h",
			ProductServiceIDQualifier = "Sr",
			ProductServiceID = "9",
			ProductServiceIDQualifier2 = "vZ",
			ProductServiceID2 = "a",
			QuantityReceived = 4,
			NumberOfUnitsShipped = 3,
			QuantityDamagedOnHold = 2,
			QuantityCommitted = 6,
			QuantityInTransit = 5,
			QuantityAdjustment = 5,
		};

		var actual = Map.MapObject<W23_DetailActivityInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8k", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.BeginningBalanceQuantity = 1;
		subject.QuantityAvailable = 9;
		subject.EndingBalanceQuantity = 8;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "NTpWyZ2dTq2h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Sr";
			subject.ProductServiceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "vZ";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "8k";
		subject.QuantityAvailable = 9;
		subject.EndingBalanceQuantity = 8;
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		//At Least one
		subject.UPCCaseCode = "NTpWyZ2dTq2h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Sr";
			subject.ProductServiceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "vZ";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "8k";
		subject.BeginningBalanceQuantity = 1;
		subject.EndingBalanceQuantity = 8;
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		//At Least one
		subject.UPCCaseCode = "NTpWyZ2dTq2h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Sr";
			subject.ProductServiceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "vZ";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "8k";
		subject.BeginningBalanceQuantity = 1;
		subject.QuantityAvailable = 9;
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		//At Least one
		subject.UPCCaseCode = "NTpWyZ2dTq2h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Sr";
			subject.ProductServiceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "vZ";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("NTpWyZ2dTq2h", "Sr", true)]
	[InlineData("NTpWyZ2dTq2h", "", true)]
	[InlineData("", "Sr", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "8k";
		subject.BeginningBalanceQuantity = 1;
		subject.QuantityAvailable = 9;
		subject.EndingBalanceQuantity = 8;
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Sr";
			subject.ProductServiceID = "9";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "vZ";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sr", "9", true)]
	[InlineData("Sr", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "8k";
		subject.BeginningBalanceQuantity = 1;
		subject.QuantityAvailable = 9;
		subject.EndingBalanceQuantity = 8;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "NTpWyZ2dTq2h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "vZ";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vZ", "a", true)]
	[InlineData("vZ", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "8k";
		subject.BeginningBalanceQuantity = 1;
		subject.QuantityAvailable = 9;
		subject.EndingBalanceQuantity = 8;
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "NTpWyZ2dTq2h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Sr";
			subject.ProductServiceID = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
