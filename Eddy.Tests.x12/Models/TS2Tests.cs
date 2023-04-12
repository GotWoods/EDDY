using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS2*9*8*9*3*5*5*3*5*5*2*9*1*1*5*7*5*5*6*6";

		var expected = new TS2_TransactionSupplementalStatistics()
		{
			MonetaryAmount = 9,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 9,
			MonetaryAmount4 = 3,
			MonetaryAmount5 = 5,
			MonetaryAmount6 = 5,
			Quantity = 3,
			MonetaryAmount7 = 5,
			MonetaryAmount8 = 5,
			Quantity2 = 2,
			Quantity3 = 9,
			Quantity4 = 1,
			Quantity5 = 1,
			Quantity6 = 5,
			MonetaryAmount9 = 7,
			Quantity7 = 5,
			MonetaryAmount10 = 5,
			MonetaryAmount11 = 6,
			MonetaryAmount12 = 6,
		};

		var actual = Map.MapObject<TS2_TransactionSupplementalStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
