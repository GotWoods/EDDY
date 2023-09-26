using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCM*6*9*v*Q";

		var expected = new SCM_CreditScoreModel()
		{
			ProductServiceID = "6",
			Number = 9,
			EvaluationRatingCode = "v",
			FreeFormMessage = "Q",
		};

		var actual = Map.MapObject<SCM_CreditScoreModel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
