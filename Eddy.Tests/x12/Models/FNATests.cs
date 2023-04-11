using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FNATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FNA*0*s*Z*x*U*w";

		var expected = new FNA_FinancialStatusInformation()
		{
			YesNoConditionOrResponseCode = "0",
			YesNoConditionOrResponseCode2 = "s",
			YesNoConditionOrResponseCode3 = "Z",
			DependencyStatusCode = "x",
			YesNoConditionOrResponseCode4 = "U",
			YesNoConditionOrResponseCode5 = "w",
		};

		var actual = Map.MapObject<FNA_FinancialStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FNA_FinancialStatusInformation();
		subject.YesNoConditionOrResponseCode2 = "s";
		subject.YesNoConditionOrResponseCode3 = "Z";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new FNA_FinancialStatusInformation();
		subject.YesNoConditionOrResponseCode = "0";
		subject.YesNoConditionOrResponseCode3 = "Z";
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode3(string yesNoConditionOrResponseCode3, bool isValidExpected)
	{
		var subject = new FNA_FinancialStatusInformation();
		subject.YesNoConditionOrResponseCode = "0";
		subject.YesNoConditionOrResponseCode2 = "s";
		subject.YesNoConditionOrResponseCode3 = yesNoConditionOrResponseCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
