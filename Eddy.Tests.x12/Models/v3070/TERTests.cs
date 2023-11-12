using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TER*H2*m*7*QP*6";

		var expected = new TER_Territory()
		{
			ClassOfTradeCode = "H2",
			GeneralTerritoryCode = "m",
			FreeFormMessageText = "7",
			CountryCode = "QP",
			Percent = 6,
		};

		var actual = Map.MapObject<TER_Territory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H2", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new TER_Territory();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
