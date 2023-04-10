using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAM*h3*lL*9*Pv7*fm*0v*k*c4*YD*l*V4*QB*U*45*CO*f";

		var expected = new DAM_DamageInformation()
		{
			DamageStatusCode = "h3",
			DamageAreaCode = "lL",
			Amount = "9",
			CurrencyCode = "Pv7",
			DamageStatusCode2 = "fm",
			DamageAreaCode2 = "0v",
			Amount2 = "k",
			DamageStatusCode3 = "c4",
			DamageAreaCode3 = "YD",
			Amount3 = "l",
			DamageStatusCode4 = "V4",
			DamageAreaCode4 = "QB",
			Amount4 = "U",
			DamageStatusCode5 = "45",
			DamageAreaCode5 = "CO",
			Amount5 = "f",
		};

		var actual = Map.MapObject<DAM_DamageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("h3","lL", true)]
	[InlineData("", "lL", true)]
	[InlineData("h3", "", true)]
	public void Validation_AtLeastOneDamageStatusCode(string damageStatusCode, string damageAreaCode, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		subject.DamageStatusCode = damageStatusCode;
		subject.DamageAreaCode = damageAreaCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("k", "fm", false)]
	[InlineData("","fm", true)]
	[InlineData("k", "", true)]
	public void Validation_NEWAmount2(string amount2, string damageStatusCode2, string damageAreaCode2, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		subject.Amount2 = amount2;
		subject.DamageStatusCode2 = damageStatusCode2;
		subject.DamageAreaCode2 = damageAreaCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("l", "c4", false)]
	[InlineData("","c4", true)]
	[InlineData("l", "", true)]
	public void Validation_NEWAmount3(string amount3, string damageStatusCode3, string damageAreaCode3, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		subject.Amount3 = amount3;
		subject.DamageStatusCode3 = damageStatusCode3;
		subject.DamageAreaCode3 = damageAreaCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("U", "V4", false)]
	[InlineData("","V4", true)]
	[InlineData("U", "", true)]
	public void Validation_NEWAmount4(string amount4, string damageStatusCode4, string damageAreaCode4, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		subject.Amount4 = amount4;
		subject.DamageStatusCode4 = damageStatusCode4;
		subject.DamageAreaCode4 = damageAreaCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("f", "45", false)]
	[InlineData("","45", true)]
	[InlineData("f", "", true)]
	public void Validation_NEWAmount5(string amount5, string damageStatusCode5, string damageAreaCode5, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		subject.Amount5 = amount5;
		subject.DamageStatusCode5 = damageStatusCode5;
		subject.DamageAreaCode5 = damageAreaCode5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	}

}
