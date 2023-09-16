using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TT*8*o";

		var expected = new TT_TermText()
		{
			AssignedNumber = 8,
			FixedFormatInformation = "o",
		};

		var actual = Map.MapObject<TT_TermText>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new TT_TermText();
		subject.FixedFormatInformation = "o";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredFixedFormatInformation(string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new TT_TermText();
		subject.AssignedNumber = 8;
		subject.FixedFormatInformation = fixedFormatInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
