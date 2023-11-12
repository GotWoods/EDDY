using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class CIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CII*7*1*3361*4Pw*y";

		var expected = new CII_ConveyanceInsuranceInformation()
		{
			Name = "7",
			ReferenceIdentification = "1",
			Year = 3361,
			CurrencyCode = "4Pw",
			Amount = "y",
		};

		var actual = Map.MapObject<CII_ConveyanceInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.ReferenceIdentification = "1";
		subject.Year = 3361;
		subject.CurrencyCode = "4Pw";
		subject.Amount = "y";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.Name = "7";
		subject.Year = 3361;
		subject.CurrencyCode = "4Pw";
		subject.Amount = "y";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3361, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.Name = "7";
		subject.ReferenceIdentification = "1";
		subject.CurrencyCode = "4Pw";
		subject.Amount = "y";
		//Test Parameters
		if (year > 0) 
			subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Pw", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.Name = "7";
		subject.ReferenceIdentification = "1";
		subject.Year = 3361;
		subject.Amount = "y";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.Name = "7";
		subject.ReferenceIdentification = "1";
		subject.Year = 3361;
		subject.CurrencyCode = "4Pw";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
