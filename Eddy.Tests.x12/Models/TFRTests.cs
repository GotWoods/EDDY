using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFR*9*o*5*1";

		var expected = new TFR_TariffRestrictions()
		{
			TariffRestrictionIDCode = "9",
			TariffRestrictionDescription = "o",
			TariffRestrictionValue = 5,
			TariffRestrictionValue2 = 1,
		};

		var actual = Map.MapObject<TFR_TariffRestrictions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredTariffRestrictionIDCode(string tariffRestrictionIDCode, bool isValidExpected)
	{
		var subject = new TFR_TariffRestrictions();
		subject.TariffRestrictionIDCode = tariffRestrictionIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
