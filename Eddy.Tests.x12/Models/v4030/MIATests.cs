using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*8*8*3*6*a*7*5*7*1*9*3*6*5*9*8*9*8*2*8*v*i*j*h*9";

		var expected = new MIA_MedicareInpatientAdjudication()
		{
			Quantity = 8,
			MonetaryAmount = 8,
			Quantity2 = 3,
			MonetaryAmount2 = 6,
			ReferenceIdentification = "a",
			MonetaryAmount3 = 7,
			MonetaryAmount4 = 5,
			MonetaryAmount5 = 7,
			MonetaryAmount6 = 1,
			MonetaryAmount7 = 9,
			MonetaryAmount8 = 3,
			MonetaryAmount9 = 6,
			MonetaryAmount10 = 5,
			MonetaryAmount11 = 9,
			Quantity3 = 8,
			MonetaryAmount12 = 9,
			MonetaryAmount13 = 8,
			MonetaryAmount14 = 2,
			MonetaryAmount15 = 8,
			ReferenceIdentification2 = "v",
			ReferenceIdentification3 = "i",
			ReferenceIdentification4 = "j",
			ReferenceIdentification5 = "h",
			MonetaryAmount16 = 9,
		};

		var actual = Map.MapObject<MIA_MedicareInpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
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
