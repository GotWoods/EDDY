using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class DRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DRA*5*x**Y1*4*A*K*O*Lf0*LqHAPT66*5*4**JN*l";

		var expected = new DRA_DrugAuthorization()
		{
			Description = "5",
			CertificationTypeCode = "x",
			CompositeMedicalProcedureIdentifier = null,
			UnitOrBasisForMeasurementCode = "Y1",
			Quantity = 4,
			FreeFormMessageText = "A",
			YesNoConditionOrResponseCode = "K",
			YesNoConditionOrResponseCode2 = "O",
			DateTimeQualifier = "Lf0",
			Date = "LqHAPT66",
			FreeFormMessageText2 = "5",
			Quantity2 = 4,
			QuestionAndAnswer = null,
			DosageFormCode = "JN",
			FreeFormMessageText3 = "l",
		};

		var actual = Map.MapObject<DRA_DrugAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new DRA_DrugAuthorization();
		//Required fields
		//Test Parameters
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "Y1";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Y1", 4, true)]
	[InlineData("Y1", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new DRA_DrugAuthorization();
		//Required fields
		subject.Description = "5";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
