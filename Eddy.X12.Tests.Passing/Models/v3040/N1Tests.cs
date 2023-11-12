using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class N1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N1*cN*U*u*3l*Pc*Ow";

		var expected = new N1_Name()
		{
			EntityIdentifierCode = "cN",
			Name = "U",
			IdentificationCodeQualifier = "u",
			IdentificationCode = "3l",
			EntityRelationshipCode = "Pc",
			EntityIdentifierCode2 = "Ow",
		};

		var actual = Map.MapObject<N1_Name>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cN", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = entityIdentifierCode;
			subject.Name = "U";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "u";
			subject.IdentificationCode = "3l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("U", "u", true)]
	[InlineData("U", "", true)]
	[InlineData("", "u", true)]
	public void Validation_AtLeastOneName(string name, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "cN";
		subject.Name = name;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "u";
			subject.IdentificationCode = "3l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "3l", true)]
	[InlineData("u", "", false)]
	[InlineData("", "3l", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "cN";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
			subject.Name = "U";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
