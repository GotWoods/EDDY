using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOC*qG*H*5*h*F*tv*c*Q*K*8**9**3**5**9**4**Fu*l*B";

		var expected = new LOC_Location()
		{
			ReferenceNumberQualifier = "qG",
			ReferenceNumber = "H",
			Description = "5",
			ReferenceNumber2 = "h",
			Category = "F",
			ReferenceNumberQualifier2 = "tv",
			ReferenceNumber3 = "c",
			Description2 = "Q",
			ReferenceNumber4 = "K",
			MeasurementValue = 8,
			CompositeUnitOfMeasure = null,
			MeasurementValue2 = 9,
			CompositeUnitOfMeasure2 = null,
			MeasurementValue3 = 3,
			CompositeUnitOfMeasure3 = null,
			MeasurementValue4 = 5,
			CompositeUnitOfMeasure4 = null,
			MeasurementValue5 = 9,
			CompositeUnitOfMeasure5 = null,
			MeasurementValue6 = 4,
			CompositeUnitOfMeasure6 = null,
			ReferenceNumberQualifier3 = "Fu",
			ReferenceNumber5 = "l",
			Description3 = "B",
		};

		var actual = Map.MapObject<LOC_Location>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qG", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumber = "H";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "tv";
			subject.ReferenceNumber3 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "Fu";
			subject.ReferenceNumber5 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "qG";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "tv";
			subject.ReferenceNumber3 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "Fu";
			subject.ReferenceNumber5 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tv", "c", true)]
	[InlineData("tv", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "qG";
		subject.ReferenceNumber = "H";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber3 = referenceNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "Fu";
			subject.ReferenceNumber5 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fu", "l", true)]
	[InlineData("Fu", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier3(string referenceNumberQualifier3, string referenceNumber5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "qG";
		subject.ReferenceNumber = "H";
		//Test Parameters
		subject.ReferenceNumberQualifier3 = referenceNumberQualifier3;
		subject.ReferenceNumber5 = referenceNumber5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "tv";
			subject.ReferenceNumber3 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
