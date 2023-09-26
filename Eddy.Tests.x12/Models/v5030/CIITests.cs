using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CII*2*W*1275*Lum*y";

		var expected = new CII_ConveyanceInsuranceInformation()
		{
			Name = "2",
			ReferenceIdentification = "W",
			Year = 1275,
			CurrencyCode = "Lum",
			Amount = "y",
		};

		var actual = Map.MapObject<CII_ConveyanceInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.ReferenceIdentification = "W";
		subject.Year = 1275;
		subject.Amount = "y";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.Name = "2";
		subject.Year = 1275;
		subject.Amount = "y";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1275, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.Name = "2";
		subject.ReferenceIdentification = "W";
		subject.Amount = "y";
		//Test Parameters
		if (year > 0) 
			subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new CII_ConveyanceInsuranceInformation();
		//Required fields
		subject.Name = "2";
		subject.ReferenceIdentification = "W";
		subject.Year = 1275;
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
