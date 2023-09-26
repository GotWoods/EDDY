using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class DEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DED*Xp*l*Iecdkf8q*a*d*o*m*X*B";

		var expected = new DED_Deductions()
		{
			TypeOfDeductionCode = "Xp",
			ReferenceIdentification = "l",
			Date = "Iecdkf8q",
			Amount = "a",
			ReferenceIdentification2 = "d",
			YesNoConditionOrResponseCode = "o",
			Name = "m",
			ReferenceIdentification3 = "X",
			YesNoConditionOrResponseCode2 = "B",
		};

		var actual = Map.MapObject<DED_Deductions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xp", true)]
	public void Validation_RequiredTypeOfDeductionCode(string typeOfDeductionCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.ReferenceIdentification = "l";
		subject.Date = "Iecdkf8q";
		subject.Amount = "a";
		subject.ReferenceIdentification2 = "d";
		subject.YesNoConditionOrResponseCode = "o";
		//Test Parameters
		subject.TypeOfDeductionCode = typeOfDeductionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeductionCode = "Xp";
		subject.Date = "Iecdkf8q";
		subject.Amount = "a";
		subject.ReferenceIdentification2 = "d";
		subject.YesNoConditionOrResponseCode = "o";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Iecdkf8q", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeductionCode = "Xp";
		subject.ReferenceIdentification = "l";
		subject.Amount = "a";
		subject.ReferenceIdentification2 = "d";
		subject.YesNoConditionOrResponseCode = "o";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeductionCode = "Xp";
		subject.ReferenceIdentification = "l";
		subject.Date = "Iecdkf8q";
		subject.ReferenceIdentification2 = "d";
		subject.YesNoConditionOrResponseCode = "o";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeductionCode = "Xp";
		subject.ReferenceIdentification = "l";
		subject.Date = "Iecdkf8q";
		subject.Amount = "a";
		subject.YesNoConditionOrResponseCode = "o";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeductionCode = "Xp";
		subject.ReferenceIdentification = "l";
		subject.Date = "Iecdkf8q";
		subject.Amount = "a";
		subject.ReferenceIdentification2 = "d";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
