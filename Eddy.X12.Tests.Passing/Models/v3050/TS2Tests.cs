using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS2*3*2*9*9*9*2*1*3*8*2*8*5*8*3*1*4*9*7*2";

		var expected = new TS2_TransactionSupplementalStatistics()
		{
			MonetaryAmount = 3,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 9,
			MonetaryAmount4 = 9,
			MonetaryAmount5 = 9,
			MonetaryAmount6 = 2,
			Quantity = 1,
			MonetaryAmount7 = 3,
			MonetaryAmount8 = 8,
			Quantity2 = 2,
			Quantity3 = 8,
			Quantity4 = 5,
			Quantity5 = 8,
			Quantity6 = 3,
			MonetaryAmount9 = 1,
			Quantity7 = 4,
			MonetaryAmount10 = 9,
			MonetaryAmount11 = 7,
			MonetaryAmount12 = 2,
		};

		var actual = Map.MapObject<TS2_TransactionSupplementalStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
