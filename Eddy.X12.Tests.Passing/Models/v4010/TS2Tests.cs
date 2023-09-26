using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TS2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TS2*2*1*4*6*7*2*1*3*9*6*8*2*7*3*4*4*7*8*3";

		var expected = new TS2_TransactionSupplementalStatistics()
		{
			MonetaryAmount = 2,
			MonetaryAmount2 = 1,
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 6,
			MonetaryAmount5 = 7,
			MonetaryAmount6 = 2,
			Quantity = 1,
			MonetaryAmount7 = 3,
			MonetaryAmount8 = 9,
			Quantity2 = 6,
			Quantity3 = 8,
			Quantity4 = 2,
			Quantity5 = 7,
			Quantity6 = 3,
			MonetaryAmount9 = 4,
			Quantity7 = 4,
			MonetaryAmount10 = 7,
			MonetaryAmount11 = 8,
			MonetaryAmount12 = 3,
		};

		var actual = Map.MapObject<TS2_TransactionSupplementalStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
