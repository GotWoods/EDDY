using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class M0Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M0*5d*CXIIaM*mhpCYe*OMDKJG";

		var expected = new M0_LetterOfCreditReference()
		{
			LetterOfCreditNumber = "5d",
			Date = "CXIIaM",
			Date2 = "mhpCYe",
			Date3 = "OMDKJG",
		};

		var actual = Map.MapObject<M0_LetterOfCreditReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5d", true)]
	public void Validation_RequiredLetterOfCreditNumber(string letterOfCreditNumber, bool isValidExpected)
	{
		var subject = new M0_LetterOfCreditReference();
		subject.LetterOfCreditNumber = letterOfCreditNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
