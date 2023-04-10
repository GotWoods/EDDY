using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class E8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E8*z*R";

		var expected = new E8_BlockingAndResponseInformation()
		{
			BlockIdentifier = "z",
			MovementAuthorityCode = "R",
		};

		var actual = Map.MapObject<E8_BlockingAndResponseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("z","R", true)]
	[InlineData("", "R", true)]
	[InlineData("z", "", true)]
	public void Validation_AtLeastOneBlockIdentifier(string blockIdentifier, string movementAuthorityCode, bool isValidExpected)
	{
		var subject = new E8_BlockingAndResponseInformation();
		subject.BlockIdentifier = blockIdentifier;
		subject.MovementAuthorityCode = movementAuthorityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
