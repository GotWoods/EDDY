using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DED*Bd*y*AbXnKA*O*N*p*N*z*r";

		var expected = new DED_Deductions()
		{
			TypeOfDeduction = "Bd",
			ReferenceIdentification = "y",
			Date = "AbXnKA",
			Amount = "O",
			ReferenceIdentification2 = "N",
			YesNoConditionOrResponseCode = "p",
			Name = "N",
			ReferenceIdentification3 = "z",
			YesNoConditionOrResponseCode2 = "r",
		};

		var actual = Map.MapObject<DED_Deductions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bd", true)]
	public void Validation_RequiredTypeOfDeduction(string typeOfDeduction, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.ReferenceIdentification = "y";
		subject.Date = "AbXnKA";
		subject.Amount = "O";
		subject.ReferenceIdentification2 = "N";
		subject.YesNoConditionOrResponseCode = "p";
		//Test Parameters
		subject.TypeOfDeduction = typeOfDeduction;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Bd";
		subject.Date = "AbXnKA";
		subject.Amount = "O";
		subject.ReferenceIdentification2 = "N";
		subject.YesNoConditionOrResponseCode = "p";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AbXnKA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Bd";
		subject.ReferenceIdentification = "y";
		subject.Amount = "O";
		subject.ReferenceIdentification2 = "N";
		subject.YesNoConditionOrResponseCode = "p";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Bd";
		subject.ReferenceIdentification = "y";
		subject.Date = "AbXnKA";
		subject.ReferenceIdentification2 = "N";
		subject.YesNoConditionOrResponseCode = "p";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Bd";
		subject.ReferenceIdentification = "y";
		subject.Date = "AbXnKA";
		subject.Amount = "O";
		subject.YesNoConditionOrResponseCode = "p";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Bd";
		subject.ReferenceIdentification = "y";
		subject.Date = "AbXnKA";
		subject.Amount = "O";
		subject.ReferenceIdentification2 = "N";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
