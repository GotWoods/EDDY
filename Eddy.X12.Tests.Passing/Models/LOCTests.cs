using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOC*vJ*6*w*9*T*Iu*2*j*l*8**4**5**4**3**5**g3*L*i";

		var expected = new LOC_Location()
		{
			ReferenceIdentificationQualifier = "vJ",
			ReferenceIdentification = "6",
			Description = "w",
			ReferenceIdentification2 = "9",
			Category = "T",
			ReferenceIdentificationQualifier2 = "Iu",
			ReferenceIdentification3 = "2",
			Description2 = "j",
			ReferenceIdentification4 = "l",
			MeasurementValue = 8,
			CompositeUnitOfMeasure = null,
			MeasurementValue2 = 4,
			CompositeUnitOfMeasure2 = null,
			MeasurementValue3 = 5,
			CompositeUnitOfMeasure3 = null,
			MeasurementValue4 = 4,
			CompositeUnitOfMeasure4 = null,
			MeasurementValue5 = 3,
			CompositeUnitOfMeasure5 = null,
			MeasurementValue6 = 5,
			CompositeUnitOfMeasure6 = null,
			ReferenceIdentificationQualifier3 = "g3",
			ReferenceIdentification5 = "L",
			Description3 = "i",
		};

		var actual = Map.MapObject<LOC_Location>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vJ", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LOC_Location();
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LOC_Location();
		subject.ReferenceIdentificationQualifier = "vJ";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Iu", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("Iu", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		subject.ReferenceIdentificationQualifier = "vJ";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification3 = referenceIdentification3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("g3", "L", true)]
	[InlineData("", "L", false)]
	[InlineData("g3", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		subject.ReferenceIdentificationQualifier = "vJ";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification5 = referenceIdentification5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
