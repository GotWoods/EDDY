using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCD*M*1**9**2**ER*8**AT*1**Br*6**Lj*2**oi*3";

		var expected = new RCD_ReceivingConditions()
		{
			AssignedIdentification = "M",
			QuantityUnitsReceivedOrAccepted = 1,
			CompositeUnitOfMeasure = null,
			QuantityUnitsReturned = 9,
			CompositeUnitOfMeasure2 = null,
			QuantityInQuestion = 2,
			CompositeUnitOfMeasure3 = null,
			ReceivingConditionCode = "ER",
			QuantityInQuestion2 = 8,
			CompositeUnitOfMeasure4 = null,
			ReceivingConditionCode2 = "AT",
			QuantityInQuestion3 = 1,
			CompositeUnitOfMeasure5 = null,
			ReceivingConditionCode3 = "Br",
			QuantityInQuestion4 = 6,
			CompositeUnitOfMeasure6 = null,
			ReceivingConditionCode4 = "Lj",
			QuantityInQuestion5 = 2,
			CompositeUnitOfMeasure7 = null,
			ReceivingConditionCode5 = "oi",
			Quantity = 3,
		};

		var actual = Map.MapObject<RCD_ReceivingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	

}
