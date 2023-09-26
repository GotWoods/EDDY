using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class SV7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV7*u*6*oB*3c9*pj*D*";

		var expected = new SV7_DrugAdjudication()
		{
			ReferenceIdentification = "u",
			ReferenceIdentification2 = "6",
			PrescriptionDenialOverrideCode = "oB",
			CoverageLevelCode = "3c9",
			ProductProcessCharacteristicCode = "pj",
			YesNoConditionOrResponseCode = "D",
			DrugUseReviewDUR = null,
		};

		var actual = Map.MapObject<SV7_DrugAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3c9", true)]
	public void Validation_RequiredCoverageLevelCode(string coverageLevelCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.ProductProcessCharacteristicCode = "pj";
		//Test Parameters
		subject.CoverageLevelCode = coverageLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pj", true)]
	public void Validation_RequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.CoverageLevelCode = "3c9";
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
