using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.Tests.Models.v6020;

public class IMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMA*a*bl*u*l*7a";

		var expected = new IMA_InterchangeMoveAuthority()
		{
			MovementAuthorityCode = "a",
			StandardCarrierAlphaCode = "bl",
			TariffApplicationCode = "u",
			TariffApplicationCode2 = "l",
			RejectReasonCode = "7a",
		};

		var actual = Map.MapObject<IMA_InterchangeMoveAuthority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredMovementAuthorityCode(string movementAuthorityCode, bool isValidExpected)
	{
		var subject = new IMA_InterchangeMoveAuthority();
		//Required fields
		//Test Parameters
		subject.MovementAuthorityCode = movementAuthorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
