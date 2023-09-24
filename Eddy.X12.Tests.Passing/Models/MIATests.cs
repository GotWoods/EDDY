using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*5*7*4*7*c*4*6*2*7*2*4*3*6*5*7*5*3*4*1*T*E*n*d*7";

		var expected = new MIA_InpatientAdjudication()
		{
			Quantity = 5,
			MonetaryAmount = 7,
			Quantity2 = 4,
			MonetaryAmount2 = 7,
			ReferenceIdentification = "c",
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 6,
			MonetaryAmount5 = 2,
			MonetaryAmount6 = 7,
			MonetaryAmount7 = 2,
			MonetaryAmount8 = 4,
			MonetaryAmount9 = 3,
			MonetaryAmount10 = 6,
			MonetaryAmount11 = 5,
			Quantity3 = 7,
			MonetaryAmount12 = 5,
			MonetaryAmount13 = 3,
			MonetaryAmount14 = 4,
			MonetaryAmount15 = 1,
			ReferenceIdentification2 = "T",
			ReferenceIdentification3 = "E",
			ReferenceIdentification4 = "n",
			ReferenceIdentification5 = "d",
			MonetaryAmount16 = 7,
		};

		var actual = Map.MapObject<MIA_InpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
