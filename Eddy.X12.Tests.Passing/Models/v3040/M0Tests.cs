using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M0*DS*RutnBP*gY4euF*t6qbQd";

		var expected = new M0_LetterOfCreditReference()
		{
			LetterOfCreditNumber = "DS",
			LetterOfCreditDate = "RutnBP",
			LetterOfCreditExpirationDate = "gY4euF",
			OnBoardVesselDate = "t6qbQd",
		};

		var actual = Map.MapObject<M0_LetterOfCreditReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DS", true)]
	public void Validation_RequiredLetterOfCreditNumber(string letterOfCreditNumber, bool isValidExpected)
	{
		var subject = new M0_LetterOfCreditReference();
		subject.LetterOfCreditNumber = letterOfCreditNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
