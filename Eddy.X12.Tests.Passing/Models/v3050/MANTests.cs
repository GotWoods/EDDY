using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MANTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MAN*Y*5*u*y*k*K";

		var expected = new MAN_MarksAndNumbers()
		{
			MarksAndNumbersQualifier = "Y",
			MarksAndNumbers = "5",
			MarksAndNumbers2 = "u",
			MarksAndNumbersQualifier2 = "y",
			MarksAndNumbers3 = "k",
			MarksAndNumbers4 = "K",
		};

		var actual = Map.MapObject<MAN_MarksAndNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredMarksAndNumbersQualifier(string marksAndNumbersQualifier, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbers = "5";
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "y";
			subject.MarksAndNumbers3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredMarksAndNumbers(string marksAndNumbers, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "Y";
		subject.MarksAndNumbers = marksAndNumbers;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "y";
			subject.MarksAndNumbers3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "k", true)]
	[InlineData("y", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredMarksAndNumbersQualifier2(string marksAndNumbersQualifier2, string marksAndNumbers3, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "Y";
		subject.MarksAndNumbers = "5";
		subject.MarksAndNumbersQualifier2 = marksAndNumbersQualifier2;
		subject.MarksAndNumbers3 = marksAndNumbers3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "k", true)]
	[InlineData("K", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBMarksAndNumbers4(string marksAndNumbers4, string marksAndNumbers3, bool isValidExpected)
	{
		var subject = new MAN_MarksAndNumbers();
		subject.MarksAndNumbersQualifier = "Y";
		subject.MarksAndNumbers = "5";
		subject.MarksAndNumbers4 = marksAndNumbers4;
		subject.MarksAndNumbers3 = marksAndNumbers3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbersQualifier2) || !string.IsNullOrEmpty(subject.MarksAndNumbers3))
		{
			subject.MarksAndNumbersQualifier2 = "y";
			subject.MarksAndNumbers3 = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
