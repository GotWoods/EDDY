using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SP*E*8*F*d*n";

		var expected = new SP_SpecialProgram()
		{
			SpecialProgramCategoryCode = "E",
			PercentageAsDecimal = 8,
			ProgramParticipationAndServicesCode = "F",
			InstitutionalGovernanceOrFundingSourceLevelCode = "d",
			Name = "n",
		};

		var actual = Map.MapObject<SP_SpecialProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("E","F", true)]
	[InlineData("", "F", true)]
	[InlineData("E", "", true)]
	public void Validation_AtLeastOneSpecialProgramCategoryCode(string specialProgramCategoryCode, string programParticipationAndServicesCode, bool isValidExpected)
	{
		var subject = new SP_SpecialProgram();
		subject.SpecialProgramCategoryCode = specialProgramCategoryCode;
		subject.ProgramParticipationAndServicesCode = programParticipationAndServicesCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
