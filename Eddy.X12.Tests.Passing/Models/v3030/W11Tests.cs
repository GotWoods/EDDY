using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W11*fm*K*4*em*6*SL*2*2o*5*kV*2*cI*8*fX*8*uY";

		var expected = new W11_WarehouseQuantitiesDetail()
		{
			ReferenceNumberQualifier = "fm",
			ReferenceNumber = "K",
			BeginningBalanceQuantity = 4,
			UnitOrBasisForMeasurementCode = "em",
			QuantityAvailable = 6,
			UnitOrBasisForMeasurementCode2 = "SL",
			EndingBalanceQuantity = 2,
			UnitOrBasisForMeasurementCode3 = "2o",
			QuantityReceived = 5,
			UnitOrBasisForMeasurementCode4 = "kV",
			NumberOfUnitsShipped = 2,
			UnitOrBasisForMeasurementCode5 = "cI",
			QuantityDamagedOnHold = 8,
			UnitOrBasisForMeasurementCode6 = "fX",
			QuantityOrdered = 8,
			UnitOrBasisForMeasurementCode7 = "uY",
		};

		var actual = Map.MapObject<W11_WarehouseQuantitiesDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fm", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("em", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SL", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2o", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "kV", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "kV", false)]
	public void Validation_AllAreRequiredQuantityReceived(decimal quantityReceived, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "cI", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "cI", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		if (numberOfUnitsShipped > 0) 
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "fX", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "fX", false)]
	public void Validation_AllAreRequiredQuantityDamagedOnHold(decimal quantityDamagedOnHold, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		if (quantityDamagedOnHold > 0) 
			subject.QuantityDamagedOnHold = quantityDamagedOnHold;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityOrdered > 0 || subject.QuantityOrdered > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode7))
		{
			subject.QuantityOrdered = 8;
			subject.UnitOrBasisForMeasurementCode7 = "uY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "uY", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "uY", false)]
	public void Validation_AllAreRequiredQuantityOrdered(decimal quantityOrdered, string unitOrBasisForMeasurementCode7, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "fm";
		subject.ReferenceNumber = "K";
		subject.BeginningBalanceQuantity = 4;
		subject.UnitOrBasisForMeasurementCode = "em";
		subject.QuantityAvailable = 6;
		subject.UnitOrBasisForMeasurementCode2 = "SL";
		subject.EndingBalanceQuantity = 2;
		subject.UnitOrBasisForMeasurementCode3 = "2o";
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		subject.UnitOrBasisForMeasurementCode7 = unitOrBasisForMeasurementCode7;
		//If one filled, all required
		if(subject.QuantityReceived > 0 || subject.QuantityReceived > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.QuantityReceived = 5;
			subject.UnitOrBasisForMeasurementCode4 = "kV";
		}
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.NumberOfUnitsShipped = 2;
			subject.UnitOrBasisForMeasurementCode5 = "cI";
		}
		if(subject.QuantityDamagedOnHold > 0 || subject.QuantityDamagedOnHold > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.QuantityDamagedOnHold = 8;
			subject.UnitOrBasisForMeasurementCode6 = "fX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
