using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MPP*GS*jd*Au2*SC*I";

		var expected = new MPP_MortgagePoolProgram()
		{
			CodeCategory = "GS",
			ProgramTypeCode = "jd",
			DateTimeQualifier = "Au2",
			DateTimePeriodFormatQualifier = "SC",
			DateTimePeriod = "I",
		};

		var actual = Map.MapObject<MPP_MortgagePoolProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GS", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new MPP_MortgagePoolProgram();
		//Required fields
		subject.ProgramTypeCode = "jd";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jd", true)]
	public void Validation_RequiredProgramTypeCode(string programTypeCode, bool isValidExpected)
	{
		var subject = new MPP_MortgagePoolProgram();
		//Required fields
		subject.CodeCategory = "GS";
		//Test Parameters
		subject.ProgramTypeCode = programTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
