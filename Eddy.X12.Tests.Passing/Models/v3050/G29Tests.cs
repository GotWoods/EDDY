using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G29Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G29*Q*6*rn";

		var expected = new G29_StoreDisplayInformation()
		{
			DisplayTypeCode = "Q",
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "rn",
		};

		var actual = Map.MapObject<G29_StoreDisplayInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredDisplayTypeCode(string displayTypeCode, bool isValidExpected)
	{
		var subject = new G29_StoreDisplayInformation();
		//Required fields
		//Test Parameters
		subject.DisplayTypeCode = displayTypeCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 6;
			subject.UnitOrBasisForMeasurementCode = "rn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "rn", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "rn", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G29_StoreDisplayInformation();
		//Required fields
		subject.DisplayTypeCode = "Q";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
