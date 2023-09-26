using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SOMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SOM*H*q5*P*5*V*lRZd3FSm*5*0*yb*a*1*Dn*K";

		var expected = new SOM_StatusOfMortgage()
		{
			LoanStatusCode = "H",
			DateTimePeriodFormatQualifier = "q5",
			DateTimePeriod = "P",
			YesNoConditionOrResponseCode = "5",
			TypeOfBankruptcyCode = "V",
			Date = "lRZd3FSm",
			YesNoConditionOrResponseCode2 = "5",
			LoanStatusCode2 = "0",
			DateTimePeriodFormatQualifier2 = "yb",
			DateTimePeriod2 = "a",
			LoanStatusCode3 = "1",
			DateTimePeriodFormatQualifier3 = "Dn",
			DateTimePeriod3 = "K",
		};

		var actual = Map.MapObject<SOM_StatusOfMortgage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredLoanStatusCode(string loanStatusCode, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "q5";
		subject.DateTimePeriod = "P";
		//Test Parameters
		subject.LoanStatusCode = loanStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "V";
			subject.Date = "lRZd3FSm";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "yb";
			subject.DateTimePeriod2 = "a";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Dn";
			subject.DateTimePeriod3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q5", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "H";
		subject.DateTimePeriod = "P";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "V";
			subject.Date = "lRZd3FSm";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "yb";
			subject.DateTimePeriod2 = "a";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Dn";
			subject.DateTimePeriod3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "H";
		subject.DateTimePeriodFormatQualifier = "q5";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "V";
			subject.Date = "lRZd3FSm";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "yb";
			subject.DateTimePeriod2 = "a";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Dn";
			subject.DateTimePeriod3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "lRZd3FSm", true)]
	[InlineData("V", "", false)]
	[InlineData("", "lRZd3FSm", false)]
	public void Validation_AllAreRequiredTypeOfBankruptcyCode(string typeOfBankruptcyCode, string date, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "H";
		subject.DateTimePeriodFormatQualifier = "q5";
		subject.DateTimePeriod = "P";
		//Test Parameters
		subject.TypeOfBankruptcyCode = typeOfBankruptcyCode;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "yb";
			subject.DateTimePeriod2 = "a";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Dn";
			subject.DateTimePeriod3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yb", "a", true)]
	[InlineData("yb", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "H";
		subject.DateTimePeriodFormatQualifier = "q5";
		subject.DateTimePeriod = "P";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "V";
			subject.Date = "lRZd3FSm";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier3) || !string.IsNullOrEmpty(subject.DateTimePeriod3))
		{
			subject.DateTimePeriodFormatQualifier3 = "Dn";
			subject.DateTimePeriod3 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Dn", "K", true)]
	[InlineData("Dn", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier3(string dateTimePeriodFormatQualifier3, string dateTimePeriod3, bool isValidExpected)
	{
		var subject = new SOM_StatusOfMortgage();
		//Required fields
		subject.LoanStatusCode = "H";
		subject.DateTimePeriodFormatQualifier = "q5";
		subject.DateTimePeriod = "P";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier3 = dateTimePeriodFormatQualifier3;
		subject.DateTimePeriod3 = dateTimePeriod3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.TypeOfBankruptcyCode) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.TypeOfBankruptcyCode = "V";
			subject.Date = "lRZd3FSm";
		}
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier2) || !string.IsNullOrEmpty(subject.DateTimePeriod2))
		{
			subject.DateTimePeriodFormatQualifier2 = "yb";
			subject.DateTimePeriod2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
