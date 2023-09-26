using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LT*jt*F*3*b";

		var expected = new LT_LetterOfRecommendation()
		{
			IndividualRelationshipCode = "jt",
			Description = "F",
			Name = "3",
			Description2 = "b",
		};

		var actual = Map.MapObject<LT_LetterOfRecommendation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jt", true)]
	public void Validation_RequiredIndividualRelationshipCode(string individualRelationshipCode, bool isValidExpected)
	{
		var subject = new LT_LetterOfRecommendation();
		//Required fields
		//Test Parameters
		subject.IndividualRelationshipCode = individualRelationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
