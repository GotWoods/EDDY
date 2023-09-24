using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M1*Kh*39*6V*Ki*vV*3";

		var expected = new M1_Insurance()
		{
			CountryCode = "Kh",
			CarriageValue = 39,
			DeclaredValue = "6V",
			RateValueQualifier = "Ki",
			EntityIdentifierCode = "vV",
			FreeFormMessage = "3",
		};

		var actual = Map.MapObject<M1_Insurance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kh", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CarriageValue = 39;
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(39, true)]
	public void Validation_RequiredCarriageValue(int carriageValue, bool isValidExpected)
	{
		var subject = new M1_Insurance();
		subject.CountryCode = "Kh";
		if (carriageValue > 0)
			subject.CarriageValue = carriageValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
