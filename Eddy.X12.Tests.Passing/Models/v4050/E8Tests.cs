using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class E8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E8*A*R";

		var expected = new E8_BlockingAndResponseInformation()
		{
			BlockIdentification = "A",
			MovementAuthorityCode = "R",
		};

		var actual = Map.MapObject<E8_BlockingAndResponseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("A", "R", true)]
	[InlineData("A", "", true)]
	[InlineData("", "R", true)]
	public void Validation_AtLeastOneBlockIdentification(string blockIdentification, string movementAuthorityCode, bool isValidExpected)
	{
		var subject = new E8_BlockingAndResponseInformation();
		subject.BlockIdentification = blockIdentification;
		subject.MovementAuthorityCode = movementAuthorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
