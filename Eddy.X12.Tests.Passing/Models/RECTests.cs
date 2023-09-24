using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class RECTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REC*Vj*xz*5*h*6*RO*u*MK*5**6n*9c2*R";

		var expected = new REC_RealEstateCondition()
		{
			OccupancyCode = "Vj",
			RealEstatePropertyConditionCode = "xz",
			PropertyDamageCode = "5",
			YesNoConditionOrResponseCode = "h",
			Quantity = 6,
			PropertyInspectionQualifier = "RO",
			ActionCode = "u",
			QuantityQualifier = "MK",
			Quantity2 = 5,
			CompositeUnitOfMeasure = null,
			OccupancyVerificationCode = "6n",
			NoteReferenceCode = "9c2",
			FreeFormMessage = "R",
		};

		var actual = Map.MapObject<REC_RealEstateCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vj", true)]
	public void Validation_RequiredOccupancyCode(string occupancyCode, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		subject.OccupancyCode = occupancyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "xz", true)]
	[InlineData("RO", "", false)]
	public void Validation_ARequiresBPropertyInspectionQualifier(string propertyInspectionQualifier, string realEstatePropertyConditionCode, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		subject.OccupancyCode = "Vj";
		subject.PropertyInspectionQualifier = propertyInspectionQualifier;
		subject.RealEstatePropertyConditionCode = realEstatePropertyConditionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("MK", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("MK", 0, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity2, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		subject.OccupancyCode = "Vj";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}


	//TODO: fix this test
	// [Theory]
	// [InlineData("","", true)]
	// [InlineData("MK", "RO", true)]
	// [InlineData("","RO", true)]
	// [InlineData("MK", "", true)]
	// public void Validation_IfOneSpecifiedThenOneMoreRequired_QuantityQualifier(string quantityQualifier, string propertyInspectionQualifier, string actionCode, decimal quantity2, string compositeUnitOfMeasure, string noteReferenceCode, string freeFormMessage, bool isValidExpected)
	// {
	// 	var subject = new REC_RealEstateCondition();
	// 	subject.OccupancyCode = "Vj";
	// 	subject.QuantityQualifier = quantityQualifier;
	// 	subject.PropertyInspectionQualifier = propertyInspectionQualifier;
	// 	subject.ActionCode = actionCode;
	// 	if (quantity2 > 0)
	// 	subject.Quantity2 = quantity2;
 //        if (compositeUnitOfMeasure != "")
 //            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
	// 	subject.NoteReferenceCode = noteReferenceCode;
	// 	subject.FreeFormMessage = freeFormMessage;
 //
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	// }

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "RO", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBQuantity2(decimal quantity2, string propertyInspectionQualifier, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		subject.OccupancyCode = "Vj";
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;
		subject.PropertyInspectionQualifier = propertyInspectionQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "R", true)]
	[InlineData("9c2", "", false)]
	public void Validation_ARequiresBNoteReferenceCode(string noteReferenceCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		subject.OccupancyCode = "Vj";
		subject.NoteReferenceCode = noteReferenceCode;
		subject.FreeFormMessage = freeFormMessage;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
