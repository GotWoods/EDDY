using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class TARTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TAR*qZ*Uqb*a*g8*S*m*9";

		var expected = new TAR_TargetMarket()
		{
			CityName = "qZ",
			PostalCodeFormatted = "Uqb",
			CountrySubdivisionCode = "a",
			CountryCode = "g8",
			MarketAreaCodeQualifier = "S",
			MarketAreaCodeIdentifier = "m",
			Description = "9",
		};

		var actual = Map.MapObject<TAR_TargetMarket>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("S", "m", "9", true)]
	[InlineData("S", "", "", false)]
	[InlineData("", "m", "9", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MarketAreaCodeQualifier(string marketAreaCodeQualifier, string marketAreaCodeIdentifier, string description, bool isValidExpected)
	{
		var subject = new TAR_TargetMarket();
		//Required fields
		//Test Parameters
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		subject.MarketAreaCodeIdentifier = marketAreaCodeIdentifier;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
