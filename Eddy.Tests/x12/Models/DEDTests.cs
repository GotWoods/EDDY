using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DED*7k*o*H6yGxmIb*m*c*K*8*E*Y";

		var expected = new DED_Deductions()
		{
			TypeOfDeductionCode = "7k",
			ReferenceIdentification = "o",
			Date = "H6yGxmIb",
			Amount = "m",
			ReferenceIdentification2 = "c",
			YesNoConditionOrResponseCode = "K",
			Name = "8",
			ReferenceIdentification3 = "E",
			YesNoConditionOrResponseCode2 = "Y",
		};

		var actual = Map.MapObject<DED_Deductions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7k", true)]
	public void Validatation_RequiredTypeOfDeductionCode(string typeOfDeductionCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		subject.ReferenceIdentification = "o";
		subject.Date = "H6yGxmIb";
		subject.Amount = "m";
		subject.ReferenceIdentification2 = "c";
		subject.YesNoConditionOrResponseCode = "K";
		subject.TypeOfDeductionCode = typeOfDeductionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		subject.TypeOfDeductionCode = "7k";
		subject.Date = "H6yGxmIb";
		subject.Amount = "m";
		subject.ReferenceIdentification2 = "c";
		subject.YesNoConditionOrResponseCode = "K";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H6yGxmIb", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		subject.TypeOfDeductionCode = "7k";
		subject.ReferenceIdentification = "o";
		subject.Amount = "m";
		subject.ReferenceIdentification2 = "c";
		subject.YesNoConditionOrResponseCode = "K";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validatation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		subject.TypeOfDeductionCode = "7k";
		subject.ReferenceIdentification = "o";
		subject.Date = "H6yGxmIb";
		subject.ReferenceIdentification2 = "c";
		subject.YesNoConditionOrResponseCode = "K";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validatation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		subject.TypeOfDeductionCode = "7k";
		subject.ReferenceIdentification = "o";
		subject.Date = "H6yGxmIb";
		subject.Amount = "m";
		subject.YesNoConditionOrResponseCode = "K";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		subject.TypeOfDeductionCode = "7k";
		subject.ReferenceIdentification = "o";
		subject.Date = "H6yGxmIb";
		subject.Amount = "m";
		subject.ReferenceIdentification2 = "c";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
