using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.Tests.Models.v8030;

public class MANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MAN*J*p*Z*2*S*3";

		var expected = new MAN_MarksAndNumbersInformation()
		{
			MarksAndNumbersQualifier = "J",
			MarksAndNumbers = "p",
			MarksAndNumbers2 = "Z",
			MarksAndNumbersQualifier2 = "2",
			MarksAndNumbers3 = "S",
			MarksAndNumbers4 = "3",
		};

		var actual = Map.MapObject<MAN_MarksAndNumbersInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredMarksAndNumbersQualifier(string marksAndNumbersQualifier, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbersInformation();
		subject.MarksAndNumbers = "p";
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "2";
			subject.MarksAndNumbers3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredMarksAndNumbers(string marksAndNumbers, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbersInformation();
		subject.MarksAndNumbersQualifier = "J";
		subject.MarksAndNumbers = marksAndNumbers;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "2";
			subject.MarksAndNumbers3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "S", true)]
	[InlineData("2", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredMarksAndNumbersQualifier2(string marksAndNumbersQualifier2, string marksAndNumbers3, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbersInformation();
		subject.MarksAndNumbersQualifier = "J";
		subject.MarksAndNumbers = "p";
		subject.MarksAndNumbersQualifier2 = marksAndNumbersQualifier2;
		subject.MarksAndNumbers3 = marksAndNumbers3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "S", true)]
	[InlineData("3", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBMarksAndNumbers4(string marksAndNumbers4, string marksAndNumbers3, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbersInformation();
		subject.MarksAndNumbersQualifier = "J";
		subject.MarksAndNumbers = "p";
		subject.MarksAndNumbers4 = marksAndNumbers4;
		subject.MarksAndNumbers3 = marksAndNumbers3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "2";
			subject.MarksAndNumbers3 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
