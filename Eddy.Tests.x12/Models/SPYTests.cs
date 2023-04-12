using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPY*e*K*H";

		var expected = new SPY_ScopeOfPowerOfAttorney()
		{
			ActionCode = "e",
			ScopeOfPowerOfAttorneyIdentificationCode = "K",
			Description = "H",
		};

		var actual = Map.MapObject<SPY_ScopeOfPowerOfAttorney>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new SPY_ScopeOfPowerOfAttorney();
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
