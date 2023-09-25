using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class OPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OP*6*R*V";

		var expected = new OP_OtherPrograms()
		{
			OtherProgramParticipationCode = "6",
			OtherProgramFundingSourceCode = "R",
			Name = "V",
		};

		var actual = Map.MapObject<OP_OtherPrograms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("6", "V", true)]
	[InlineData("6", "", true)]
	[InlineData("", "V", true)]
	public void Validation_AtLeastOneOtherProgramParticipationCode(string otherProgramParticipationCode, string name, bool isValidExpected)
	{
		var subject = new OP_OtherPrograms();
		//Required fields
		//Test Parameters
		subject.OtherProgramParticipationCode = otherProgramParticipationCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
