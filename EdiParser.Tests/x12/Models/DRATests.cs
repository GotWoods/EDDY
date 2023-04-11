using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class DRATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DRA*b*I**TS*7*o*m*a*8mN*eqXDRJ99*G*7**8W*0";

		var expected = new DRA_DrugAuthorization()
		{
			Description = "b",
			CertificationTypeCode = "I",
			CompositeMedicalProcedureIdentifier = null,
			UnitOrBasisForMeasurementCode = "TS",
			Quantity = 7,
			FreeFormMessageText = "o",
			YesNoConditionOrResponseCode = "m",
			YesNoConditionOrResponseCode2 = "a",
			DateTimeQualifier = "8mN",
			Date = "eqXDRJ99",
			FreeFormMessageText2 = "G",
			Quantity2 = 7,
			QuestionAndAnswer = null,
			DosageFormCode = "8W",
			FreeFormMessageText3 = "0",
		};

		var actual = Map.MapObject<DRA_DrugAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validatation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new DRA_DrugAuthorization();
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("TS", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("TS", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new DRA_DrugAuthorization();
		subject.Description = "b";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
