using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G13*JC*4*pM*6*3";

		var expected = new G13_StoreSizeAttributes()
		{
			ClassOfTradeCode = "JC",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "pM",
			Number = 6,
			MonetaryAmount = 3,
		};

		var actual = Map.MapObject<G13_StoreSizeAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JC", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 4;
			subject.UnitOrBasisForMeasurementCode = "pM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "pM", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "pM", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		subject.ClassOfTradeCode = "JC";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
