using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN1*t*Lj*uH*yF*L*70*HK";

		var expected = new IN1_IndividualIdentification()
		{
			EntityTypeQualifier = "t",
			NameTypeCode = "Lj",
			EntityIdentifierCode = "uH",
			ReferenceNumberQualifier = "yF",
			ReferenceNumber = "L",
			IndividualRelationshipCode = "70",
			LevelOfIndividualOrTestCode = "HK",
		};

		var actual = Map.MapObject<IN1_IndividualIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.NameTypeCode = "Lj";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "yF";
			subject.ReferenceNumber = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lj", true)]
	public void Validation_RequiredNameTypeCode(string nameTypeCode, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "t";
		//Test Parameters
		subject.NameTypeCode = nameTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "yF";
			subject.ReferenceNumber = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yF", "L", true)]
	[InlineData("yF", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "t";
		subject.NameTypeCode = "Lj";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
