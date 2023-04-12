using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class USITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "USI*8*Rzv*o";

		var expected = new USI_UnitizedShipmentInformation()
		{
			Quantity = 8,
			PackagingFormCode = "Rzv",
			YesNoConditionOrResponseCode = "o",
		};

		var actual = Map.MapObject<USI_UnitizedShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new USI_UnitizedShipmentInformation();
		subject.PackagingFormCode = "Rzv";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rzv", true)]
	public void Validation_RequiredPackagingFormCode(string packagingFormCode, bool isValidExpected)
	{
		var subject = new USI_UnitizedShipmentInformation();
		subject.Quantity = 8;
		subject.PackagingFormCode = packagingFormCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
