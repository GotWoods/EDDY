using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class OPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OP*J*0*i";

		var expected = new OP_OtherProgramsAndServices()
		{
			OtherProgramParticipationAndServicesCode = "J",
			OtherProgramAndServicesFundingSourceCode = "0",
			Name = "i",
		};

		var actual = Map.MapObject<OP_OtherProgramsAndServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("J", "i", true)]
	[InlineData("J", "", true)]
	[InlineData("", "i", true)]
	public void Validation_AtLeastOneOtherProgramParticipationAndServicesCode(string otherProgramParticipationAndServicesCode, string name, bool isValidExpected)
	{
		var subject = new OP_OtherProgramsAndServices();
		//Required fields
		//Test Parameters
		subject.OtherProgramParticipationAndServicesCode = otherProgramParticipationAndServicesCode;
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
