using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G91Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G91*Q*12F";

		var expected = new G91_PriceChangeStatus()
		{
			ChangeTypeCode = "Q",
			PriceIdentifierCode = "12F",
		};

		var actual = Map.MapObject<G91_PriceChangeStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new G91_PriceChangeStatus();
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
