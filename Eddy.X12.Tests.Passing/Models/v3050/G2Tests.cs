using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G2*H*E";

		var expected = new G2_BeyondRouting()
		{
			SpecialIndicatorCode = "H",
			Description = "E",
		};

		var actual = Map.MapObject<G2_BeyondRouting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredSpecialIndicatorCode(string specialIndicatorCode, bool isValidExpected)
	{
		var subject = new G2_BeyondRouting();
		subject.SpecialIndicatorCode = specialIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
