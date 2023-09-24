using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFR*3*k*3*1";

		var expected = new TFR_TariffRestrictions()
		{
			TariffRestrictionIDCode = "3",
			TariffRestrictionDescription = "k",
			TariffRestrictionValue = 3,
			TariffRestrictionValue2 = 1,
		};

		var actual = Map.MapObject<TFR_TariffRestrictions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredTariffRestrictionIDCode(string tariffRestrictionIDCode, bool isValidExpected)
	{
		var subject = new TFR_TariffRestrictions();
		subject.TariffRestrictionIDCode = tariffRestrictionIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
