using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SV7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV7*N*b*BD*p8r*26*H";

		var expected = new SV7_DrugAdjudication()
		{
			ReferenceIdentification = "N",
			ReferenceIdentification2 = "b",
			PrescriptionDenialOverrideCode = "BD",
			CoverageLevelCode = "p8r",
			ProductProcessCharacteristicCode = "26",
			YesNoConditionOrResponseCode = "H",
		};

		var actual = Map.MapObject<SV7_DrugAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p8r", true)]
	public void Validation_RequiredCoverageLevelCode(string coverageLevelCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.ProductProcessCharacteristicCode = "26";
		//Test Parameters
		subject.CoverageLevelCode = coverageLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("26", true)]
	public void Validation_RequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.CoverageLevelCode = "p8r";
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
