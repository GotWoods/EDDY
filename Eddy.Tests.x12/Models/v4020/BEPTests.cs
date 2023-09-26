using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEP*d*I";

		var expected = new BEP_BorrowerEducationProgram()
		{
			ProgramParticipationAndServicesCode = "d",
			InstructionalSettingCode = "I",
		};

		var actual = Map.MapObject<BEP_BorrowerEducationProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredProgramParticipationAndServicesCode(string programParticipationAndServicesCode, bool isValidExpected)
	{
		var subject = new BEP_BorrowerEducationProgram();
		//Required fields
		//Test Parameters
		subject.ProgramParticipationAndServicesCode = programParticipationAndServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
