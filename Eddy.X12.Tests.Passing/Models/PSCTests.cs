using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class PSCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSC*LZ*qZ*co*Z*CK*M**5*Hzj*y9yWFBFh*7L2ekuUt**6*3*9*Q*3*9Z*x*Sz*VR*n*6*R*p";

		var expected = new PSC_ProductServiceContract()
		{
			ContractStatusCode = "LZ",
			TypeOfProductServiceCode = "qZ",
			TypeOfProductServiceCode2 = "co",
			ReferenceIdentification = "Z",
			EntityIdentifierCode = "CK",
			ContractNumber = "M",
			CompositeUnitOfMeasure = null,
			Count = 5,
			DateTimeQualifier = "Hzj",
			Date = "y9yWFBFh",
			Date2 = "7L2ekuUt",
			CompositeUnitOfMeasure2 = null,
			RangeMaximum = 6,
			RangeMinimum = 3,
			MeasurementValue = 9,
			ActionCode = "Q",
			PercentageAsDecimal = 3,
			AgencyQualifierCode = "9Z",
			SourceSubqualifier = "x",
			OperationEnvironmentCode = "Sz",
			SpecialServicesCode = "VR",
			Description = "n",
			UnitPrice = 6,
			YesNoConditionOrResponseCode = "R",
			ContactMethodCode = "p",
		};

		var actual = Map.MapObject<PSC_ProductServiceContract>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LZ", true)]
	public void Validation_RequiredContractStatusCode(string contractStatusCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.TypeOfProductServiceCode = "qZ";
		subject.ContractStatusCode = contractStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qZ", true)]
	public void Validation_RequiredTypeOfProductServiceCode(string typeOfProductServiceCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = typeOfProductServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "AA", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBRangeMaximum(decimal rangeMaximum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = "qZ";
		if (rangeMaximum > 0)
		subject.RangeMaximum = rangeMaximum;
        if (compositeUnitOfMeasure2 != "")
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure2 };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "AA", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBRangeMinimum(decimal rangeMinimum, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = "qZ";
		if (rangeMinimum > 0)
		subject.RangeMinimum = rangeMinimum;
        if (compositeUnitOfMeasure2 != "")
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure2 };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "AA", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = "qZ";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
        if (compositeUnitOfMeasure2 != "")
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure2 };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 6, true)]
	[InlineData("Q", 0, false)]
	public void Validation_ARequiresBActionCode(string actionCode, decimal rangeMaximum, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = "qZ";
		subject.ActionCode = actionCode;
		if (rangeMaximum > 0)
		subject.RangeMaximum = rangeMaximum;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0,  "",true)]
	[InlineData("Q", 5, "",true)]
	[InlineData("",5, "",true)]
	[InlineData("Q", 0, "",true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ActionCode(string actionCode, int count, string date, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = "qZ";
		subject.ActionCode = actionCode;
		if (count > 0)
		subject.Count = count;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Sz", true)]
	[InlineData("9Z", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string operationEnvironmentCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = "qZ";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.OperationEnvironmentCode = operationEnvironmentCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "9Z", true)]
	[InlineData("x", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PSC_ProductServiceContract();
		subject.ContractStatusCode = "LZ";
		subject.TypeOfProductServiceCode = "qZ";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
