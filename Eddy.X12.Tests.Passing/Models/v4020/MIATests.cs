using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*8*1*6*7*e*5*4*3*6*4*7*3*9*8*7*5*8*1*1*U*h*P*T*9";

		var expected = new MIA_MedicareInpatientAdjudication()
		{
			Quantity = 8,
			MonetaryAmount = 1,
			Quantity2 = 6,
			MonetaryAmount2 = 7,
			ReferenceIdentification = "e",
			MonetaryAmount3 = 5,
			MonetaryAmount4 = 4,
			MonetaryAmount5 = 3,
			MonetaryAmount6 = 6,
			MonetaryAmount7 = 4,
			MonetaryAmount8 = 7,
			MonetaryAmount9 = 3,
			MonetaryAmount10 = 9,
			MonetaryAmount11 = 8,
			Quantity3 = 7,
			MonetaryAmount12 = 5,
			MonetaryAmount13 = 8,
			MonetaryAmount14 = 1,
			MonetaryAmount15 = 1,
			ReferenceIdentification2 = "U",
			ReferenceIdentification3 = "h",
			ReferenceIdentification4 = "P",
			ReferenceIdentification5 = "T",
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
