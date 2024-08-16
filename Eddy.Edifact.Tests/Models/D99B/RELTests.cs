using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class RELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "REL+4+";

		var expected = new REL_Relationship()
		{
			RelationshipTypeCodeQualifier = "4",
			Relationship = null,
		};

		var actual = Map.MapObject<REL_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredRelationshipTypeCodeQualifier(string relationshipTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new REL_Relationship();
		//Required fields
		//Test Parameters
		subject.RelationshipTypeCodeQualifier = relationshipTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
