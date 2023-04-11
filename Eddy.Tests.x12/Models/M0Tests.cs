using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M0*Wr*AcuZx4AI*rb2ehw5z*Z7QgrxZ7";

		var expected = new M0_LetterOfCreditReference()
		{
			LetterOfCreditNumber = "Wr",
			Date = "AcuZx4AI",
			Date2 = "rb2ehw5z",
			Date3 = "Z7QgrxZ7",
		};

		var actual = Map.MapObject<M0_LetterOfCreditReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wr", true)]
	public void Validation_RequiredLetterOfCreditNumber(string letterOfCreditNumber, bool isValidExpected)
	{
		var subject = new M0_LetterOfCreditReference();
		subject.LetterOfCreditNumber = letterOfCreditNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
