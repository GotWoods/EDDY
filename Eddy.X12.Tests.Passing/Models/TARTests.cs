using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAR*T4*tKB*g*tZ*E*l*E";

		var expected = new TAR_TargetMarket()
		{
			CityName = "T4",
			PostalCodeFormatted = "tKB",
			CountrySubdivisionCode = "g",
			CountryCode = "tZ",
			MarketAreaCodeQualifier = "E",
			MarketAreaCodeIdentifier = "l",
			Description = "E",
		};

		var actual = Map.MapObject<TAR_TargetMarket>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", "",true)]
	[InlineData("E", "l", "", true)]
	[InlineData("", "l", "", true)]
	[InlineData("E", "", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, string description, bool isValidExpected)
	{
		var subject = new TAR_TargetMarket();
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
