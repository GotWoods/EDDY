using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class STPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STP*gusDc2*13*i*T*p*2*5*9*8*8";

		var expected = new STP_StudyParameters()
		{
			Date = "gusDc2",
			Century = 13,
			EntityTitle = "i",
			ReferenceIdentification = "T",
			ReferenceIdentification2 = "p",
			Number = 2,
			Number2 = 5,
			Number3 = 9,
			Number4 = 8,
			ReferenceIdentification3 = "8",
		};

		var actual = Map.MapObject<STP_StudyParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gusDc2", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Century = 13;
		subject.EntityTitle = "i";
		subject.ReferenceIdentification = "T";
		subject.ReferenceIdentification2 = "p";
		subject.Number = 2;
		subject.Number2 = 5;
		subject.Number3 = 9;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(13, true)]
	public void Validation_RequiredCentury(int century, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "gusDc2";
		subject.EntityTitle = "i";
		subject.ReferenceIdentification = "T";
		subject.ReferenceIdentification2 = "p";
		subject.Number = 2;
		subject.Number2 = 5;
		subject.Number3 = 9;
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredEntityTitle(string entityTitle, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "gusDc2";
		subject.Century = 13;
		subject.ReferenceIdentification = "T";
		subject.ReferenceIdentification2 = "p";
		subject.Number = 2;
		subject.Number2 = 5;
		subject.Number3 = 9;
		//Test Parameters
		subject.EntityTitle = entityTitle;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "gusDc2";
		subject.Century = 13;
		subject.EntityTitle = "i";
		subject.ReferenceIdentification2 = "p";
		subject.Number = 2;
		subject.Number2 = 5;
		subject.Number3 = 9;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "gusDc2";
		subject.Century = 13;
		subject.EntityTitle = "i";
		subject.ReferenceIdentification = "T";
		subject.Number = 2;
		subject.Number2 = 5;
		subject.Number3 = 9;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "gusDc2";
		subject.Century = 13;
		subject.EntityTitle = "i";
		subject.ReferenceIdentification = "T";
		subject.ReferenceIdentification2 = "p";
		subject.Number2 = 5;
		subject.Number3 = 9;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumber2(int number2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "gusDc2";
		subject.Century = 13;
		subject.EntityTitle = "i";
		subject.ReferenceIdentification = "T";
		subject.ReferenceIdentification2 = "p";
		subject.Number = 2;
		subject.Number3 = 9;
		//Test Parameters
		if (number2 > 0) 
			subject.Number2 = number2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumber3(int number3, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "gusDc2";
		subject.Century = 13;
		subject.EntityTitle = "i";
		subject.ReferenceIdentification = "T";
		subject.ReferenceIdentification2 = "p";
		subject.Number = 2;
		subject.Number2 = 5;
		//Test Parameters
		if (number3 > 0) 
			subject.Number3 = number3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
