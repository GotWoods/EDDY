using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEP*P*w";

		var expected = new BEP_BorrowerEducationProgram()
		{
			ProgramParticipationAndServicesCode = "P",
			InstructionalSettingCode = "w",
		};

		var actual = Map.MapObject<BEP_BorrowerEducationProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredProgramParticipationAndServicesCode(string programParticipationAndServicesCode, bool isValidExpected)
	{
		var subject = new BEP_BorrowerEducationProgram();
		//Required fields
		subject.InstructionalSettingCode = "w";
		//Test Parameters
		subject.ProgramParticipationAndServicesCode = programParticipationAndServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredInstructionalSettingCode(string instructionalSettingCode, bool isValidExpected)
	{
		var subject = new BEP_BorrowerEducationProgram();
		//Required fields
		subject.ProgramParticipationAndServicesCode = "P";
		//Test Parameters
		subject.InstructionalSettingCode = instructionalSettingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
