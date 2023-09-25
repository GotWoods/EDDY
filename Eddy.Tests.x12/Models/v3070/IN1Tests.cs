using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class IN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN1*j*qs*ba*h4*T*P5*dB";

		var expected = new IN1_IndividualIdentification()
		{
			EntityTypeQualifier = "j",
			NameTypeCode = "qs",
			EntityIdentifierCode = "ba",
			ReferenceIdentificationQualifier = "h4",
			ReferenceIdentification = "T",
			IndividualRelationshipCode = "P5",
			LevelOfIndividualTestOrCourseCode = "dB",
		};

		var actual = Map.MapObject<IN1_IndividualIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.NameTypeCode = "qs";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qs", true)]
	public void Validation_RequiredNameTypeCode(string nameTypeCode, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "j";
		//Test Parameters
		subject.NameTypeCode = nameTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h4", "T", true)]
	[InlineData("h4", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "j";
		subject.NameTypeCode = "qs";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
