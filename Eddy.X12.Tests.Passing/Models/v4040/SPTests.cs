using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class SPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SP*C*9*r*f*3";

		var expected = new SP_SpecialProgram()
		{
			SpecialProgramCategoryCode = "C",
			Percent = 9,
			ProgramParticipationAndServicesCode = "r",
			InstitutionalGovernanceOrFundingSourceLevelCode = "f",
			Name = "3",
		};

		var actual = Map.MapObject<SP_SpecialProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("C", "r", true)]
	[InlineData("C", "", true)]
	[InlineData("", "r", true)]
	public void Validation_AtLeastOneSpecialProgramCategoryCode(string specialProgramCategoryCode, string programParticipationAndServicesCode, bool isValidExpected)
	{
		var subject = new SP_SpecialProgram();
		//Required fields
		//Test Parameters
		subject.SpecialProgramCategoryCode = specialProgramCategoryCode;
		subject.ProgramParticipationAndServicesCode = programParticipationAndServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
