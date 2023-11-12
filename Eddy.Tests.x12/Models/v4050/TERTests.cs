using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class TERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TER*P3*O*Z*YC*4*3";

		var expected = new TER_Territory()
		{
			ClassOfTradeCode = "P3",
			GeneralTerritoryCode = "O",
			FreeFormMessageText = "Z",
			CountryCode = "YC",
			PercentageAsDecimal = 4,
			FreeFormMessageText2 = "3",
		};

		var actual = Map.MapObject<TER_Territory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P3", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new TER_Territory();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
