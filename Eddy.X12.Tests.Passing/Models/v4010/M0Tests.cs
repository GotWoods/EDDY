using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class M0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M0*XT*w0GzkjpQ*aA1Rckpd*2DvPcM58";

		var expected = new M0_LetterOfCreditReference()
		{
			LetterOfCreditNumber = "XT",
			Date = "w0GzkjpQ",
			Date2 = "aA1Rckpd",
			Date3 = "2DvPcM58",
		};

		var actual = Map.MapObject<M0_LetterOfCreditReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XT", true)]
	public void Validation_RequiredLetterOfCreditNumber(string letterOfCreditNumber, bool isValidExpected)
	{
		var subject = new M0_LetterOfCreditReference();
		subject.LetterOfCreditNumber = letterOfCreditNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
