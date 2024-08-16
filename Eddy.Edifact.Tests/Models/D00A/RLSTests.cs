using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class RLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RLS+S+";

		var expected = new RLS_Relationship()
		{
			RelationshipTypeCodeQualifier = "S",
			Relationship = null,
		};

		var actual = Map.MapObject<RLS_Relationship>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredRelationshipTypeCodeQualifier(string relationshipTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new RLS_Relationship();
		//Required fields
		//Test Parameters
		subject.RelationshipTypeCodeQualifier = relationshipTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
