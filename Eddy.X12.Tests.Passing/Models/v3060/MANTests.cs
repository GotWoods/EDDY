using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MAN*D*U*n*t*c*b";

		var expected = new MAN_MarksAndNumbers()
		{
			MarksAndNumbersQualifier = "D",
			MarksAndNumbers = "U",
			MarksAndNumbers2 = "n",
			MarksAndNumbersQualifier2 = "t",
			MarksAndNumbers3 = "c",
			MarksAndNumbers4 = "b",
		};

		var actual = Map.MapObject<MAN_MarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredMarksAndNumbersQualifier(string marksAndNumbersQualifier, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbers = "U";
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "t";
			subject.MarksAndNumbers3 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredMarksAndNumbers(string marksAndNumbers, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "D";
		subject.MarksAndNumbers = marksAndNumbers;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "t";
			subject.MarksAndNumbers3 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "c", true)]
	[InlineData("t", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredMarksAndNumbersQualifier2(string marksAndNumbersQualifier2, string marksAndNumbers3, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "D";
		subject.MarksAndNumbers = "U";
		subject.MarksAndNumbersQualifier2 = marksAndNumbersQualifier2;
		subject.MarksAndNumbers3 = marksAndNumbers3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "c", true)]
	[InlineData("b", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBMarksAndNumbers4(string marksAndNumbers4, string marksAndNumbers3, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "D";
		subject.MarksAndNumbers = "U";
		subject.MarksAndNumbers4 = marksAndNumbers4;
		subject.MarksAndNumbers3 = marksAndNumbers3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "t";
			subject.MarksAndNumbers3 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
