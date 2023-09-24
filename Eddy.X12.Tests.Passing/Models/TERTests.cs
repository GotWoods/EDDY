using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TER*Kx*c*Y*MC*8*S";

		var expected = new TER_Territory()
		{
			ClassOfTradeCode = "Kx",
			GeneralTerritoryCode = "c",
			FreeFormMessageText = "Y",
			CountryCode = "MC",
			PercentageAsDecimal = 8,
			FreeFormMessageText2 = "S",
		};

		var actual = Map.MapObject<TER_Territory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kx", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new TER_Territory();
		subject.ClassOfTradeCode = classOfTradeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
