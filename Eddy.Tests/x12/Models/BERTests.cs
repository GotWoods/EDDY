using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BER*pW*8";

		var expected = new BER_BeerInformation()
		{
			BeerStyle = "pW",
			MeasurementValue = 8,
		};

		var actual = Map.MapObject<BER_BeerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pW", true)]
	public void Validatation_RequiredBeerStyle(string beerStyle, bool isValidExpected)
	{
		var subject = new BER_BeerInformation();
		subject.BeerStyle = beerStyle;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
