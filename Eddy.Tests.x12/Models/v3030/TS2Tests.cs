using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS2*6*2*5*2*3*8*8*2*1*6*4*1*1*2*8";

		var expected = new TS2_TransactionSupplementalStatistics()
		{
			MonetaryAmount = 6,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 5,
			MonetaryAmount4 = 2,
			MonetaryAmount5 = 3,
			MonetaryAmount6 = 8,
			Quantity = 8,
			MonetaryAmount7 = 2,
			MonetaryAmount8 = 1,
			Quantity2 = 6,
			Quantity3 = 4,
			Quantity4 = 1,
			Quantity5 = 1,
			Quantity6 = 2,
			MonetaryAmount9 = 8,
		};

		var actual = Map.MapObject<TS2_TransactionSupplementalStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
