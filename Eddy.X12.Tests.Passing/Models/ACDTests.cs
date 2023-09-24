using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ACDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ACD*F*Zw*N";

		var expected = new ACD_AccountDescription()
		{
	AccountRelationshipCode = "F",
	RatingRemarksCode = "Zw",
	LoanTypeCode = "N",
	};

	var actual = Map.MapObject<ACD_AccountDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
	Assert.Equivalent(expected, actual);
	}
}
