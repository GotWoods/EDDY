using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RECTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REC*Fz*X5*c*m*7*IT*f*e4*3**hp*qtO*s";

		var expected = new REC_RealEstateCondition()
		{
			OccupancyCode = "Fz",
			RealEstatePropertyConditionCode = "X5",
			PropertyDamageCode = "c",
			YesNoConditionOrResponseCode = "m",
			Quantity = 7,
			PropertyInspectionQualifier = "IT",
			ActionCode = "f",
			QuantityQualifier = "e4",
			Quantity2 = 3,
			CompositeUnitOfMeasure = null,
			OccupancyVerificationCode = "hp",
			NoteReferenceCode = "qtO",
			FreeFormMessage = "s",
		};

		var actual = Map.MapObject<REC_RealEstateCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fz", true)]
	public void Validation_RequiredOccupancyCode(string occupancyCode, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		//Required fields
		//Test Parameters
		subject.OccupancyCode = occupancyCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier = "e4";
			subject.Quantity2 = 3;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.PropertyInspectionQualifier) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Quantity2 > 0 || subject.QuantityQualifier != null || !string.IsNullOrEmpty(subject.NoteReferenceCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.QuantityQualifier = "e4";
			subject.PropertyInspectionQualifier = "IT";
			subject.ActionCode = "f";
			subject.Quantity2 = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.NoteReferenceCode = "qtO";
			subject.FreeFormMessage = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IT", "X5", true)]
	[InlineData("IT", "", false)]
	[InlineData("", "X5", true)]
	public void Validation_ARequiresBPropertyInspectionQualifier(string propertyInspectionQualifier, string realEstatePropertyConditionCode, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		//Required fields
		subject.OccupancyCode = "Fz";
		//Test Parameters
		subject.PropertyInspectionQualifier = propertyInspectionQualifier;
		subject.RealEstatePropertyConditionCode = realEstatePropertyConditionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier = "e4";
			subject.Quantity2 = 3;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Quantity2 > 0 || subject.QuantityQualifier != null || !string.IsNullOrEmpty(subject.NoteReferenceCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.QuantityQualifier = "e4";
			subject.ActionCode = "f";
			subject.Quantity2 = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.NoteReferenceCode = "qtO";
			subject.FreeFormMessage = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e4", 3, true)]
	[InlineData("e4", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity2, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		//Required fields
		subject.OccupancyCode = "Fz";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//A Requires B
        if (quantity2 > 0)
        {
            subject.PropertyInspectionQualifier = "IT";
            subject.RealEstatePropertyConditionCode = "TT";
        }

        if (subject.QuantityQualifier != "")
        {
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        }



        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", 0, "", "", "", true)]
	[InlineData("e4", "IT", "f", 3, "A", "qtO", "s", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_QuantityQualifier(string quantityQualifier, string propertyInspectionQualifier, string actionCode, decimal quantity2, string compositeUnitOfMeasure, string noteReferenceCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		//Required fields
		subject.OccupancyCode = "Fz";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		subject.PropertyInspectionQualifier = propertyInspectionQualifier;
		subject.ActionCode = actionCode;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.NoteReferenceCode = noteReferenceCode;
		subject.FreeFormMessage = freeFormMessage;
		//A Requires B
		if (propertyInspectionQualifier != "")
			subject.RealEstatePropertyConditionCode = "X5";
		if (quantity2 > 0)
			subject.PropertyInspectionQualifier = "IT";
		if (noteReferenceCode != "")
			subject.FreeFormMessage = "s";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "IT", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "IT", true)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string propertyInspectionQualifier, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		//Required fields
		subject.OccupancyCode = "Fz";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		subject.PropertyInspectionQualifier = propertyInspectionQualifier;
		//A Requires B
		if (propertyInspectionQualifier != "")
			subject.RealEstatePropertyConditionCode = "X5";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier = "e4";
			subject.Quantity2 = 3;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.ActionCode) || subject.QuantityQualifier != null || !string.IsNullOrEmpty(subject.NoteReferenceCode) || !string.IsNullOrEmpty(subject.FreeFormMessage))
		{
			subject.QuantityQualifier = "e4";
			subject.ActionCode = "f";
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
			subject.NoteReferenceCode = "qtO";
			subject.FreeFormMessage = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qtO", "s", true)]
	[InlineData("qtO", "", false)]
	[InlineData("", "s", true)]
	public void Validation_ARequiresBNoteReferenceCode(string noteReferenceCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		//Required fields
		subject.OccupancyCode = "Fz";
		//Test Parameters
		subject.NoteReferenceCode = noteReferenceCode;
		subject.FreeFormMessage = freeFormMessage;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity2 > 0)
		{
			subject.QuantityQualifier = "e4";
			subject.Quantity2 = 3;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.PropertyInspectionQualifier) || !string.IsNullOrEmpty(subject.ActionCode) || subject.Quantity2 > 0 || subject.QuantityQualifier != null)
		{
			subject.QuantityQualifier = "e4";
			subject.PropertyInspectionQualifier = "IT";
			subject.ActionCode = "f";
			subject.Quantity2 = 3;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
