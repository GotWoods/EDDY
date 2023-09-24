using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class N1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N1*74*3*w*mB*MK*X8";

		var expected = new N1_Name()
		{
			EntityIdentifierCode = "74",
			Name = "3",
			IdentificationCodeQualifier = "w",
			IdentificationCode = "mB",
			EntityRelationshipCode = "MK",
			EntityIdentifierCode2 = "X8",
		};

		var actual = Map.MapObject<N1_Name>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("74", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = entityIdentifierCode;
			subject.Name = "3";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "w";
			subject.IdentificationCode = "mB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("3", "w", true)]
	[InlineData("3", "", true)]
	[InlineData("", "w", true)]
	public void Validation_AtLeastOneName(string name, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "74";
		subject.Name = name;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "w";
			subject.IdentificationCode = "mB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "mB", true)]
	[InlineData("w", "", false)]
	[InlineData("", "mB", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "74";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
			subject.Name = "3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
