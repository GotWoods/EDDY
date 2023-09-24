using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F1*cH*E*Og*Mk";

		var expected = new F1_ConsignorName()
		{
			Name30CharacterFormat = "cH",
			IdentificationCodeQualifier = "E",
			IdentificationCode = "Og",
			EntityIdentifierCode = "Mk",
		};

		var actual = Map.MapObject<F1_ConsignorName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cH", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new F1_ConsignorName();
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
