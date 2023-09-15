using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G2*d*D";

		var expected = new G2_BeyondRouting()
		{
			SpecialIndicatorCode = "d",
			BeyondRoutingDescription = "D",
		};

		var actual = Map.MapObject<G2_BeyondRouting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredSpecialIndicatorCode(string specialIndicatorCode, bool isValidExpected)
	{
		var subject = new G2_BeyondRouting();
		subject.SpecialIndicatorCode = specialIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
