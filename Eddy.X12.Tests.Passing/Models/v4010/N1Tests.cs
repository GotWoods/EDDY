using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class N1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N1*gk*P*i*ec*4M*bp";

		var expected = new N1_Name()
		{
			EntityIdentifierCode = "gk",
			Name = "P",
			IdentificationCodeQualifier = "i",
			IdentificationCode = "ec",
			EntityRelationshipCode = "4M",
			EntityIdentifierCode2 = "bp",
		};

		var actual = Map.MapObject<N1_Name>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gk", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = entityIdentifierCode;
			subject.Name = "P";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "ec";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("P", "i", true)]
	[InlineData("P", "", true)]
	[InlineData("", "i", true)]
	public void Validation_AtLeastOneName(string name, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "gk";
		subject.Name = name;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "ec";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "ec", true)]
	[InlineData("i", "", false)]
	[InlineData("", "ec", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "gk";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
			subject.Name = "P";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
