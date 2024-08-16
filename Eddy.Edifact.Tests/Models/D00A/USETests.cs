using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USE+n";

		var expected = new USE_SecurityMessageRelation()
		{
			MessageRelationCoded = "n",
		};

		var actual = Map.MapObject<USE_SecurityMessageRelation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredMessageRelationCoded(string messageRelationCoded, bool isValidExpected)
	{
		var subject = new USE_SecurityMessageRelation();
		//Required fields
		//Test Parameters
		subject.MessageRelationCoded = messageRelationCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
