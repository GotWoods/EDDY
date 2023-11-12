using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class OPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OP*0*L*4";

		var expected = new OP_OtherProgramsAndServices()
		{
			ProgramParticipationAndServicesCode = "0",
			ProgramAndServicesFundingSourceCode = "L",
			Name = "4",
		};

		var actual = Map.MapObject<OP_OtherProgramsAndServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("0", "4", true)]
	[InlineData("0", "", true)]
	[InlineData("", "4", true)]
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
