using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Tests.Models.v4030.Composites;

public class C040Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "ve*o*hj*o*dl*o";

		var expected = new C040_ReferenceIdentifier()
		{
			ReferenceIdentificationQualifier = "ve",
			ReferenceIdentification = "o",
			ReferenceIdentificationQualifier2 = "hj",
			ReferenceIdentification2 = "o",
			ReferenceIdentificationQualifier3 = "dl",
			ReferenceIdentification3 = "o",
		};

		var actual = Map.MapObject<C040_ReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ve", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "hj";
			subject.ReferenceIdentification2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "dl";
			subject.ReferenceIdentification3 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentificationQualifier = "ve";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "hj";
			subject.ReferenceIdentification2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "dl";
			subject.ReferenceIdentification3 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hj", "o", true)]
	[InlineData("hj", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentificationQualifier = "ve";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "dl";
			subject.ReferenceIdentification3 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dl", "o", true)]
	[InlineData("dl", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentificationQualifier = "ve";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "hj";
			subject.ReferenceIdentification2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
