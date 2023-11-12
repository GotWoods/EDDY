using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class F10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F10*0BH7bnG2*p*7*a9";

		var expected = new F10_IdentificationOfClaimTracer()
		{
			Date = "0BH7bnG2",
			ReferenceIdentification = "p",
			ReferenceIdentification2 = "7",
			ReferenceIdentificationQualifier = "a9",
		};

		var actual = Map.MapObject<F10_IdentificationOfClaimTracer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0BH7bnG2", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.ReferenceIdentification = "p";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "7";
			subject.ReferenceIdentificationQualifier = "a9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "0BH7bnG2";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier))
		{
			subject.ReferenceIdentification2 = "7";
			subject.ReferenceIdentificationQualifier = "a9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "a9", true)]
	[InlineData("7", "", false)]
	[InlineData("", "a9", false)]
	public void Validation_AllAreRequiredReferenceIdentification2(string referenceIdentification2, string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new F10_IdentificationOfClaimTracer();
		subject.Date = "0BH7bnG2";
		subject.ReferenceIdentification = "p";
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
