using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class USITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USI*9*NV1*k";

		var expected = new USI_UnitizedShipmentInformation()
		{
			Quantity = 9,
			PackagingFormCode = "NV1",
			YesNoConditionOrResponseCode = "k",
		};

		var actual = Map.MapObject<USI_UnitizedShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new USI_UnitizedShipmentInformation();
		//Required fields
		subject.PackagingFormCode = "NV1";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NV1", true)]
	public void Validation_RequiredPackagingFormCode(string packagingFormCode, bool isValidExpected)
	{
		var subject = new USI_UnitizedShipmentInformation();
		//Required fields
		subject.Quantity = 9;
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
