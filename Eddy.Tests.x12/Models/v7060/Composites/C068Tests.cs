using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060.Composites;

public class C068Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "e*PY*S*iP*I*mA*i*wn*I*w4*A*k6*B*zr*v*Tz";

		var expected = new C068_CompositeIngredientInformation()
		{
			FreeFormMessageText = "e",
			LanguageCode = "PY",
			FreeFormMessageText2 = "S",
			LanguageCode2 = "iP",
			FreeFormMessageText3 = "I",
			LanguageCode3 = "mA",
			FreeFormMessageText4 = "i",
			LanguageCode4 = "wn",
			FreeFormMessageText5 = "I",
			LanguageCode5 = "w4",
			FreeFormMessageText6 = "A",
			LanguageCode6 = "k6",
			FreeFormMessageText7 = "B",
			LanguageCode7 = "zr",
			FreeFormMessageText8 = "v",
			LanguageCode8 = "Tz",
		};

		var actual = Map.MapObject<C068_CompositeIngredientInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredFreeFormMessageText(string freeFormMessageText, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText = freeFormMessageText;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PY", true)]
	public void Validation_RequiredLanguageCode(string languageCode, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		//Test Parameters
		subject.LanguageCode = languageCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "iP", true)]
	[InlineData("S", "", false)]
	[InlineData("", "iP", false)]
	public void Validation_AllAreRequiredFreeFormMessageText2(string freeFormMessageText2, string languageCode2, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText2 = freeFormMessageText2;
		subject.LanguageCode2 = languageCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "mA", true)]
	[InlineData("I", "", false)]
	[InlineData("", "mA", false)]
	public void Validation_AllAreRequiredFreeFormMessageText3(string freeFormMessageText3, string languageCode3, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText3 = freeFormMessageText3;
		subject.LanguageCode3 = languageCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "wn", true)]
	[InlineData("i", "", false)]
	[InlineData("", "wn", false)]
	public void Validation_AllAreRequiredFreeFormMessageText4(string freeFormMessageText4, string languageCode4, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText4 = freeFormMessageText4;
		subject.LanguageCode4 = languageCode4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "w4", true)]
	[InlineData("I", "", false)]
	[InlineData("", "w4", false)]
	public void Validation_AllAreRequiredFreeFormMessageText5(string freeFormMessageText5, string languageCode5, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText5 = freeFormMessageText5;
		subject.LanguageCode5 = languageCode5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "k6", true)]
	[InlineData("A", "", false)]
	[InlineData("", "k6", false)]
	public void Validation_AllAreRequiredFreeFormMessageText6(string freeFormMessageText6, string languageCode6, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText6 = freeFormMessageText6;
		subject.LanguageCode6 = languageCode6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "zr", true)]
	[InlineData("B", "", false)]
	[InlineData("", "zr", false)]
	public void Validation_AllAreRequiredFreeFormMessageText7(string freeFormMessageText7, string languageCode7, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText7 = freeFormMessageText7;
		subject.LanguageCode7 = languageCode7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.FreeFormMessageText8) || !string.IsNullOrEmpty(subject.LanguageCode8))
		{
			subject.FreeFormMessageText8 = "v";
			subject.LanguageCode8 = "Tz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "Tz", true)]
	[InlineData("v", "", false)]
	[InlineData("", "Tz", false)]
	public void Validation_AllAreRequiredFreeFormMessageText8(string freeFormMessageText8, string languageCode8, bool isValidExpected)
	{
		var subject = new C068_CompositeIngredientInformation();
		//Required fields
		subject.FreeFormMessageText = "e";
		subject.LanguageCode = "PY";
		//Test Parameters
		subject.FreeFormMessageText8 = freeFormMessageText8;
		subject.LanguageCode8 = languageCode8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "S";
			subject.LanguageCode2 = "iP";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "I";
			subject.LanguageCode3 = "mA";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "i";
			subject.LanguageCode4 = "wn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.FreeFormMessageText5) || !string.IsNullOrEmpty(subject.LanguageCode5))
		{
			subject.FreeFormMessageText5 = "I";
			subject.LanguageCode5 = "w4";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.FreeFormMessageText6) || !string.IsNullOrEmpty(subject.LanguageCode6))
		{
			subject.FreeFormMessageText6 = "A";
			subject.LanguageCode6 = "k6";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.FreeFormMessageText7) || !string.IsNullOrEmpty(subject.LanguageCode7))
		{
			subject.FreeFormMessageText7 = "B";
			subject.LanguageCode7 = "zr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
