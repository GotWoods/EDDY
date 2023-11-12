using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class DRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DRA*V*z**4u*1*U*E*3*bdl*fVkkqOdS*7*3**sw*9";

		var expected = new DRA_DrugAuthorization()
		{
			Description = "V",
			CertificationTypeCode = "z",
			CompositeMedicalProcedureIdentifier = null,
			UnitOrBasisForMeasurementCode = "4u",
			Quantity = 1,
			FreeFormMessageText = "U",
			YesNoConditionOrResponseCode = "E",
			YesNoConditionOrResponseCode2 = "3",
			DateTimeQualifier = "bdl",
			Date = "fVkkqOdS",
			FreeFormMessageText2 = "7",
			Quantity2 = 3,
			QuestionAndAnswer = null,
			DosageFormCode = "sw",
			FreeFormMessageText3 = "9",
		};

		var actual = Map.MapObject<DRA_DrugAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new DRA_DrugAuthorization();
		//Required fields
		subject.CertificationTypeCode = "z";
		//Test Parameters
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "4u";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredCertificationTypeCode(string certificationTypeCode, bool isValidExpected)
	{
		var subject = new DRA_DrugAuthorization();
		//Required fields
		subject.Description = "V";
		//Test Parameters
		subject.CertificationTypeCode = certificationTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "4u";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4u", 1, true)]
	[InlineData("4u", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new DRA_DrugAuthorization();
		//Required fields
		subject.Description = "V";
		subject.CertificationTypeCode = "z";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
