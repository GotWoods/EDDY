using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCM*y*2*G*E";

		var expected = new SCM_CreditScoreModel()
		{
			ProductServiceID = "y",
			Number = 2,
			EvaluationRatingCode = "G",
			FreeFormMessage = "E",
		};

		var actual = Map.MapObject<SCM_CreditScoreModel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
