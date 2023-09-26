using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class IMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMA*n*xI*vV*7*Z";

		var expected = new IMA_InterchangeMoveAuthority()
		{
			MovementAuthorityCode = "n",
			SpecialHandlingDescription = "xI",
			StandardCarrierAlphaCode = "vV",
			TariffApplicationCode = "7",
			TariffApplicationCode2 = "Z",
		};

		var actual = Map.MapObject<IMA_InterchangeMoveAuthority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredMovementAuthorityCode(string movementAuthorityCode, bool isValidExpected)
	{
		var subject = new IMA_InterchangeMoveAuthority();
		//Required fields
		//Test Parameters
		subject.MovementAuthorityCode = movementAuthorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
