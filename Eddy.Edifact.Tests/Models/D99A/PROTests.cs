using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class PROTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRO+";

		var expected = new PRO_Promotions()
		{
			PromotionDetails = null,
		};

		var actual = Map.MapObject<PRO_Promotions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPromotionDetails(string promotionDetails, bool isValidExpected)
	{
		var subject = new PRO_Promotions();
		//Required fields
		//Test Parameters
		if (promotionDetails != "") 
			subject.PromotionDetails = new E019_PromotionDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
