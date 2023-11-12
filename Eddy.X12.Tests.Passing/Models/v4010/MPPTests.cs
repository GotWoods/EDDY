using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MPP*In*F7*PWm*gb*Q*2*W*t";

		var expected = new MPP_MortgagePoolProgram()
		{
			CodeCategory = "In",
			ProgramTypeCode = "F7",
			DateTimeQualifier = "PWm",
			DateTimePeriodFormatQualifier = "gb",
			DateTimePeriod = "Q",
			MonetaryAmount = 2,
			AccrualRateMethodCode = "W",
			CertificationTypeCode = "t",
		};

		var actual = Map.MapObject<MPP_MortgagePoolProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("In", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new MPP_MortgagePoolProgram();
		//Required fields
		subject.ProgramTypeCode = "F7";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F7", true)]
	public void Validation_RequiredProgramTypeCode(string programTypeCode, bool isValidExpected)
	{
		var subject = new MPP_MortgagePoolProgram();
		//Required fields
		subject.CodeCategory = "In";
		//Test Parameters
		subject.ProgramTypeCode = programTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
