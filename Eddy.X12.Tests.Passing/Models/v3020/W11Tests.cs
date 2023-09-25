using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W11*NL*L*3*lQ*4*jP*3*Uu*6*ky*8*MU*2*6u*8*dj";

		var expected = new W11_WarehouseQuantitiesDetail()
		{
			ReferenceNumberQualifier = "NL",
			ReferenceNumber = "L",
			BeginningBalanceQuantity = 3,
			UnitOfMeasurementCode = "lQ",
			QuantityAvailable = 4,
			UnitOfMeasurementCode2 = "jP",
			EndingBalanceQuantity = 3,
			UnitOfMeasurementCode3 = "Uu",
			QuantityReceived = 6,
			UnitOfMeasurementCode4 = "ky",
			NumberOfUnitsShipped = 8,
			UnitOfMeasurementCode5 = "MU",
			QuantityDamagedOnHold = 2,
			UnitOfMeasurementCode6 = "6u",
			QuantityOrdered = 8,
			UnitOfMeasurementCode7 = "dj",
		};

		var actual = Map.MapObject<W11_WarehouseQuantitiesDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NL", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lQ", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jP", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uu", true)]
	public void Validation_RequiredUnitOfMeasurementCode3(string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		//Test Parameters
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "ky", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "ky", false)]
	public void Validation_AllAreRequiredQuantityReceived(decimal quantityReceived, string unitOfMeasurementCode4, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOfMeasurementCode4 = unitOfMeasurementCode4;
		//If one filled, all required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "MU", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "MU", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOfMeasurementCode5, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOfMeasurementCode5 = unitOfMeasurementCode5;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "6u", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "6u", false)]
	public void Validation_AllAreRequiredQuantityDamagedOnHold(decimal quantityDamagedOnHold, string unitOfMeasurementCode6, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		if (quantityDamagedOnHold > 0) 
			subject.QuantityDamagedOnHold = quantityDamagedOnHold;
		subject.UnitOfMeasurementCode6 = unitOfMeasurementCode6;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOfMeasurementCode7 = "dj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "dj", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "dj", false)]
	public void Validation_AllAreRequiredQuantityOrdered(decimal quantityOrdered, string unitOfMeasurementCode7, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "NL";
		subject.ReferenceNumber = "L";
		subject.BeginningBalanceQuantity = 3;
		subject.UnitOfMeasurementCode = "lQ";
		subject.QuantityAvailable = 4;
		subject.UnitOfMeasurementCode2 = "jP";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "Uu";
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		subject.UnitOfMeasurementCode7 = unitOfMeasurementCode7;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.QuantityReceived = 6;
			subject.UnitOfMeasurementCode4 = "ky";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOfMeasurementCode5 = "MU";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 2;
			subject.UnitOfMeasurementCode6 = "6u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
