using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SV7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV7*X*b*4V*LsA*st*I";

		var expected = new SV7_DrugAdjudication()
		{
			ReferenceIdentification = "X",
			ReferenceIdentification2 = "b",
			PrescriptionDenialOverrideCode = "4V",
			CoverageLevelCode = "LsA",
			ProductProcessCharacteristicCode = "st",
			YesNoConditionOrResponseCode = "I",
		};

		var actual = Map.MapObject<SV7_DrugAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LsA", true)]
	public void Validation_RequiredCoverageLevelCode(string coverageLevelCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.ProductProcessCharacteristicCode = "st";
		//Test Parameters
		subject.CoverageLevelCode = coverageLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("st", true)]
	public void Validation_RequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.CoverageLevelCode = "LsA";
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
