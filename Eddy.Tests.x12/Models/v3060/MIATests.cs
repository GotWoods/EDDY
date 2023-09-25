using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIA*9*2*8*4*Y*3*2*8*9*7*2*6*8*4*4*4*1*3*6*N*u*F*F*6";

		var expected = new MIA_MedicareInpatientAdjudication()
		{
			Quantity = 9,
			Quantity2 = 2,
			Quantity3 = 8,
			MonetaryAmount = 4,
			ReferenceIdentification = "Y",
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 2,
			MonetaryAmount4 = 8,
			MonetaryAmount5 = 9,
			MonetaryAmount6 = 7,
			MonetaryAmount7 = 2,
			MonetaryAmount8 = 6,
			MonetaryAmount9 = 8,
			MonetaryAmount10 = 4,
			Quantity4 = 4,
			MonetaryAmount11 = 4,
			MonetaryAmount12 = 1,
			MonetaryAmount13 = 3,
			MonetaryAmount14 = 6,
			ReferenceIdentification2 = "N",
			ReferenceIdentification3 = "u",
			ReferenceIdentification4 = "F",
			ReferenceIdentification5 = "F",
			MonetaryAmount15 = 6,
		};

		var actual = Map.MapObject<MIA_MedicareInpatientAdjudication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
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
