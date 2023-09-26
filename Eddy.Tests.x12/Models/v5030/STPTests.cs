using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class STPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STP*ANfqk1rl*I*w*8*5*8*8*9*w";

		var expected = new STP_StudyParameters()
		{
			Date = "ANfqk1rl",
			EntityTitle = "I",
			ReferenceIdentification = "w",
			ReferenceIdentification2 = "8",
			Number = 5,
			Number2 = 8,
			Number3 = 8,
			Number4 = 9,
			ReferenceIdentification3 = "w",
		};

		var actual = Map.MapObject<STP_StudyParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ANfqk1rl", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.EntityTitle = "I";
		subject.ReferenceIdentification = "w";
		subject.ReferenceIdentification2 = "8";
		subject.Number = 5;
		subject.Number2 = 8;
		subject.Number3 = 8;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredEntityTitle(string entityTitle, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "ANfqk1rl";
		subject.ReferenceIdentification = "w";
		subject.ReferenceIdentification2 = "8";
		subject.Number = 5;
		subject.Number2 = 8;
		subject.Number3 = 8;
		//Test Parameters
		subject.EntityTitle = entityTitle;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "ANfqk1rl";
		subject.EntityTitle = "I";
		subject.ReferenceIdentification2 = "8";
		subject.Number = 5;
		subject.Number2 = 8;
		subject.Number3 = 8;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "ANfqk1rl";
		subject.EntityTitle = "I";
		subject.ReferenceIdentification = "w";
		subject.Number = 5;
		subject.Number2 = 8;
		subject.Number3 = 8;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "ANfqk1rl";
		subject.EntityTitle = "I";
		subject.ReferenceIdentification = "w";
		subject.ReferenceIdentification2 = "8";
		subject.Number2 = 8;
		subject.Number3 = 8;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumber2(int number2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "ANfqk1rl";
		subject.EntityTitle = "I";
		subject.ReferenceIdentification = "w";
		subject.ReferenceIdentification2 = "8";
		subject.Number = 5;
		subject.Number3 = 8;
		//Test Parameters
		if (number2 > 0) 
			subject.Number2 = number2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumber3(int number3, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "ANfqk1rl";
		subject.EntityTitle = "I";
		subject.ReferenceIdentification = "w";
		subject.ReferenceIdentification2 = "8";
		subject.Number = 5;
		subject.Number2 = 8;
		//Test Parameters
		if (number3 > 0) 
			subject.Number3 = number3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
