using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070.Composites;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSC*zL*85*dL*F*lg*R**5*Fja*y1mvKZ*uYqqmk**3*9*4*K*9*9D*s*Gy*Gs*p*5*S*S";

		var expected = new PSC_ProductServiceContract()
		{
			ContractStatusCode = "zL",
			TypeOfProductServiceCode = "85",
			TypeOfProductServiceCode2 = "dL",
			ReferenceIdentification = "F",
			EntityIdentifierCode = "lg",
			ContractNumber = "R",
			CompositeUnitOfMeasure = null,
			Count = 5,
			DateTimeQualifier = "Fja",
			Date = "y1mvKZ",
			Date2 = "uYqqmk",
			CompositeUnitOfMeasure2 = null,
			RangeMaximum = 3,
			RangeMinimum = 9,
			MeasurementValue = 4,
			ActionCode = "K",
			Percent = 9,
			AgencyQualifierCode = "9D",
			SourceSubqualifier = "s",
			OperationEnvironmentCode = "Gy",
			SpecialServicesCode = "Gs",
			Description = "p",
			UnitPrice = 5,
			YesNoConditionOrResponseCode = "S",
			ContactMethodCode = "S",
		};

		var actual = Map.MapObject<PSC_ProductServiceContract>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zL", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.TypeOfProductServiceCode = "85";
		//Test Parameters
		subject.ContractStatusCode = contractStatusCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "K";
			subject.Count = 5;
			subject.Date = "y1mvKZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("85", true)]
	public void Validation_RequiredTypeOfProductServiceCode(string typeOfProductServiceCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		//Test Parameters
		subject.TypeOfProductServiceCode = typeOfProductServiceCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "K";
			subject.Count = 5;
			subject.Date = "y1mvKZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "A", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		subject.TypeOfProductServiceCode = "85";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "K";
			subject.Count = 5;
			subject.Date = "y1mvKZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "A", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		subject.TypeOfProductServiceCode = "85";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "K";
			subject.Count = 5;
			subject.Date = "y1mvKZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "A", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "A", true)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		subject.TypeOfProductServiceCode = "85";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "K";
			subject.Count = 5;
			subject.Date = "y1mvKZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("K", 3, true)]
	[InlineData("K", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBActionCode(string actionCode, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		subject.TypeOfProductServiceCode = "85";
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
	[InlineData("K", 5, "y1mvKZ", true)]
	[InlineData("K", 0, "", false)]
	[InlineData("", 5, "y1mvKZ", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ActionCode(string actionCode, int count, string date, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		subject.TypeOfProductServiceCode = "85";
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
	[InlineData("9D", "Gy", true)]
	[InlineData("9D", "", false)]
	[InlineData("", "Gy", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string operationEnvironmentCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		subject.TypeOfProductServiceCode = "85";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.OperationEnvironmentCode = operationEnvironmentCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "K";
			subject.Count = 5;
			subject.Date = "y1mvKZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "9D", true)]
	[InlineData("s", "", false)]
	[InlineData("", "9D", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "zL";
		subject.TypeOfProductServiceCode = "85";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.OperationEnvironmentCode = "Gy";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "K";
			subject.Count = 5;
			subject.Date = "y1mvKZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
