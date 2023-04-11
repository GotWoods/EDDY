using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN1*B*Rx*4r*uh*A*bi*iB";

		var expected = new IN1_IndividualIdentification()
		{
			EntityTypeQualifier = "B",
			NameTypeCode = "Rx",
			EntityIdentifierCode = "4r",
			ReferenceIdentificationQualifier = "uh",
			ReferenceIdentification = "A",
			IndividualRelationshipCode = "bi",
			LevelOfIndividualTestOrCourseCode = "iB",
		};

		var actual = Map.MapObject<IN1_IndividualIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		subject.NameTypeCode = "Rx";
		subject.EntityTypeQualifier = entityTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rx", true)]
	public void Validation_RequiredNameTypeCode(string nameTypeCode, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		subject.EntityTypeQualifier = "B";
		subject.NameTypeCode = nameTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("uh", "A", true)]
	[InlineData("", "A", false)]
	[InlineData("uh", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		subject.EntityTypeQualifier = "B";
		subject.NameTypeCode = "Rx";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
