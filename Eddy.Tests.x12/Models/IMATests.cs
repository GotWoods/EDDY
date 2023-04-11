using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMA*f*K5*F*H*bX";

		var expected = new IMA_InterchangeMoveAuthority()
		{
			MovementAuthorityCode = "f",
			StandardCarrierAlphaCode = "K5",
			TariffApplicationCode = "F",
			TariffApplicationCode2 = "H",
			RejectReasonCode = "bX",
		};

		var actual = Map.MapObject<IMA_InterchangeMoveAuthority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredMovementAuthorityCode(string movementAuthorityCode, bool isValidExpected)
	{
		var subject = new IMA_InterchangeMoveAuthority();
		subject.MovementAuthorityCode = movementAuthorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
