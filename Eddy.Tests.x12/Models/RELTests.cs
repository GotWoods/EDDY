using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REL*mu*5";

		var expected = new REL_Relationship()
		{
			IndividualRelationshipCode = "mu",
			Number = 5,
		};

		var actual = Map.MapObject<REL_Relationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mu", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new REL_Relationship();
		subject.IndividualRelationshipCode = individualRelationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
