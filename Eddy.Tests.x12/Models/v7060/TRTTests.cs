using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class TRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRT*iQ*hy*o**e6*d*6*";

		var expected = new TRT_TradeItemType()
		{
			ClassOfTradeCode = "iQ",
			ReferenceIdentificationQualifier = "hy",
			ReferenceIdentification = "o",
			CompositeIngredientInformation = null,
			ReferenceIdentificationQualifier2 = "e6",
			ReferenceIdentification2 = "d",
			MeasurementValue = 6,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<TRT_TradeItemType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iQ", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "hy";
		subject.ReferenceIdentification = "o";
		subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "e6";
			subject.ReferenceIdentification2 = "d";
		}
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hy", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "iQ";
		subject.ReferenceIdentification = "o";
		subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "e6";
			subject.ReferenceIdentification2 = "d";
		}
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "iQ";
		subject.ReferenceIdentificationQualifier = "hy";
		subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "e6";
			subject.ReferenceIdentification2 = "d";
		}
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeIngredientInformation(string compositeIngredientInformation, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "iQ";
		subject.ReferenceIdentificationQualifier = "hy";
		subject.ReferenceIdentification = "o";
		//Test Parameters
		if (compositeIngredientInformation != "") 
			subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "e6";
			subject.ReferenceIdentification2 = "d";
		}
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e6", "d", true)]
	[InlineData("e6", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "iQ";
		subject.ReferenceIdentificationQualifier = "hy";
		subject.ReferenceIdentification = "o";
		subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(subject.MeasurementValue > 0 || subject.MeasurementValue > 0 || subject.MeasurementValue != null)
		{
			subject.MeasurementValue = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "A", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new TRT_TradeItemType();
		//Required fields
		subject.ClassOfTradeCode = "iQ";
		subject.ReferenceIdentificationQualifier = "hy";
		subject.ReferenceIdentification = "o";
		subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "e6";
			subject.ReferenceIdentification2 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
