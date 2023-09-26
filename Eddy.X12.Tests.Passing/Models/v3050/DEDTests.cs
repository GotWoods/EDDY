using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DED*4A*w*p2z7wY*E*h*t*T*9*x";

		var expected = new DED_Deductions()
		{
			TypeOfDeduction = "4A",
			ReferenceNumber = "w",
			Date = "p2z7wY",
			Amount = "E",
			ReferenceNumber2 = "h",
			YesNoConditionOrResponseCode = "t",
			Name = "T",
			ReferenceNumber3 = "9",
			YesNoConditionOrResponseCode2 = "x",
		};

		var actual = Map.MapObject<DED_Deductions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4A", true)]
	public void Validation_RequiredTypeOfDeduction(string typeOfDeduction, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.ReferenceNumber = "w";
		subject.Date = "p2z7wY";
		subject.Amount = "E";
		subject.ReferenceNumber2 = "h";
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		subject.TypeOfDeduction = typeOfDeduction;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "4A";
		subject.Date = "p2z7wY";
		subject.Amount = "E";
		subject.ReferenceNumber2 = "h";
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p2z7wY", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "4A";
		subject.ReferenceNumber = "w";
		subject.Amount = "E";
		subject.ReferenceNumber2 = "h";
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "4A";
		subject.ReferenceNumber = "w";
		subject.Date = "p2z7wY";
		subject.ReferenceNumber2 = "h";
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "4A";
		subject.ReferenceNumber = "w";
		subject.Date = "p2z7wY";
		subject.Amount = "E";
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "4A";
		subject.ReferenceNumber = "w";
		subject.Date = "p2z7wY";
		subject.Amount = "E";
		subject.ReferenceNumber2 = "h";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
