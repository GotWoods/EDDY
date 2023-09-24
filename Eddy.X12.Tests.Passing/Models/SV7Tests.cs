using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SV7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV7*D*3*di*YKi*DO*S*";

		var expected = new SV7_DrugAdjudication()
		{
			ReferenceIdentification = "D",
			ReferenceIdentification2 = "3",
			PrescriptionDenialOverrideCode = "di",
			CoverageLevelCode = "YKi",
			ProductProcessCharacteristicCode = "DO",
			YesNoConditionOrResponseCode = "S",
			DrugUseReviewDUR = null,
		};

		var actual = Map.MapObject<SV7_DrugAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YKi", true)]
	public void Validation_RequiredCoverageLevelCode(string coverageLevelCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		subject.ProductProcessCharacteristicCode = "DO";
		subject.CoverageLevelCode = coverageLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DO", true)]
	public void Validation_RequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		subject.CoverageLevelCode = "YKi";
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
