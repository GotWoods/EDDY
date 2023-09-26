using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class IN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN1*r*hD*Z4*a6*m*rV*EN";

		var expected = new IN1_IndividualIdentification()
		{
			EntityTypeQualifier = "r",
			NameTypeCode = "hD",
			EntityIdentifierCode = "Z4",
			ReferenceIdentificationQualifier = "a6",
			ReferenceIdentification = "m",
			IndividualRelationshipCode = "rV",
			LevelOfIndividualTestOrCourseCode = "EN",
		};

		var actual = Map.MapObject<IN1_IndividualIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.NameTypeCode = "hD";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "a6";
			subject.ReferenceIdentification = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hD", true)]
	public void Validation_RequiredNameTypeCode(string nameTypeCode, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "r";
		//Test Parameters
		subject.NameTypeCode = nameTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "a6";
			subject.ReferenceIdentification = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a6", "m", true)]
	[InlineData("a6", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "r";
		subject.NameTypeCode = "hD";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
