using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G29Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G29*G*6*sA";

		var expected = new G29_StoreDisplayInformation()
		{
			DisplayTypeCode = "G",
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "sA",
		};

		var actual = Map.MapObject<G29_StoreDisplayInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredDisplayTypeCode(string displayTypeCode, bool isValidExpected)
	{
		var subject = new G29_StoreDisplayInformation();
		subject.DisplayTypeCode = displayTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "sA", true)]
	[InlineData(0, "sA", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G29_StoreDisplayInformation();
		subject.DisplayTypeCode = "G";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
