using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOC*zs*Z*w*S*X*hH*M*L*T*5**4**9**4**9**5**Ej*m*v";

		var expected = new LOC_Location()
		{
			ReferenceIdentificationQualifier = "zs",
			ReferenceIdentification = "Z",
			Description = "w",
			ReferenceIdentification2 = "S",
			Category = "X",
			ReferenceIdentificationQualifier2 = "hH",
			ReferenceIdentification3 = "M",
			Description2 = "L",
			ReferenceIdentification4 = "T",
			MeasurementValue = 5,
			CompositeUnitOfMeasure = null,
			MeasurementValue2 = 4,
			CompositeUnitOfMeasure2 = null,
			MeasurementValue3 = 9,
			CompositeUnitOfMeasure3 = null,
			MeasurementValue4 = 4,
			CompositeUnitOfMeasure4 = null,
			MeasurementValue5 = 9,
			CompositeUnitOfMeasure5 = null,
			MeasurementValue6 = 5,
			CompositeUnitOfMeasure6 = null,
			ReferenceIdentificationQualifier3 = "Ej",
			ReferenceIdentification5 = "m",
			Description3 = "v",
		};

		var actual = Map.MapObject<LOC_Location>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zs", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentification = "Z";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "hH";
			subject.ReferenceIdentification3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "Ej";
			subject.ReferenceIdentification5 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "zs";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "hH";
			subject.ReferenceIdentification3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "Ej";
			subject.ReferenceIdentification5 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hH", "M", true)]
	[InlineData("hH", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "zs";
		subject.ReferenceIdentification = "Z";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "Ej";
			subject.ReferenceIdentification5 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ej", "m", true)]
	[InlineData("Ej", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "zs";
		subject.ReferenceIdentification = "Z";
		//Test Parameters
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification5 = referenceIdentification5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "hH";
			subject.ReferenceIdentification3 = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
