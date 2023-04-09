using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEP*0*t";

		var expected = new BEP_BorrowerEducationProgram()
		{
			ProgramParticipationAndServicesCode = "0",
			InstructionalSettingCode = "t",
		};

		var actual = Map.MapObject<BEP_BorrowerEducationProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validatation_RequiredProgramParticipationAndServicesCode(string programParticipationAndServicesCode, bool isValidExpected)
	{
		var subject = new BEP_BorrowerEducationProgram();
		subject.ProgramParticipationAndServicesCode = programParticipationAndServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
