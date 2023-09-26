using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ACDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACD*i*Nq*r";

		var expected = new ACD_AccountDescription()
		{
			AccountRelationshipCode = "i",
			RatingRemarksCode = "Nq",
			LoanTypeCode = "r",
		};

		var actual = Map.MapObject<ACD_AccountDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
