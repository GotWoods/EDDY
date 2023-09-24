using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class STPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STP*fGrwvAxB*w*i*u*3*7*6*8*M";

		var expected = new STP_StudyParameters()
		{
			Date = "fGrwvAxB",
			EntityTitle = "w",
			ReferenceIdentification = "i",
			ReferenceIdentification2 = "u",
			Number = 3,
			Number2 = 7,
			Number3 = 6,
			Number4 = 8,
			ReferenceIdentification3 = "M",
		};

		var actual = Map.MapObject<STP_StudyParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fGrwvAxB", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		subject.EntityTitle = "w";
		subject.ReferenceIdentification = "i";
		subject.ReferenceIdentification2 = "u";
		subject.Number = 3;
		subject.Number2 = 7;
		subject.Number3 = 6;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredEntityTitle(string entityTitle, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		subject.Date = "fGrwvAxB";
		subject.ReferenceIdentification = "i";
		subject.ReferenceIdentification2 = "u";
		subject.Number = 3;
		subject.Number2 = 7;
		subject.Number3 = 6;
		subject.EntityTitle = entityTitle;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		subject.Date = "fGrwvAxB";
		subject.EntityTitle = "w";
		subject.ReferenceIdentification2 = "u";
		subject.Number = 3;
		subject.Number2 = 7;
		subject.Number3 = 6;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		subject.Date = "fGrwvAxB";
		subject.EntityTitle = "w";
		subject.ReferenceIdentification = "i";
		subject.Number = 3;
		subject.Number2 = 7;
		subject.Number3 = 6;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		subject.Date = "fGrwvAxB";
		subject.EntityTitle = "w";
		subject.ReferenceIdentification = "i";
		subject.ReferenceIdentification2 = "u";
		subject.Number2 = 7;
		subject.Number3 = 6;
		if (number > 0)
		subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredNumber2(int number2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		subject.Date = "fGrwvAxB";
		subject.EntityTitle = "w";
		subject.ReferenceIdentification = "i";
		subject.ReferenceIdentification2 = "u";
		subject.Number = 3;
		subject.Number3 = 6;
		if (number2 > 0)
		subject.Number2 = number2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumber3(int number3, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		subject.Date = "fGrwvAxB";
		subject.EntityTitle = "w";
		subject.ReferenceIdentification = "i";
		subject.ReferenceIdentification2 = "u";
		subject.Number = 3;
		subject.Number2 = 7;
		if (number3 > 0)
		subject.Number3 = number3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
