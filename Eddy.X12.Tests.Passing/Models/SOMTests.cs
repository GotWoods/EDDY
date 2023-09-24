using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SOMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SOM*d*cJ*p*f*r*4az5yNYc*f*V*jF*O*x*Ik*x";

		var expected = new SOM_StatusOfMortgage()
		{
			LoanStatusCode = "d",
			DateTimePeriodFormatQualifier = "cJ",
			DateTimePeriod = "p",
			YesNoConditionOrResponseCode = "f",
			TypeOfBankruptcyCode = "r",
			Date = "4az5yNYc",
			YesNoConditionOrResponseCode2 = "f",
			LoanStatusCode2 = "V",
			DateTimePeriodFormatQualifier2 = "jF",
			DateTimePeriod2 = "O",
			LoanStatusCode3 = "x",
			DateTimePeriodFormatQualifier3 = "Ik",
			DateTimePeriod3 = "x",
		};

		var actual = Map.MapObject<SOM_StatusOfMortgage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLoanStatusCode(string loanStatusCode, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		subject.DateTimePeriodFormatQualifier = "cJ";
		subject.DateTimePeriod = "p";
		subject.LoanStatusCode = loanStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cJ", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		subject.LoanStatusCode = "d";
		subject.DateTimePeriod = "p";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		subject.LoanStatusCode = "d";
		subject.DateTimePeriodFormatQualifier = "cJ";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("r", "4az5yNYc", true)]
	[InlineData("", "4az5yNYc", false)]
	[InlineData("r", "", false)]
	public void Validation_AllAreRequiredTypeOfBankruptcyCode(string typeOfBankruptcyCode, string date, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		subject.LoanStatusCode = "d";
		subject.DateTimePeriodFormatQualifier = "cJ";
		subject.DateTimePeriod = "p";
		subject.TypeOfBankruptcyCode = typeOfBankruptcyCode;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("jF", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("jF", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		subject.LoanStatusCode = "d";
		subject.DateTimePeriodFormatQualifier = "cJ";
		subject.DateTimePeriod = "p";
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ik", "x", true)]
	[InlineData("", "x", false)]
	[InlineData("Ik", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		subject.LoanStatusCode = "d";
		subject.DateTimePeriodFormatQualifier = "cJ";
		subject.DateTimePeriod = "p";
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
