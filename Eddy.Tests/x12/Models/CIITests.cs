using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CII*P*7*5949*6Jk*Y";

		var expected = new CII_ConveyanceInsuranceInformation()
		{
			Name = "P",
			ReferenceIdentification = "7",
			Year = 5949,
			CurrencyCode = "6Jk",
			Amount = "Y",
		};

		var actual = Map.MapObject<CII_ConveyanceInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		subject.ReferenceIdentification = "7";
		subject.Year = 5949;
		subject.Amount = "Y";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		subject.Name = "P";
		subject.Year = 5949;
		subject.Amount = "Y";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5949, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		subject.Name = "P";
		subject.ReferenceIdentification = "7";
		subject.Amount = "Y";
		if (year > 0)
		subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		subject.Name = "P";
		subject.ReferenceIdentification = "7";
		subject.Year = 5949;
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
