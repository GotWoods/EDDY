using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class E8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E8*s*C";

		var expected = new E8_BlockingAndResponseInformation()
		{
			BlockIdentifier = "s",
			MovementAuthorityCode = "C",
		};

		var actual = Map.MapObject<E8_BlockingAndResponseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("s", "C", true)]
	[InlineData("s", "", true)]
	[InlineData("", "C", true)]
	public void Validation_AtLeastOneBlockIdentifier(string blockIdentifier, string movementAuthorityCode, bool isValidExpected)
	{
		var subject = new E8_BlockingAndResponseInformation();
		subject.BlockIdentifier = blockIdentifier;
		subject.MovementAuthorityCode = movementAuthorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
