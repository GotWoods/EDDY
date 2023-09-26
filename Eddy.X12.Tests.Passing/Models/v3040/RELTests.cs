using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REL*vh*8";

		var expected = new REL_Relationship()
		{
			IndividualRelationshipCode = "vh",
			Number = 8,
		};

		var actual = Map.MapObject<REL_Relationship>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vh", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new REL_Relationship();
		//Required fields
		//Test Parameters
		subject.IndividualRelationshipCode = individualRelationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
