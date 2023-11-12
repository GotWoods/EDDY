using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Q6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q6*3*P*K*6*QY4*nC*V*jow*Wn*S";

		var expected = new Q6_ShipmentDetails()
		{
			Weight = 3,
			WeightUnitQualifier = "P",
			WeightQualifier = "K",
			LadingQuantity = 6,
			LadingQuantityQualifier = "QY4",
			ShipmentMethodOfPayment = "nC",
			NetAmountDue = "V",
			CurrencyCode = "jow",
			UnitOfTimePeriodCode = "Wn",
			ServiceStandard = "S",
		};

		var actual = Map.MapObject<Q6_ShipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
