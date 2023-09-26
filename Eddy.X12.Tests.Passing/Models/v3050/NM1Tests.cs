using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*2n*9*2*o*x*X*X*F*cy";

		var expected = new NM1_IndividualOrOrganizationalName()
		{
			EntityIdentifierCode = "2n",
			EntityTypeQualifier = "9",
			NameLastOrOrganizationName = "2",
			NameFirst = "o",
			NameMiddle = "x",
			NamePrefix = "X",
			NameSuffix = "X",
			IdentificationCodeQualifier = "F",
			IdentificationCode = "cy",
		};

		var actual = Map.MapObject<NM1_IndividualOrOrganizationalName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2n", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityTypeQualifier = "9";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "F";
			subject.IdentificationCode = "cy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "2n";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "F";
			subject.IdentificationCode = "cy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "cy", true)]
	[InlineData("F", "", false)]
	[InlineData("", "cy", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "2n";
		subject.EntityTypeQualifier = "9";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
