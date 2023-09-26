using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SP*8*o";

		var expected = new SP_SpecialEducationProgram()
		{
			SpecialEducationProgramParticipationCode = "8",
			InstructionalSettingCode = "o",
		};

		var actual = Map.MapObject<SP_SpecialEducationProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredSpecialEducationProgramParticipationCode(string specialEducationProgramParticipationCode, bool isValidExpected)
	{
		var subject = new SP_SpecialEducationProgram();
		//Required fields
		//Test Parameters
		subject.SpecialEducationProgramParticipationCode = specialEducationProgramParticipationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
