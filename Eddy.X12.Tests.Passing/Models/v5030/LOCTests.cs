using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOC*Qn*h*0*z*z*jQ*c*y*s*3**2**4**4**9**5**fD*B*5";

		var expected = new LOC_Location()
		{
			ReferenceIdentificationQualifier = "Qn",
			ReferenceIdentification = "h",
			Description = "0",
			ReferenceIdentification2 = "z",
			Category = "z",
			ReferenceIdentificationQualifier2 = "jQ",
			ReferenceIdentification3 = "c",
			Description2 = "y",
			ReferenceIdentification4 = "s",
			MeasurementValue = 3,
			CompositeUnitOfMeasure = null,
			MeasurementValue2 = 2,
			CompositeUnitOfMeasure2 = null,
			MeasurementValue3 = 4,
			CompositeUnitOfMeasure3 = null,
			MeasurementValue4 = 4,
			CompositeUnitOfMeasure4 = null,
			MeasurementValue5 = 9,
			CompositeUnitOfMeasure5 = null,
			MeasurementValue6 = 5,
			CompositeUnitOfMeasure6 = null,
			ReferenceIdentificationQualifier3 = "fD",
			ReferenceIdentification5 = "B",
			Description3 = "5",
		};

		var actual = Map.MapObject<LOC_Location>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qn", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentification = "h";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "jQ";
			subject.ReferenceIdentification3 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "fD";
			subject.ReferenceIdentification5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Qn";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "jQ";
			subject.ReferenceIdentification3 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "fD";
			subject.ReferenceIdentification5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jQ", "c", true)]
	[InlineData("jQ", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Qn";
		subject.ReferenceIdentification = "h";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification5))
		{
			subject.ReferenceIdentificationQualifier3 = "fD";
			subject.ReferenceIdentification5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fD", "B", true)]
	[InlineData("fD", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Qn";
		subject.ReferenceIdentification = "h";
		//Test Parameters
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification5 = referenceIdentification5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier2 = "jQ";
			subject.ReferenceIdentification3 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
