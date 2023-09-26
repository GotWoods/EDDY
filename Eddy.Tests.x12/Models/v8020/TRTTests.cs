using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class TRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRT*yt*xU*Y**en*T*5*";

		var expected = new TRT_TradeItemType()
		{
			ClassOfTradeCode = "yt",
			ReferenceIdentificationQualifier = "xU",
			ReferenceIdentification = "Y",
			CompositeIngredientInformation = null,
			ReferenceIdentificationQualifier2 = "en",
			ReferenceIdentification2 = "T",
			MeasurementValue = 5,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<TRT_TradeItemType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yt", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "xU";
		subject.ReferenceIdentification = "Y";
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "en";
			subject.ReferenceIdentification2 = "T";
		}
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 5;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xU", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "yt";
		subject.ReferenceIdentification = "Y";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "en";
			subject.ReferenceIdentification2 = "T";
		}
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 5;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "yt";
		subject.ReferenceIdentificationQualifier = "xU";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "en";
			subject.ReferenceIdentification2 = "T";
		}
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 5;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("en", "T", true)]
	[InlineData("en", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "yt";
		subject.ReferenceIdentificationQualifier = "xU";
		subject.ReferenceIdentification = "Y";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 5;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "A", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "yt";
		subject.ReferenceIdentificationQualifier = "xU";
		subject.ReferenceIdentification = "Y";
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "en";
			subject.ReferenceIdentification2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
