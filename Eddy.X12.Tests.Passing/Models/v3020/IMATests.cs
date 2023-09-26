using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class IMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMA*v*pQ";

		var expected = new IMA_InterchangeMoveAuthority()
		{
			MovementAuthorityCode = "v",
			SpecialHandlingDescription = "pQ",
		};

		var actual = Map.MapObject<IMA_InterchangeMoveAuthority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "pQ", false)]
	[InlineData("v", "", true)]
	[InlineData("", "pQ", true)]
	public void Validation_OnlyOneOfMovementAuthorityCode(string movementAuthorityCode, string specialHandlingDescription, bool isValidExpected)
	{
		var subject = new IMA_InterchangeMoveAuthority();
		//Required fields
		//Test Parameters
		subject.MovementAuthorityCode = movementAuthorityCode;
		subject.SpecialHandlingDescription = specialHandlingDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
