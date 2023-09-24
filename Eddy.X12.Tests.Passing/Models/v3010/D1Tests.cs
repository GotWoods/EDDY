using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D1*cr*4*1V*Jh";

		var expected = new D1_ConsigneeName()
		{
			Name30CharacterFormat = "cr",
			IdentificationCodeQualifier = "4",
			IdentificationCode = "1V",
			EntityIdentifierCode = "Jh",
		};

		var actual = Map.MapObject<D1_ConsigneeName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cr", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new D1_ConsigneeName();
		//Required fields
		//Test Parameters
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
