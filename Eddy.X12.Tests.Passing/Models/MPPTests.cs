using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MPP*So*Ur*tVK*89*J*4*7*t";

		var expected = new MPP_MortgagePoolProgram()
		{
			CodeCategory = "So",
			ProgramTypeCode = "Ur",
			DateTimeQualifier = "tVK",
			DateTimePeriodFormatQualifier = "89",
			DateTimePeriod = "J",
			MonetaryAmount = 4,
			AccrualRateMethodCode = "7",
			CertificationTypeCode = "t",
		};

		var actual = Map.MapObject<MPP_MortgagePoolProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("So", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new MPP_MortgagePoolProgram();
		subject.ProgramTypeCode = "Ur";
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ur", true)]
	public void Validation_RequiredProgramTypeCode(string programTypeCode, bool isValidExpected)
	{
		var subject = new MPP_MortgagePoolProgram();
		subject.CodeCategory = "So";
		subject.ProgramTypeCode = programTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
