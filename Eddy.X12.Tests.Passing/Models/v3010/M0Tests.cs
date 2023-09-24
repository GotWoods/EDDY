using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M0*Jb*7s8nxS*miHAMN*6SE4E8";

		var expected = new M0_LetterOfCreditReference()
		{
			LetterOfCreditNumber = "Jb",
			LetterOfCreditDate = "7s8nxS",
			LetterOfCreditExpirationDate = "miHAMN",
			OnBoardVesselDate = "6SE4E8",
		};

		var actual = Map.MapObject<M0_LetterOfCreditReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jb", true)]
	public void Validation_RequiredLetterOfCreditNumber(string letterOfCreditNumber, bool isValidExpected)
	{
		var subject = new M0_LetterOfCreditReference();
		subject.LetterOfCreditDate = "7s8nxS";
		subject.LetterOfCreditNumber = letterOfCreditNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7s8nxS", true)]
	public void Validation_RequiredLetterOfCreditDate(string letterOfCreditDate, bool isValidExpected)
	{
		var subject = new M0_LetterOfCreditReference();
		subject.LetterOfCreditNumber = "Jb";
		subject.LetterOfCreditDate = letterOfCreditDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
