using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E1*ya*Q*N4";

		var expected = new E1_EmptyCarDispositionPendedDestinationConsignee()
		{
			Name30CharacterFormat = "ya",
			IdentificationCodeQualifier = "Q",
			IdentificationCode = "N4",
		};

		var actual = Map.MapObject<E1_EmptyCarDispositionPendedDestinationConsignee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ya", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new E1_EmptyCarDispositionPendedDestinationConsignee();
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
