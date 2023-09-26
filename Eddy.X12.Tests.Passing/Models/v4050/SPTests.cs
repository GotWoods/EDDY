using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SP*r*7*S*6*g";

		var expected = new SP_SpecialProgram()
		{
			SpecialProgramCategoryCode = "r",
			PercentageAsDecimal = 7,
			ProgramParticipationAndServicesCode = "S",
			InstitutionalGovernanceOrFundingSourceLevelCode = "6",
			Name = "g",
		};

		var actual = Map.MapObject<SP_SpecialProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("r", "S", true)]
	[InlineData("r", "", true)]
	[InlineData("", "S", true)]
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
