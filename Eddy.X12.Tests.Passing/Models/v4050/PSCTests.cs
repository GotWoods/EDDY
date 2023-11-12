using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050.Composites;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class PSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSC*tK*vn*p9*W*jK*B**5*yns*N97lcbcg*HFJMPI6b**7*7*2*R*6*MZ*z*7d*HU*K*1*O*F";

		var expected = new PSC_ProductServiceContract()
		{
			ContractStatusCode = "tK",
			TypeOfProductServiceCode = "vn",
			TypeOfProductServiceCode2 = "p9",
			ReferenceIdentification = "W",
			EntityIdentifierCode = "jK",
			ContractNumber = "B",
			CompositeUnitOfMeasure = null,
			Count = 5,
			DateTimeQualifier = "yns",
			Date = "N97lcbcg",
			Date2 = "HFJMPI6b",
			CompositeUnitOfMeasure2 = null,
			RangeMaximum = 7,
			RangeMinimum = 7,
			MeasurementValue = 2,
			ActionCode = "R",
			PercentageAsDecimal = 6,
			AgencyQualifierCode = "MZ",
			SourceSubqualifier = "z",
			OperationEnvironmentCode = "7d",
			SpecialServicesCode = "HU",
			Description = "K",
			UnitPrice = 1,
			YesNoConditionOrResponseCode = "O",
			ContactMethodCode = "F",
		};

		var actual = Map.MapObject<PSC_ProductServiceContract>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tK", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		subject.ContractStatusCode = contractStatusCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "R";
			subject.Count = 5;
			subject.Date = "N97lcbcg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vn", true)]
	public void Validation_RequiredTypeOfProductServiceCode(string typeOfProductServiceCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		//Test Parameters
		subject.TypeOfProductServiceCode = typeOfProductServiceCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "R";
			subject.Count = 5;
			subject.Date = "N97lcbcg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "A", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "R";
			subject.Count = 5;
			subject.Date = "N97lcbcg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "A", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "R";
			subject.Count = 5;
			subject.Date = "N97lcbcg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "A", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "R";
			subject.Count = 5;
			subject.Date = "N97lcbcg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("R", 7, true)]
	[InlineData("R", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBActionCode(string actionCode, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//A Requires B
		if (rangeMaximum > 0)
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();

        if (subject.ActionCode != "")
        {
            subject.Count = 1;
        }


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, "", true)]
	[InlineData("R", 5, "N97lcbcg", true)]
	[InlineData("R", 0, "", false)]
	[InlineData("", 5, "N97lcbcg", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ActionCode(string actionCode, int count, string date, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (count > 0) 
			subject.Count = count;
		subject.Date = date;

        if (subject.ActionCode != "")
        {
            subject.RangeMaximum = 1;
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MZ", "7d", true)]
	[InlineData("MZ", "", false)]
	[InlineData("", "7d", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string operationEnvironmentCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.OperationEnvironmentCode = operationEnvironmentCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "R";
			subject.Count = 5;
			subject.Date = "N97lcbcg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "MZ", true)]
	[InlineData("z", "", false)]
	[InlineData("", "MZ", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "tK";
		subject.TypeOfProductServiceCode = "vn";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.OperationEnvironmentCode = "7d";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "R";
			subject.Count = 5;
			subject.Date = "N97lcbcg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
