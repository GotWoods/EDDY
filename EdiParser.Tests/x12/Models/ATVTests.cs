using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ATVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ATV*7*a*J*9*9**BC*6*P*S";

		var expected = new ATV_StudentActivitiesAndAwards()
		{
			CodeListQualifierCode = "7",
			IndustryCode = "a",
			EntityTitle = "J",
			EntityTitle2 = "9",
			Quantity = 9,
			//CompositeUnitOfMeasure = "",
			LevelOfIndividualTestOrCourseCode = "BC",
			YesNoConditionOrResponseCode = "6",
			YesNoConditionOrResponseCode2 = "P",
			YesNoConditionOrResponseCode3 = "S",
		};

		var actual = Map.MapObject<ATV_StudentActivitiesAndAwards>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("7", "a", true)]
	[InlineData("", "a", false)]
	[InlineData("7", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new ATV_StudentActivitiesAndAwards();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}


	//TODO: composite type
	// [Theory]
	// [InlineData(0,"", true)]
	// [InlineData(9, "", true)]
	// [InlineData(0, "", false)]
	// [InlineData(9, "", false)]
	// public void Validation_AllAreRequiredQuantity(decimal quantity, C001_CompositeUnitOfMeasure compositeUnitOfMeasure, bool isValidExpected)
	// {
	// 	var subject = new ATV_StudentActivitiesAndAwards();
	// 	if (quantity > 0)
	// 	subject.Quantity = quantity;
	// 	subject.CompositeUnitOfMeasure = compositeUnitOfMeasure;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	// }

}
