using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class RELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "REL+s+";

		var expected = new REL_Relationship()
		{
			RelationshipQualifier = "s",
			Relationship = null,
		};

		var actual = Map.MapObject<REL_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredRelationshipQualifier(string relationshipQualifier, bool isValidExpected)
	{
		var subject = new REL_Relationship();
		//Required fields
		//Test Parameters
		subject.RelationshipQualifier = relationshipQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
