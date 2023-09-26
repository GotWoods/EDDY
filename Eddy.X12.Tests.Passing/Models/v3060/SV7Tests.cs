using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SV7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV7*W*J*sY*IJy*9j*q";

		var expected = new SV7_DrugAdjudication()
		{
			ReferenceIdentification = "W",
			ReferenceIdentification2 = "J",
			PrescriptionDenialOverrideCode = "sY",
			CoverageLevelCode = "IJy",
			ProductProcessCharacteristicCode = "9j",
			YesNoConditionOrResponseCode = "q",
		};

		var actual = Map.MapObject<SV7_DrugAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IJy", true)]
	public void Validation_RequiredCoverageLevelCode(string coverageLevelCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.ProductProcessCharacteristicCode = "9j";
		//Test Parameters
		subject.CoverageLevelCode = coverageLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9j", true)]
	public void Validation_RequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, bool isValidExpected)
	{
		var subject = new SV7_DrugAdjudication();
		//Required fields
		subject.CoverageLevelCode = "IJy";
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
