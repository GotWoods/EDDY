using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FNATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FNA*k*G*E*U*c*J";

		var expected = new FNA_FinancialStatusInformation()
		{
			YesNoConditionOrResponseCode = "k",
			YesNoConditionOrResponseCode2 = "G",
			YesNoConditionOrResponseCode3 = "E",
			DependencyStatusCode = "U",
			YesNoConditionOrResponseCode4 = "c",
			YesNoConditionOrResponseCode5 = "J",
		};

		var actual = Map.MapObject<FNA_FinancialStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FNA_FinancialStatusInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode2 = "G";
		subject.YesNoConditionOrResponseCode3 = "E";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new FNA_FinancialStatusInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "k";
		subject.YesNoConditionOrResponseCode3 = "E";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode3(string yesNoConditionOrResponseCode3, bool isValidExpected)
	{
		var subject = new FNA_FinancialStatusInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "k";
		subject.YesNoConditionOrResponseCode2 = "G";
		//Test Parameters
		subject.YesNoConditionOrResponseCode3 = yesNoConditionOrResponseCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
