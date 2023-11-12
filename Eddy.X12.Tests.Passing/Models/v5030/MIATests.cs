using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*5*5*1*3*2*7*1*2*9*6*6*9*6*8*1*1*6*4*8*I*f*f*1*7";

		var expected = new MIA_MedicareInpatientAdjudication()
		{
			Quantity = 5,
			MonetaryAmount = 5,
			Quantity2 = 1,
			MonetaryAmount2 = 3,
			ReferenceIdentification = "2",
			MonetaryAmount3 = 7,
			MonetaryAmount4 = 1,
			MonetaryAmount5 = 2,
			MonetaryAmount6 = 9,
			MonetaryAmount7 = 6,
			MonetaryAmount8 = 6,
			MonetaryAmount9 = 9,
			MonetaryAmount10 = 6,
			MonetaryAmount11 = 8,
			Quantity3 = 1,
			MonetaryAmount12 = 1,
			MonetaryAmount13 = 6,
			MonetaryAmount14 = 4,
			MonetaryAmount15 = 8,
			ReferenceIdentification2 = "I",
			ReferenceIdentification3 = "f",
			ReferenceIdentification4 = "f",
			ReferenceIdentification5 = "1",
			MonetaryAmount16 = 7,
		};

		var actual = Map.MapObject<MIA_MedicareInpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
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
