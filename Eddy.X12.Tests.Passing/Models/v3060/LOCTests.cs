using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOC*yG*x*u*w*k*JX*s*B*K*4**2**9**5**1**6**yR*U*y";

		var expected = new LOC_Location()
		{
			ReferenceIdentificationQualifier = "yG",
			ReferenceIdentification = "x",
			Description = "u",
			ReferenceIdentification2 = "w",
			Category = "k",
			ReferenceIdentificationQualifier2 = "JX",
			ReferenceIdentification3 = "s",
			Description2 = "B",
			ReferenceIdentification4 = "K",
			MeasurementValue = 4,
			CompositeUnitOfMeasure = null,
			MeasurementValue2 = 2,
			CompositeUnitOfMeasure2 = null,
			MeasurementValue3 = 9,
			CompositeUnitOfMeasure3 = null,
			MeasurementValue4 = 5,
			CompositeUnitOfMeasure4 = null,
			MeasurementValue5 = 1,
			CompositeUnitOfMeasure5 = null,
			MeasurementValue6 = 6,
			CompositeUnitOfMeasure6 = null,
			ReferenceIdentificationQualifier3 = "yR",
			ReferenceIdentification5 = "U",
			Description3 = "y",
		};

		var actual = Map.MapObject<LOC_Location>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yG", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentification = "x";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "JX";
			subject.ReferenceIdentification3 = "s";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "yR";
			subject.ReferenceIdentification5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "yG";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "JX";
			subject.ReferenceIdentification3 = "s";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "yR";
			subject.ReferenceIdentification5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JX", "s", true)]
	[InlineData("JX", "", false)]
	[InlineData("", "s", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "yG";
		subject.ReferenceIdentification = "x";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "yR";
			subject.ReferenceIdentification5 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yR", "U", true)]
	[InlineData("yR", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "yG";
		subject.ReferenceIdentification = "x";
		//Test Parameters
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification5 = referenceIdentification5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "JX";
			subject.ReferenceIdentification3 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
