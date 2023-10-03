using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5030;
using Eddy.x12.Models.v5030.Composites;

namespace Eddy.x12.Tests.Models.v5030.Composites;

public class C040Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Y1*w*Py*R*JS*b";

		var expected = new C040_ReferenceIdentifier()
		{
			ReferenceIdentificationQualifier = "Y1",
			ReferenceIdentification = "w",
			ReferenceIdentificationQualifier2 = "Py",
			ReferenceIdentification2 = "R",
			ReferenceIdentificationQualifier3 = "JS",
			ReferenceIdentification3 = "b",
		};

		var actual = Map.MapObject<C040_ReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y1", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentification = "w";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Py";
			subject.ReferenceIdentification2 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "JS";
			subject.ReferenceIdentification3 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Y1";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Py";
			subject.ReferenceIdentification2 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "JS";
			subject.ReferenceIdentification3 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Py", "R", true)]
	[InlineData("Py", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Y1";
		subject.ReferenceIdentification = "w";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "JS";
			subject.ReferenceIdentification3 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JS", "b", true)]
	[InlineData("JS", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new C040_ReferenceIdentifier();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Y1";
		subject.ReferenceIdentification = "w";
		//Test Parameters
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Py";
			subject.ReferenceIdentification2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
