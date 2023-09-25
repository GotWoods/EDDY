using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SP*x*6*l*Z*q";

		var expected = new SP_SpecialProgram()
		{
			SpecialProgramCategoryCode = "x",
			Percent = 6,
			ProgramParticipationAndServicesCode = "l",
			ProgramAndServicesFundingSourceCode = "Z",
			Name = "q",
		};

		var actual = Map.MapObject<SP_SpecialProgram>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("x", "l", true)]
	[InlineData("x", "", true)]
	[InlineData("", "l", true)]
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
