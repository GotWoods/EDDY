using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DED*cZ*i*3DaBgH9i*x*T*4*d*C*G";

		var expected = new DED_Deductions()
		{
			TypeOfDeduction = "cZ",
			ReferenceIdentification = "i",
			Date = "3DaBgH9i",
			Amount = "x",
			ReferenceIdentification2 = "T",
			YesNoConditionOrResponseCode = "4",
			Name = "d",
			ReferenceIdentification3 = "C",
			YesNoConditionOrResponseCode2 = "G",
		};

		var actual = Map.MapObject<DED_Deductions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cZ", true)]
	public void Validation_RequiredTypeOfDeduction(string typeOfDeduction, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.ReferenceIdentification = "i";
		subject.Date = "3DaBgH9i";
		subject.Amount = "x";
		subject.ReferenceIdentification2 = "T";
		subject.YesNoConditionOrResponseCode = "4";
		//Test Parameters
		subject.TypeOfDeduction = typeOfDeduction;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "cZ";
		subject.Date = "3DaBgH9i";
		subject.Amount = "x";
		subject.ReferenceIdentification2 = "T";
		subject.YesNoConditionOrResponseCode = "4";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3DaBgH9i", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "cZ";
		subject.ReferenceIdentification = "i";
		subject.Amount = "x";
		subject.ReferenceIdentification2 = "T";
		subject.YesNoConditionOrResponseCode = "4";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "cZ";
		subject.ReferenceIdentification = "i";
		subject.Date = "3DaBgH9i";
		subject.ReferenceIdentification2 = "T";
		subject.YesNoConditionOrResponseCode = "4";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "cZ";
		subject.ReferenceIdentification = "i";
		subject.Date = "3DaBgH9i";
		subject.Amount = "x";
		subject.YesNoConditionOrResponseCode = "4";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "cZ";
		subject.ReferenceIdentification = "i";
		subject.Date = "3DaBgH9i";
		subject.Amount = "x";
		subject.ReferenceIdentification2 = "T";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
