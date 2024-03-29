using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D5*4K*ck*9*r1";

		var expected = new D5_ConsigneesThirdParty()
		{
			EntityIdentifierCode = "4K",
			Name30CharacterFormat = "ck",
			IdentificationCodeQualifier = "9",
			IdentificationCode = "r1",
		};

		var actual = Map.MapObject<D5_ConsigneesThirdParty>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4K", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new D5_ConsigneesThirdParty();
		subject.Name30CharacterFormat = "ck";
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ck", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new D5_ConsigneesThirdParty();
		subject.EntityIdentifierCode = "4K";
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
