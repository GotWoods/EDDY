using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*qF*B*M*p*k*6*z*t*AQ";

		var expected = new NM1_IndividualOrOrganizationalName()
		{
			EntityIdentifierCode = "qF",
			EntityTypeQualifier = "B",
			NameLastOrOrganizationName = "M",
			NameFirst = "p",
			NameMiddle = "k",
			NamePrefix = "6",
			NameSuffix = "z",
			IdentificationCodeQualifier = "t",
			IdentificationCode = "AQ",
		};

		var actual = Map.MapObject<NM1_IndividualOrOrganizationalName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qF", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityTypeQualifier = "B";
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "t";
			subject.IdentificationCode = "AQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "qF";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "t";
			subject.IdentificationCode = "AQ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "AQ", true)]
	[InlineData("t", "", false)]
	[InlineData("", "AQ", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualOrOrganizationalName();
		//Required fields
		subject.EntityIdentifierCode = "qF";
		subject.EntityTypeQualifier = "B";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
