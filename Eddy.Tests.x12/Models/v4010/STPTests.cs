using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class STPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STP*LZY4EHeP*2*L*B*6*6*8*3*1";

		var expected = new STP_StudyParameters()
		{
			Date = "LZY4EHeP",
			EntityTitle = "2",
			ReferenceIdentification = "L",
			ReferenceIdentification2 = "B",
			Number = 6,
			Number2 = 6,
			Number3 = 8,
			Number4 = 3,
			ReferenceIdentification3 = "1",
		};

		var actual = Map.MapObject<STP_StudyParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LZY4EHeP", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.EntityTitle = "2";
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "B";
		subject.Number = 6;
		subject.Number2 = 6;
		subject.Number3 = 8;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredEntityTitle(string entityTitle, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "LZY4EHeP";
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "B";
		subject.Number = 6;
		subject.Number2 = 6;
		subject.Number3 = 8;
		//Test Parameters
		subject.EntityTitle = entityTitle;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "LZY4EHeP";
		subject.EntityTitle = "2";
		subject.ReferenceIdentification2 = "B";
		subject.Number = 6;
		subject.Number2 = 6;
		subject.Number3 = 8;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "LZY4EHeP";
		subject.EntityTitle = "2";
		subject.ReferenceIdentification = "L";
		subject.Number = 6;
		subject.Number2 = 6;
		subject.Number3 = 8;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "LZY4EHeP";
		subject.EntityTitle = "2";
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "B";
		subject.Number2 = 6;
		subject.Number3 = 8;
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumber2(int number2, bool isValidExpected)
	{
		var subject = new STP_StudyParameters();
		//Required fields
		subject.Date = "LZY4EHeP";
		subject.EntityTitle = "2";
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "B";
		subject.Number = 6;
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
		subject.Date = "LZY4EHeP";
		subject.EntityTitle = "2";
		subject.ReferenceIdentification = "L";
		subject.ReferenceIdentification2 = "B";
		subject.Number = 6;
		subject.Number2 = 6;
		//Test Parameters
		if (number3 > 0) 
			subject.Number3 = number3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
