using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RETTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RET*J*Z2*W7*E*R3";

		var expected = new RET_RealEstateTransaction()
		{
			InformationStatusCode = "J",
			TransactionTypeCode = "Z2",
			StatusCode = "W7",
			StatusOfPlansForRealEstateAssetCode = "E",
			ContractTypeCode = "R3",
		};

		var actual = Map.MapObject<RET_RealEstateTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
