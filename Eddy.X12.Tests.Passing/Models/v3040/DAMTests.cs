using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAM*5w*o6*9*RJu*iM*Cc*X*v4*HS*S*cF*hV*7*LT*K0*N";

		var expected = new DAM_DamageInformation()
		{
			DamageStatusCode = "5w",
			DamageAreaCode = "o6",
			Amount = "9",
			CurrencyCode = "RJu",
			DamageStatusCode2 = "iM",
			DamageAreaCode2 = "Cc",
			Amount2 = "X",
			DamageStatusCode3 = "v4",
			DamageAreaCode3 = "HS",
			Amount3 = "S",
			DamageStatusCode4 = "cF",
			DamageAreaCode4 = "hV",
			Amount4 = "7",
			DamageStatusCode5 = "LT",
			DamageAreaCode5 = "K0",
			Amount5 = "N",
		};

		var actual = Map.MapObject<DAM_DamageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("5w", "o6", true)]
	[InlineData("5w", "", true)]
	[InlineData("", "o6", true)]
	public void Validation_AtLeastOneDamageStatusCode(string damageStatusCode, string damageAreaCode, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		//Required fields
		//Test Parameters
		subject.DamageStatusCode = damageStatusCode;
		subject.DamageAreaCode = damageAreaCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.DamageStatusCode2) || !string.IsNullOrEmpty(subject.DamageAreaCode2))
		{
			subject.Amount2 = "X";
			subject.DamageStatusCode2 = "iM";
			subject.DamageAreaCode2 = "Cc";
		}
		if(!string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.DamageStatusCode3) || !string.IsNullOrEmpty(subject.DamageAreaCode3))
		{
			subject.Amount3 = "S";
			subject.DamageStatusCode3 = "v4";
			subject.DamageAreaCode3 = "HS";
		}
		if(!string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.DamageStatusCode4) || !string.IsNullOrEmpty(subject.DamageAreaCode4))
		{
			subject.Amount4 = "7";
			subject.DamageStatusCode4 = "cF";
			subject.DamageAreaCode4 = "hV";
		}
		if(!string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.DamageStatusCode5) || !string.IsNullOrEmpty(subject.DamageAreaCode5))
		{
			subject.Amount5 = "N";
			subject.DamageStatusCode5 = "LT";
			subject.DamageAreaCode5 = "K0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("X", "iM", "Cc", true)]
	[InlineData("X", "", "", false)]
	[InlineData("", "iM", "Cc", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount2(string amount2, string damageStatusCode2, string damageAreaCode2, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		//Required fields
		//Test Parameters
		subject.Amount2 = amount2;
		subject.DamageStatusCode2 = damageStatusCode2;
		subject.DamageAreaCode2 = damageAreaCode2;
		//At Least one
		subject.DamageStatusCode = "5w";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.DamageStatusCode3) || !string.IsNullOrEmpty(subject.DamageAreaCode3))
		{
			subject.Amount3 = "S";
			subject.DamageStatusCode3 = "v4";
			subject.DamageAreaCode3 = "HS";
		}
		if(!string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.DamageStatusCode4) || !string.IsNullOrEmpty(subject.DamageAreaCode4))
		{
			subject.Amount4 = "7";
			subject.DamageStatusCode4 = "cF";
			subject.DamageAreaCode4 = "hV";
		}
		if(!string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.DamageStatusCode5) || !string.IsNullOrEmpty(subject.DamageAreaCode5))
		{
			subject.Amount5 = "N";
			subject.DamageStatusCode5 = "LT";
			subject.DamageAreaCode5 = "K0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("S", "v4", "HS", true)]
	[InlineData("S", "", "", false)]
	[InlineData("", "v4", "HS", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount3(string amount3, string damageStatusCode3, string damageAreaCode3, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		//Required fields
		//Test Parameters
		subject.Amount3 = amount3;
		subject.DamageStatusCode3 = damageStatusCode3;
		subject.DamageAreaCode3 = damageAreaCode3;
		//At Least one
		subject.DamageStatusCode = "5w";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.DamageStatusCode2) || !string.IsNullOrEmpty(subject.DamageAreaCode2))
		{
			subject.Amount2 = "X";
			subject.DamageStatusCode2 = "iM";
			subject.DamageAreaCode2 = "Cc";
		}
		if(!string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.DamageStatusCode4) || !string.IsNullOrEmpty(subject.DamageAreaCode4))
		{
			subject.Amount4 = "7";
			subject.DamageStatusCode4 = "cF";
			subject.DamageAreaCode4 = "hV";
		}
		if(!string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.DamageStatusCode5) || !string.IsNullOrEmpty(subject.DamageAreaCode5))
		{
			subject.Amount5 = "N";
			subject.DamageStatusCode5 = "LT";
			subject.DamageAreaCode5 = "K0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("7", "cF", "hV", true)]
	[InlineData("7", "", "", false)]
	[InlineData("", "cF", "hV", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount4(string amount4, string damageStatusCode4, string damageAreaCode4, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		//Required fields
		//Test Parameters
		subject.Amount4 = amount4;
		subject.DamageStatusCode4 = damageStatusCode4;
		subject.DamageAreaCode4 = damageAreaCode4;
		//At Least one
		subject.DamageStatusCode = "5w";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.DamageStatusCode2) || !string.IsNullOrEmpty(subject.DamageAreaCode2))
		{
			subject.Amount2 = "X";
			subject.DamageStatusCode2 = "iM";
			subject.DamageAreaCode2 = "Cc";
		}
		if(!string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.DamageStatusCode3) || !string.IsNullOrEmpty(subject.DamageAreaCode3))
		{
			subject.Amount3 = "S";
			subject.DamageStatusCode3 = "v4";
			subject.DamageAreaCode3 = "HS";
		}
		if(!string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.Amount5) || !string.IsNullOrEmpty(subject.DamageStatusCode5) || !string.IsNullOrEmpty(subject.DamageAreaCode5))
		{
			subject.Amount5 = "N";
			subject.DamageStatusCode5 = "LT";
			subject.DamageAreaCode5 = "K0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("N", "LT", "K0", true)]
	[InlineData("N", "", "", false)]
	[InlineData("", "LT", "K0", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_Amount5(string amount5, string damageStatusCode5, string damageAreaCode5, bool isValidExpected)
	{
		var subject = new DAM_DamageInformation();
		//Required fields
		//Test Parameters
		subject.Amount5 = amount5;
		subject.DamageStatusCode5 = damageStatusCode5;
		subject.DamageAreaCode5 = damageAreaCode5;
		//At Least one
		subject.DamageStatusCode = "5w";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.Amount2) || !string.IsNullOrEmpty(subject.DamageStatusCode2) || !string.IsNullOrEmpty(subject.DamageAreaCode2))
		{
			subject.Amount2 = "X";
			subject.DamageStatusCode2 = "iM";
			subject.DamageAreaCode2 = "Cc";
		}
		if(!string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.Amount3) || !string.IsNullOrEmpty(subject.DamageStatusCode3) || !string.IsNullOrEmpty(subject.DamageAreaCode3))
		{
			subject.Amount3 = "S";
			subject.DamageStatusCode3 = "v4";
			subject.DamageAreaCode3 = "HS";
		}
		if(!string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.Amount4) || !string.IsNullOrEmpty(subject.DamageStatusCode4) || !string.IsNullOrEmpty(subject.DamageAreaCode4))
		{
			subject.Amount4 = "7";
			subject.DamageStatusCode4 = "cF";
			subject.DamageAreaCode4 = "hV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
