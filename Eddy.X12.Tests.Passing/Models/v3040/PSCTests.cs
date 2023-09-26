using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSC*uS*Lf*8n*S*8m*X*K9*5*gfl*UBnOqW*O3w0II*OA*1*1*1*h*1*VW*k*mP*Ps*2*3*w*9";

		var expected = new PSC_ProductServiceContract()
		{
			ContractStatusCode = "uS",
			TypeOfProductServiceCode = "Lf",
			TypeOfProductServiceCode2 = "8n",
			ReferenceNumber = "S",
			EntityIdentifierCode = "8m",
			ContractNumber = "X",
			UnitOrBasisForMeasurementCode = "K9",
			Count = 5,
			DateTimeQualifier = "gfl",
			Date = "UBnOqW",
			Date2 = "O3w0II",
			UnitOrBasisForMeasurementCode2 = "OA",
			RangeMaximum = 1,
			RangeMinimum = 1,
			MeasurementValue = 1,
			ActionCode = "h",
			Percent = 1,
			AgencyQualifierCode = "VW",
			SourceSubqualifier = "k",
			OperationEnvironmentCode = "mP",
			SpecialServicesCode = "Ps",
			Description = "2",
			UnitPrice = 3,
			SupplementalInspectionCode = "w",
			ContactMethodCode = "9",
		};

		var actual = Map.MapObject<PSC_ProductServiceContract>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uS", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		subject.ContractStatusCode = contractStatusCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Count = 5;
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lf", true)]
	public void Validation_RequiredTypeOfProductServiceCode(string typeOfProductServiceCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		//Test Parameters
		subject.TypeOfProductServiceCode = typeOfProductServiceCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Count = 5;
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "K9", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "K9", true)]
	public void Validation_ARequiresBCount(int count, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "OA", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "OA", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Count = 5;
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "OA", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "OA", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Count = 5;
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "OA", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "OA", true)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Count = 5;
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h", 1, true)]
	[InlineData("h", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBActionCode(string actionCode, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//A Requires B
		if (rangeMaximum > 0)
			subject.UnitOrBasisForMeasurementCode2 = "OA";

        if (subject.ActionCode != "")
        {
            subject.Count = 1;
            subject.UnitOrBasisForMeasurementCode = "AB";
        }


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, "", true)]
	[InlineData("h", 5, "UBnOqW", true)]
	[InlineData("h", 0, "", false)]
	[InlineData("", 5, "UBnOqW", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ActionCode(string actionCode, int count, string date, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (count > 0) 
			subject.Count = count;
		subject.Date = date;
		//A Requires B
		if (count > 0)
			subject.UnitOrBasisForMeasurementCode = "K9";


        if (subject.ActionCode != "")
        {
            subject.RangeMaximum = 1;
            subject.UnitOrBasisForMeasurementCode2 = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VW", "mP", true)]
	[InlineData("VW", "", false)]
	[InlineData("", "mP", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string operationEnvironmentCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.OperationEnvironmentCode = operationEnvironmentCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Count = 5;
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "VW", true)]
	[InlineData("k", "", false)]
	[InlineData("", "VW", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "uS";
		subject.TypeOfProductServiceCode = "Lf";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.OperationEnvironmentCode = "mP";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "h";
			subject.Count = 5;
			subject.Date = "UBnOqW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
