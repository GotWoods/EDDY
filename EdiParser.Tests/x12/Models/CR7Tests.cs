using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CR7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR7*kE*8*7";

		var expected = new CR7_HomeHealthTreatmentPlanCertification()
		{
			DisciplineTypeCode = "kE",
			Number = 8,
			Number2 = 7,
		};

		var actual = Map.MapObject<CR7_HomeHealthTreatmentPlanCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kE", true)]
	public void Validatation_RequiredDisciplineTypeCode(string disciplineTypeCode, bool isValidExpected)
	{
		var subject = new CR7_HomeHealthTreatmentPlanCertification();
		subject.Number = 8;
		subject.Number2 = 7;
		subject.DisciplineTypeCode = disciplineTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validatation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new CR7_HomeHealthTreatmentPlanCertification();
		subject.DisciplineTypeCode = "kE";
		subject.Number2 = 7;
		if (number > 0)
		subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validatation_RequiredNumber2(int number2, bool isValidExpected)
	{
		var subject = new CR7_HomeHealthTreatmentPlanCertification();
		subject.DisciplineTypeCode = "kE";
		subject.Number = 8;
		if (number2 > 0)
		subject.Number2 = number2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
