using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class U1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "U1*45*l*oq*xj";

		var expected = new U1_UltimateConsigneeName()
		{
			Name30CharacterFormat = "45",
			IdentificationCodeQualifier = "l",
			IdentificationCode = "oq",
			EntityIdentifierCode = "xj",
		};

		var actual = Map.MapObject<U1_UltimateConsigneeName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("45", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new U1_UltimateConsigneeName();
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
