using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class IN1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IN1*K*tq*3w*s0*H*68";

		var expected = new IN1_IndividualIdentification()
		{
			EntityTypeQualifier = "K",
			NameTypeCode = "tq",
			EntityIdentifierCode = "3w",
			ReferenceNumberQualifier = "s0",
			ReferenceNumber = "H",
			IndividualRelationshipCode = "68",
		};

		var actual = Map.MapObject<IN1_IndividualIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredEntityTypeQualifier(string entityTypeQualifier, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.NameTypeCode = "tq";
		//Test Parameters
		subject.EntityTypeQualifier = entityTypeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "s0";
			subject.ReferenceNumber = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tq", true)]
	public void Validation_RequiredNameTypeCode(string nameTypeCode, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "K";
		//Test Parameters
		subject.NameTypeCode = nameTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "s0";
			subject.ReferenceNumber = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s0", "H", true)]
	[InlineData("s0", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new IN1_IndividualIdentification();
		//Required fields
		subject.EntityTypeQualifier = "K";
		subject.NameTypeCode = "tq";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
