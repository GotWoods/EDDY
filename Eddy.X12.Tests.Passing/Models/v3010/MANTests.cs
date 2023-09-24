using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class MANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MAN*J*V";

		var expected = new MAN_MarksAndNumbers()
		{
			MarksAndNumbersQualifier = "J",
			MarksAndNumbers = "V",
		};

		var actual = Map.MapObject<MAN_MarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredMarksAndNumbersQualifier(string marksAndNumbersQualifier, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbers = "V";
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredMarksAndNumbers(string marksAndNumbers, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "J";
		subject.MarksAndNumbers = marksAndNumbers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
