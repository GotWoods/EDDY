using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RETTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RET*9*6F*75*e*RV";

		var expected = new RET_RealEstateTransaction()
		{
			InformationStatusCode = "9",
			TransactionTypeCode = "6F",
			StatusCode = "75",
			StatusOfPlansForRealEstateAssetCode = "e",
			ContractTypeCode = "RV",
		};

		var actual = Map.MapObject<RET_RealEstateTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
