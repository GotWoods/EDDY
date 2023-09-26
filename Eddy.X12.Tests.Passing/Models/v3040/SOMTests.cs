using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SOMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SOM*U*hH*h*D*D*HIT2Rd*n*C*BF*o*O*x9*0";

		var expected = new SOM_StatusOfMortgage()
		{
			LoanStatusCode = "U",
			DateTimePeriodFormatQualifier = "hH",
			DateTimePeriod = "h",
			YesNoConditionOrResponseCode = "D",
			TypeOfBankruptcyCode = "D",
			Date = "HIT2Rd",
			YesNoConditionOrResponseCode2 = "n",
			LoanStatusCode2 = "C",
			DateTimePeriodFormatQualifier2 = "BF",
			DateTimePeriod2 = "o",
			LoanStatusCode3 = "O",
			DateTimePeriodFormatQualifier3 = "x9",
			DateTimePeriod3 = "0",
		};

		var actual = Map.MapObject<SOM_StatusOfMortgage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredLoanStatusCode(string loanStatusCode, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "hH";
		subject.DateTimePeriod = "h";
		//Test Parameters
		subject.LoanStatusCode = loanStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "D";
			subject.Date = "HIT2Rd";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "BF";
			subject.DateTimePeriod2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "x9";
			subject.DateTimePeriod3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hH", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "U";
		subject.DateTimePeriod = "h";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "D";
			subject.Date = "HIT2Rd";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "BF";
			subject.DateTimePeriod2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "x9";
			subject.DateTimePeriod3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "U";
		subject.DateTimePeriodFormatQualifier = "hH";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "D";
			subject.Date = "HIT2Rd";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "BF";
			subject.DateTimePeriod2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "x9";
			subject.DateTimePeriod3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "HIT2Rd", true)]
	[InlineData("D", "", false)]
	[InlineData("", "HIT2Rd", false)]
	public void Validation_AllAreRequiredTypeOfBankruptcyCode(string typeOfBankruptcyCode, string date, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "U";
		subject.DateTimePeriodFormatQualifier = "hH";
		subject.DateTimePeriod = "h";
		//Test Parameters
		subject.TypeOfBankruptcyCode = typeOfBankruptcyCode;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "BF";
			subject.DateTimePeriod2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "x9";
			subject.DateTimePeriod3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BF", "o", true)]
	[InlineData("BF", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "U";
		subject.DateTimePeriodFormatQualifier = "hH";
		subject.DateTimePeriod = "h";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "D";
			subject.Date = "HIT2Rd";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "x9";
			subject.DateTimePeriod3 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x9", "0", true)]
	[InlineData("x9", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "U";
		subject.DateTimePeriodFormatQualifier = "hH";
		subject.DateTimePeriod = "h";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "D";
			subject.Date = "HIT2Rd";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "BF";
			subject.DateTimePeriod2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
