using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class F13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F13*p*fBf1vx*1*1164243876199131*6R5z9y";

		var expected = new F13_PaymentInformation()
		{
			CheckNumber = "p",
			Date = "fBf1vx",
			Amount = "1",
			MICRNumber = 1164243876199131,
			Date2 = "6R5z9y",
		};

		var actual = Map.MapObject<F13_PaymentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredCheckNumber(string checkNumber, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.Date = "fBf1vx";
		subject.Amount = "1";
		subject.CheckNumber = checkNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fBf1vx", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "p";
		subject.Amount = "1";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F13_PaymentInformation();
		subject.CheckNumber = "p";
		subject.Date = "fBf1vx";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
