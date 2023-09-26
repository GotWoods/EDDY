using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DED*Vy*4*GvCSWB*n*p*K*k*7*8";

		var expected = new DED_Deductions()
		{
			TypeOfDeduction = "Vy",
			ReferenceIdentification = "4",
			Date = "GvCSWB",
			Amount = "n",
			ReferenceIdentification2 = "p",
			YesNoConditionOrResponseCode = "K",
			Name = "k",
			ReferenceIdentification3 = "7",
			YesNoConditionOrResponseCode2 = "8",
		};

		var actual = Map.MapObject<DED_Deductions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vy", true)]
	public void Validation_RequiredTypeOfDeduction(string typeOfDeduction, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.ReferenceIdentification = "4";
		subject.Date = "GvCSWB";
		subject.Amount = "n";
		subject.ReferenceIdentification2 = "p";
		subject.YesNoConditionOrResponseCode = "K";
		//Test Parameters
		subject.TypeOfDeduction = typeOfDeduction;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Vy";
		subject.Date = "GvCSWB";
		subject.Amount = "n";
		subject.ReferenceIdentification2 = "p";
		subject.YesNoConditionOrResponseCode = "K";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GvCSWB", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Vy";
		subject.ReferenceIdentification = "4";
		subject.Amount = "n";
		subject.ReferenceIdentification2 = "p";
		subject.YesNoConditionOrResponseCode = "K";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Vy";
		subject.ReferenceIdentification = "4";
		subject.Date = "GvCSWB";
		subject.ReferenceIdentification2 = "p";
		subject.YesNoConditionOrResponseCode = "K";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Vy";
		subject.ReferenceIdentification = "4";
		subject.Date = "GvCSWB";
		subject.Amount = "n";
		subject.YesNoConditionOrResponseCode = "K";
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new DED_Deductions();
		//Required fields
		subject.TypeOfDeduction = "Vy";
		subject.ReferenceIdentification = "4";
		subject.Date = "GvCSWB";
		subject.Amount = "n";
		subject.ReferenceIdentification2 = "p";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
