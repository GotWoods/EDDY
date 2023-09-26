using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class OPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OP*Z*P*o";

		var expected = new OP_OtherProgramsAndServices()
		{
			ProgramParticipationAndServicesCode = "Z",
			InstitutionalGovernanceOrFundingSourceLevelCode = "P",
			Name = "o",
		};

		var actual = Map.MapObject<OP_OtherProgramsAndServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Z", "o", true)]
	[InlineData("Z", "", true)]
	[InlineData("", "o", true)]
	public void Validation_AtLeastOneProgramParticipationAndServicesCode(string programParticipationAndServicesCode, string name, bool isValidExpected)
	{
		var subject = new OP_OtherProgramsAndServices();
		//Required fields
		//Test Parameters
		subject.ProgramParticipationAndServicesCode = programParticipationAndServicesCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
