using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CR7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR7*R9*8*4";

		var expected = new CR7_HomeHealthTreatmentPlanCertification()
		{
			DisciplineTypeCode = "R9",
			Number = 8,
			Number2 = 4,
		};

		var actual = Map.MapObject<CR7_HomeHealthTreatmentPlanCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R9", true)]
	public void Validation_RequiredDisciplineTypeCode(string disciplineTypeCode, bool isValidExpected)
	{
		var subject = new CR7_HomeHealthTreatmentPlanCertification();
		//Required fields
		subject.Number = 8;
		subject.Number2 = 4;
		//Test Parameters
		subject.DisciplineTypeCode = disciplineTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new CR7_HomeHealthTreatmentPlanCertification();
		//Required fields
		subject.DisciplineTypeCode = "R9";
		subject.Number2 = 4;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumber2(int number2, bool isValidExpected)
	{
		var subject = new CR7_HomeHealthTreatmentPlanCertification();
		//Required fields
		subject.DisciplineTypeCode = "R9";
		subject.Number = 8;
		//Test Parameters
		if (number2 > 0) 
			subject.Number2 = number2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
