using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCL*s*K*h*9*S*4*5U*z*z*6";

		var expected = new SCL_RateBasisScales()
		{
			RateBasisQualifier = "s",
			RateBasisNumber = "K",
			RateBasisNumber2 = "h",
			LocationQualifier = "9",
			LocationIdentifier = "S",
			LocationIdentifier2 = "4",
			StateOrProvinceCode = "5U",
			TariffAddOnFactor = "z",
			TariffClassAdjustmentReference = "z",
			TariffClassAdjustmentReference2 = "6",
		};

		var actual = Map.MapObject<SCL_RateBasisScales>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredRateBasisQualifier(string rateBasisQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = rateBasisQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
