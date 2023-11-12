using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class STPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STP*CxlXH0Or*f*I*M*7*9*3*1*q";

		var expected = new STP_StudyParameters()
		{
			Date = "CxlXH0Or",
			EntityTitle = "f",
			ReferenceIdentification = "I",
			ReferenceIdentification2 = "M",
			Number = 7,
			Number2 = 9,
			Number3 = 3,
			Number4 = 1,
			ReferenceIdentification3 = "q",
		};

		var actual = Map.MapObject<STP_StudyParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CxlXH0Or", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.EntityTitle = "f";
		subject.ReferenceIdentification = "I";
		subject.ReferenceIdentification2 = "M";
		subject.Number = 7;
		subject.Number2 = 9;
		subject.Number3 = 3;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredEntityTitle(string entityTitle, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "CxlXH0Or";
		subject.ReferenceIdentification = "I";
		subject.ReferenceIdentification2 = "M";
		subject.Number = 7;
		subject.Number2 = 9;
		subject.Number3 = 3;
		//Test Parameters
		subject.EntityTitle = entityTitle;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "CxlXH0Or";
		subject.EntityTitle = "f";
		subject.ReferenceIdentification2 = "M";
		subject.Number = 7;
		subject.Number2 = 9;
		subject.Number3 = 3;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "CxlXH0Or";
		subject.EntityTitle = "f";
		subject.ReferenceIdentification = "I";
		subject.Number = 7;
		subject.Number2 = 9;
		subject.Number3 = 3;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "CxlXH0Or";
		subject.EntityTitle = "f";
		subject.ReferenceIdentification = "I";
		subject.ReferenceIdentification2 = "M";
		subject.Number2 = 9;
		subject.Number3 = 3;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumber2(int number2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "CxlXH0Or";
		subject.EntityTitle = "f";
		subject.ReferenceIdentification = "I";
		subject.ReferenceIdentification2 = "M";
		subject.Number = 7;
		subject.Number3 = 3;
		//Test Parameters
		if (number2 > 0) 
			subject.Number2 = number2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumber3(int number3, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "CxlXH0Or";
		subject.EntityTitle = "f";
		subject.ReferenceIdentification = "I";
		subject.ReferenceIdentification2 = "M";
		subject.Number = 7;
		subject.Number2 = 9;
		//Test Parameters
		if (number3 > 0) 
			subject.Number3 = number3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
