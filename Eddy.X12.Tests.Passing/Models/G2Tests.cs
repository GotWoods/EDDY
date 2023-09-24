using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G2*B*i";

		var expected = new G2_BeyondRouting()
		{
			SpecialIndicatorCode = "B",
			Description = "i",
		};

		var actual = Map.MapObject<G2_BeyondRouting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredSpecialIndicatorCode(string specialIndicatorCode, bool isValidExpected)
	{
		var subject = new G2_BeyondRouting();
		subject.SpecialIndicatorCode = specialIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
