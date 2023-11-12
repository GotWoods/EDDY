using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TER*Kp*M*q*QA*3*H";

		var expected = new TER_Territory()
		{
			ClassOfTradeCode = "Kp",
			GeneralTerritoryCode = "M",
			FreeFormMessageText = "q",
			CountryCode = "QA",
			Percent = 3,
			FreeFormMessageText2 = "H",
		};

		var actual = Map.MapObject<TER_Territory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kp", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new TER_Territory();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
