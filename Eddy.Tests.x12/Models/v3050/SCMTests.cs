using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCM*5*8*U*6";

		var expected = new SCM_CreditScoreModel()
		{
			ProductServiceID = "5",
			Number = 8,
			EvaluationRatingCode = "U",
			FreeFormMessage = "6",
		};

		var actual = Map.MapObject<SCM_CreditScoreModel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
