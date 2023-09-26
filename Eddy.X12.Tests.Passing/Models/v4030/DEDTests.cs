using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class DEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DED*d1*k*aAOW66Fe*Q*2*9*Z*4*1";

		var expected = new DED_Deductions()
		{
			TypeOfDeduction = "d1",
			ReferenceIdentification = "k",
			Date = "aAOW66Fe",
			Amount = "Q",
			ReferenceIdentification2 = "2",
			YesNoConditionOrResponseCode = "9",
			Name = "Z",
			ReferenceIdentification3 = "4",
			YesNoConditionOrResponseCode2 = "1",
		};

		var actual = Map.MapObject<DED_Deductions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d1", true)]
	public void Validation_RequiredTypeOfDeduction(string typeOfDeduction, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.ReferenceIdentification = "k";
		subject.Date = "aAOW66Fe";
		subject.Amount = "Q";
		subject.ReferenceIdentification2 = "2";
		subject.YesNoConditionOrResponseCode = "9";
		//Test Parameters
		subject.TypeOfDeduction = typeOfDeduction;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "d1";
		subject.Date = "aAOW66Fe";
		subject.Amount = "Q";
		subject.ReferenceIdentification2 = "2";
		subject.YesNoConditionOrResponseCode = "9";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aAOW66Fe", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "d1";
		subject.ReferenceIdentification = "k";
		subject.Amount = "Q";
		subject.ReferenceIdentification2 = "2";
		subject.YesNoConditionOrResponseCode = "9";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "d1";
		subject.ReferenceIdentification = "k";
		subject.Date = "aAOW66Fe";
		subject.ReferenceIdentification2 = "2";
		subject.YesNoConditionOrResponseCode = "9";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "d1";
		subject.ReferenceIdentification = "k";
		subject.Date = "aAOW66Fe";
		subject.Amount = "Q";
		subject.YesNoConditionOrResponseCode = "9";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "d1";
		subject.ReferenceIdentification = "k";
		subject.Date = "aAOW66Fe";
		subject.Amount = "Q";
		subject.ReferenceIdentification2 = "2";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
