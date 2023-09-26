using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSC*fw*uN*Xr*m*FL*G*2j*6*8lX*umAd3R*A1Qcc0*Zo*8*4*7*s*4*pa*a*By*fo*W*1*Q*X";

		var expected = new PSC_ProductServiceContract()
		{
			ContractStatusCode = "fw",
			TypeOfProductServiceCode = "uN",
			TypeOfProductServiceCode2 = "Xr",
			ReferenceNumber = "m",
			EntityIdentifierCode = "FL",
			ContractNumber = "G",
			UnitOrBasisForMeasurementCode = "2j",
			Count = 6,
			DateTimeQualifier = "8lX",
			Date = "umAd3R",
			Date2 = "A1Qcc0",
			UnitOrBasisForMeasurementCode2 = "Zo",
			RangeMaximum = 8,
			RangeMinimum = 4,
			MeasurementValue = 7,
			ActionCode = "s",
			Percent = 4,
			AgencyQualifierCode = "pa",
			SourceSubqualifier = "a",
			OperationEnvironmentCode = "By",
			SpecialServicesCode = "fo",
			Description = "W",
			UnitPrice = 1,
			YesNoConditionOrResponseCode = "Q",
			ContactMethodCode = "X",
		};

		var actual = Map.MapObject<PSC_ProductServiceContract>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fw", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		subject.ContractStatusCode = contractStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
			subject.RangeMaximum = 8;
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uN", true)]
	public void Validation_RequiredTypeOfProductServiceCode(string typeOfProductServiceCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		//Test Parameters
		subject.TypeOfProductServiceCode = typeOfProductServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
			subject.RangeMaximum = 8;
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2j", 6, true)]
	[InlineData("2j", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, int count, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (count > 0) 
			subject.Count = count;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
			subject.RangeMaximum = 8;
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("Zo", 8, 4, 7, true)]
	[InlineData("Zo", 0, 0, 0, false)]
	[InlineData("", 8, 4, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal rangeMaximum, decimal rangeMinimum, decimal measurementValue, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//A Requires B
		if (rangeMaximum > 0)
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
		if (rangeMinimum > 0)
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
		if (measurementValue > 0)
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Zo", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Zo", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Zo", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Zo", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.MeasurementValue > 0)
		{
			subject.RangeMaximum = 8;
			subject.MeasurementValue = 7;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Zo", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Zo", true)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.RangeMinimum > 0)
		{
			subject.RangeMaximum = 8;
			subject.RangeMinimum = 4;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("s", 8, true)]
	[InlineData("s", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBActionCode(string actionCode, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//A Requires B
		if (rangeMaximum > 0)
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}

        if (subject.ActionCode != "")
        {
            subject.Count = 1;
            subject.UnitOrBasisForMeasurementCode = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, "", true)]
	[InlineData("s", 6, "umAd3R", true)]
	[InlineData("s", 0, "", false)]
	[InlineData("", 6, "umAd3R", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ActionCode(string actionCode, int count, string date, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (count > 0) 
			subject.Count = count;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
			subject.RangeMaximum = 8;
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}


        if (subject.ActionCode != "")
        {
            subject.RangeMaximum = 1;
            subject.UnitOrBasisForMeasurementCode2 = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pa", "By", true)]
	[InlineData("pa", "", false)]
	[InlineData("", "By", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string operationEnvironmentCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.OperationEnvironmentCode = operationEnvironmentCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
			subject.RangeMaximum = 8;
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "pa", true)]
	[InlineData("a", "", false)]
	[InlineData("", "pa", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "fw";
		subject.TypeOfProductServiceCode = "uN";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.OperationEnvironmentCode = "By";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Count > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2j";
			subject.Count = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2) || subject.RangeMaximum > 0 || subject.RangeMinimum > 0 || subject.MeasurementValue > 0)
		{
			subject.UnitOrBasisForMeasurementCode2 = "Zo";
			subject.RangeMaximum = 8;
			subject.RangeMinimum = 4;
			subject.MeasurementValue = 7;
		}
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "s";
			subject.Count = 6;
			subject.Date = "umAd3R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
