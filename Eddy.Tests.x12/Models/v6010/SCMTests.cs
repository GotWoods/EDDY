using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class SCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCM*c*8*K*N";

		var expected = new SCM_CreditScoreModel()
		{
			ProductServiceID = "c",
			Number = 8,
			EvaluationRatingCode = "K",
			FreeFormMessage = "N",
		};

		var actual = Map.MapObject<SCM_CreditScoreModel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
