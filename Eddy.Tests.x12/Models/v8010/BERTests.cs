using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class BERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BER*CQ*1";

		var expected = new BER_BeerInformation()
		{
			BeerStyle = "CQ",
			MeasurementValue = 1,
		};

		var actual = Map.MapObject<BER_BeerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CQ", true)]
	public void Validation_RequiredBeerStyle(string beerStyle, bool isValidExpected)
	{
		var subject = new BER_BeerInformation();
		//Required fields
		//Test Parameters
		subject.BeerStyle = beerStyle;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
