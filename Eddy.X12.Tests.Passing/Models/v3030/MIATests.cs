using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*1*3*9*2*m*1*4*8*8*7*1*2*9*4*6*6*5*9*6*b*g*a*g*8";

		var expected = new MIA_MedicareInpatientAdjudication()
		{
			Quantity = 1,
			Quantity2 = 3,
			Quantity3 = 9,
			MonetaryAmount = 2,
			ReferenceNumber = "m",
			MonetaryAmount2 = 1,
			MonetaryAmount3 = 4,
			MonetaryAmount4 = 8,
			MonetaryAmount5 = 8,
			MonetaryAmount6 = 7,
			MonetaryAmount7 = 1,
			MonetaryAmount8 = 2,
			MonetaryAmount9 = 9,
			MonetaryAmount10 = 4,
			Quantity4 = 6,
			MonetaryAmount11 = 6,
			MonetaryAmount12 = 5,
			MonetaryAmount13 = 9,
			MonetaryAmount14 = 6,
			ReferenceNumber2 = "b",
			ReferenceNumber3 = "g",
			ReferenceNumber4 = "a",
			ReferenceNumber5 = "g",
			MonetaryAmount15 = 8,
		};

		var actual = Map.MapObject<MIA_MedicareInpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new MIA_MedicareInpatientAdjudication();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
