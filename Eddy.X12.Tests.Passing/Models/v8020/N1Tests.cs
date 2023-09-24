using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class N1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N1*mw*p*f*FT*nz*zH*";

		var expected = new N1_PartyIdentification()
		{
			EntityIdentifierCode = "mw",
			Name = "p",
			IdentificationCodeQualifier = "f",
			IdentificationCode = "FT",
			EntityRelationshipCode = "nz",
			EntityIdentifierCode2 = "zH",
			CompositeIdentificationCodes = null,
		};

		var actual = Map.MapObject<N1_PartyIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mw", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new N1_PartyIdentification();
		subject.EntityIdentifierCode = entityIdentifierCode;
			subject.Name = "p";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "f";
			subject.IdentificationCode = "FT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("p", "f", true)]
	[InlineData("p", "", true)]
	[InlineData("", "f", true)]
	public void Validation_AtLeastOneName(string name, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new N1_PartyIdentification();
		subject.EntityIdentifierCode = "mw";
		subject.Name = name;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "f";
			subject.IdentificationCode = "FT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "FT", true)]
	[InlineData("f", "", false)]
	[InlineData("", "FT", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new N1_PartyIdentification();
		subject.EntityIdentifierCode = "mw";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
			subject.Name = "p";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
