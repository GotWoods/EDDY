using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class N1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N1*OM*K*f*Rx*Oh*qU";

		var expected = new N1_Name()
		{
			EntityIdentifierCode = "OM",
			Name = "K",
			IdentificationCodeQualifier = "f",
			IdentificationCode = "Rx",
			EntityRelationshipCode = "Oh",
			EntityIdentifierCode2 = "qU",
		};

		var actual = Map.MapObject<N1_Name>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OM", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = entityIdentifierCode;
			subject.Name = "K";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "f";
			subject.IdentificationCode = "Rx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("K", "f", true)]
	[InlineData("K", "", true)]
	[InlineData("", "f", true)]
	public void Validation_AtLeastOneName(string name, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "OM";
		subject.Name = name;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "f";
			subject.IdentificationCode = "Rx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "Rx", true)]
	[InlineData("f", "", false)]
	[InlineData("", "Rx", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new N1_Name();
		subject.EntityIdentifierCode = "OM";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
			subject.Name = "K";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
