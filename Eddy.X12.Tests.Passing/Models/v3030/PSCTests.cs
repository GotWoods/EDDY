using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSC*u3*OT*AF*A*at*6*re*2*lOe*h92TwM*JG9b37*dR*2*9*3*k*7*LS*m*uV*2r*1*4*1*K";

		var expected = new PSC_ProductServiceContract()
		{
			ContractStatusCode = "u3",
			TypeOfProductServiceCode = "OT",
			TypeOfProductServiceCode2 = "AF",
			ReferenceNumber = "A",
			EntityIdentifierCode = "at",
			ContractNumber = "6",
			UnitOrBasisForMeasurementCode = "re",
			Count = 2,
			DateTimeQualifier = "lOe",
			Date = "h92TwM",
			Date2 = "JG9b37",
			UnitOrBasisForMeasurementCode2 = "dR",
			RangeMaximum = 2,
			RangeMinimum = 9,
			MeasurementValue = 3,
			ActionCode = "k",
			Percent = 7,
			AgencyQualifierCode = "LS",
			SourceSubqualifier = "m",
			OperationEnvironmentCode = "uV",
			SpecialServicesCode = "2r",
			Description = "1",
			UnitPrice = 4,
			SupplementalInspectionCode = "1",
			ContactMethodCode = "K",
		};

		var actual = Map.MapObject<PSC_ProductServiceContract>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u3", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		subject.ContractStatusCode = contractStatusCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Count = 2;
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OT", true)]
	public void Validation_RequiredTypeOfProductServiceCode(string typeOfProductServiceCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		//Test Parameters
		subject.TypeOfProductServiceCode = typeOfProductServiceCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Count = 2;
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "re", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "re", true)]
	public void Validation_ARequiresBCount(int count, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "dR", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "dR", true)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Count = 2;
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "dR", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "dR", true)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		if (rangeMinimum > 0) 
			subject.RangeMinimum = rangeMinimum;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Count = 2;
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "dR", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "dR", true)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Count = 2;
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("k", 2, true)]
	[InlineData("k", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBActionCode(string actionCode, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (rangeMaximum > 0) 
			subject.RangeMaximum = rangeMaximum;
		//A Requires B
		if (rangeMaximum > 0)
			subject.UnitOrBasisForMeasurementCode2 = "dR";

        if (subject.ActionCode != "")
        {
            subject.Count = 1;
            subject.UnitOrBasisForMeasurementCode = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, "", true)]
	[InlineData("k", 2, "h92TwM", true)]
	[InlineData("k", 0, "", false)]
	[InlineData("", 2, "h92TwM", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ActionCode(string actionCode, int count, string date, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		subject.ActionCode = actionCode;
		if (count > 0) 
			subject.Count = count;
		subject.Date = date;
		//A Requires B
		if (count > 0)
			subject.UnitOrBasisForMeasurementCode = "re";

        if (subject.ActionCode != "")
        {
            subject.RangeMaximum = 1;
            subject.UnitOrBasisForMeasurementCode2 = "AB";
        }

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LS", "uV", true)]
	[InlineData("LS", "", false)]
	[InlineData("", "uV", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string operationEnvironmentCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.OperationEnvironmentCode = operationEnvironmentCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Count = 2;
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "LS", true)]
	[InlineData("m", "", false)]
	[InlineData("", "LS", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		//Required fields
		subject.ContractStatusCode = "u3";
		subject.TypeOfProductServiceCode = "OT";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.OperationEnvironmentCode = "uV";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ActionCode) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Count > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.ActionCode = "k";
			subject.Count = 2;
			subject.Date = "h92TwM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
