using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060.Composites;

public class C071Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "2*Bf*k*Jx*S*gn*n*fD";

		var expected = new C071_CompositeMultipleLanguageTextInformation()
		{
			FreeFormMessageText = "2",
			LanguageCode = "Bf",
			FreeFormMessageText2 = "k",
			LanguageCode2 = "Jx",
			FreeFormMessageText3 = "S",
			LanguageCode3 = "gn",
			FreeFormMessageText4 = "n",
			LanguageCode4 = "fD",
		};

		var actual = Map.MapObject<C071_CompositeMultipleLanguageTextInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredFreeFormMessageText(string freeFormMessageText, bool isValidExpected)
	{
		var subject = new C071_CompositeMultipleLanguageTextInformation();
		//Required fields
		subject.LanguageCode = "Bf";
		//Test Parameters
		subject.FreeFormMessageText = freeFormMessageText;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "k";
			subject.LanguageCode2 = "Jx";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "S";
			subject.LanguageCode3 = "gn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "n";
			subject.LanguageCode4 = "fD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bf", true)]
	public void Validation_RequiredLanguageCode(string languageCode, bool isValidExpected)
	{
		var subject = new C071_CompositeMultipleLanguageTextInformation();
		//Required fields
		subject.FreeFormMessageText = "2";
		//Test Parameters
		subject.LanguageCode = languageCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "k";
			subject.LanguageCode2 = "Jx";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "S";
			subject.LanguageCode3 = "gn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "n";
			subject.LanguageCode4 = "fD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "Jx", true)]
	[InlineData("k", "", false)]
	[InlineData("", "Jx", false)]
	public void Validation_AllAreRequiredFreeFormMessageText2(string freeFormMessageText2, string languageCode2, bool isValidExpected)
	{
		var subject = new C071_CompositeMultipleLanguageTextInformation();
		//Required fields
		subject.FreeFormMessageText = "2";
		subject.LanguageCode = "Bf";
		//Test Parameters
		subject.FreeFormMessageText2 = freeFormMessageText2;
		subject.LanguageCode2 = languageCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "S";
			subject.LanguageCode3 = "gn";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "n";
			subject.LanguageCode4 = "fD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "gn", true)]
	[InlineData("S", "", false)]
	[InlineData("", "gn", false)]
	public void Validation_AllAreRequiredFreeFormMessageText3(string freeFormMessageText3, string languageCode3, bool isValidExpected)
	{
		var subject = new C071_CompositeMultipleLanguageTextInformation();
		//Required fields
		subject.FreeFormMessageText = "2";
		subject.LanguageCode = "Bf";
		//Test Parameters
		subject.FreeFormMessageText3 = freeFormMessageText3;
		subject.LanguageCode3 = languageCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "k";
			subject.LanguageCode2 = "Jx";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.FreeFormMessageText4) || !string.IsNullOrEmpty(subject.LanguageCode4))
		{
			subject.FreeFormMessageText4 = "n";
			subject.LanguageCode4 = "fD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "fD", true)]
	[InlineData("n", "", false)]
	[InlineData("", "fD", false)]
	public void Validation_AllAreRequiredFreeFormMessageText4(string freeFormMessageText4, string languageCode4, bool isValidExpected)
	{
		var subject = new C071_CompositeMultipleLanguageTextInformation();
		//Required fields
		subject.FreeFormMessageText = "2";
		subject.LanguageCode = "Bf";
		//Test Parameters
		subject.FreeFormMessageText4 = freeFormMessageText4;
		subject.LanguageCode4 = languageCode4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.FreeFormMessageText2) || !string.IsNullOrEmpty(subject.LanguageCode2))
		{
			subject.FreeFormMessageText2 = "k";
			subject.LanguageCode2 = "Jx";
		}
		if(!string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.FreeFormMessageText3) || !string.IsNullOrEmpty(subject.LanguageCode3))
		{
			subject.FreeFormMessageText3 = "S";
			subject.LanguageCode3 = "gn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
