using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*7*6*8*1*T*4*7*1*6*4*5*6*9*6*8*1*5*8*5*V*j*f*T*2";

		var expected = new MIA_InpatientAdjudication()
		{
			Quantity = 7,
			MonetaryAmount = 6,
			Quantity2 = 8,
			MonetaryAmount2 = 1,
			ReferenceIdentification = "T",
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 7,
			MonetaryAmount5 = 1,
			MonetaryAmount6 = 6,
			MonetaryAmount7 = 4,
			MonetaryAmount8 = 5,
			MonetaryAmount9 = 6,
			MonetaryAmount10 = 9,
			MonetaryAmount11 = 6,
			Quantity3 = 8,
			MonetaryAmount12 = 1,
			MonetaryAmount13 = 5,
			MonetaryAmount14 = 8,
			MonetaryAmount15 = 5,
			ReferenceIdentification2 = "V",
			ReferenceIdentification3 = "j",
			ReferenceIdentification4 = "f",
			ReferenceIdentification5 = "T",
			MonetaryAmount16 = 2,
		};

		var actual = Map.MapObject<MIA_InpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
