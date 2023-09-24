using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class D1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D1*ZF*d*Gy*x1";

		var expected = new D1_ConsigneeName()
		{
			Name30CharacterFormat = "ZF",
			IdentificationCodeQualifier = "d",
			IdentificationCode = "Gy",
			EntityIdentifierCode = "x1",
		};

		var actual = Map.MapObject<D1_ConsigneeName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZF", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new D1_ConsigneeName();
		//Required fields
		//Test Parameters
		subject.Name30CharacterFormat = name30CharacterFormat;

        if (subject.Name30CharacterFormat != "")
            subject.IdentificationCodeQualifier = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("ZF", "d", true)]
	[InlineData("ZF", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string name30CharacterFormat, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new D1_ConsigneeName();
		//Test Parameters
		subject.Name30CharacterFormat = name30CharacterFormat;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
