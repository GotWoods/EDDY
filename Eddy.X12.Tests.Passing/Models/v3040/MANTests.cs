using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class MANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MAN*b*P*S*Z*H*2";

		var expected = new MAN_MarksAndNumbers()
		{
			MarksAndNumbersQualifier = "b",
			MarksAndNumbers = "P",
			MarksAndNumbers2 = "S",
			MarksAndNumbersQualifier2 = "Z",
			MarksAndNumbers3 = "H",
			MarksAndNumbers4 = "2",
		};

		var actual = Map.MapObject<MAN_MarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredMarksAndNumbersQualifier(string marksAndNumbersQualifier, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbers = "P";
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredMarksAndNumbers(string marksAndNumbers, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "b";
		subject.MarksAndNumbers = marksAndNumbers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
