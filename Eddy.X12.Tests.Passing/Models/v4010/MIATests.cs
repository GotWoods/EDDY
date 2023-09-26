using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*1*8*6*1*u*8*1*6*5*5*7*7*1*6*1*3*6*2*2*S*O*0*7*9";

		var expected = new MIA_MedicareInpatientAdjudication()
		{
			Quantity = 1,
			Quantity2 = 8,
			Quantity3 = 6,
			MonetaryAmount = 1,
			ReferenceIdentification = "u",
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 1,
			MonetaryAmount4 = 6,
			MonetaryAmount5 = 5,
			MonetaryAmount6 = 5,
			MonetaryAmount7 = 7,
			MonetaryAmount8 = 7,
			MonetaryAmount9 = 1,
			MonetaryAmount10 = 6,
			Quantity4 = 1,
			MonetaryAmount11 = 3,
			MonetaryAmount12 = 6,
			MonetaryAmount13 = 2,
			MonetaryAmount14 = 2,
			ReferenceIdentification2 = "S",
			ReferenceIdentification3 = "O",
			ReferenceIdentification4 = "0",
			ReferenceIdentification5 = "7",
			MonetaryAmount15 = 9,
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
