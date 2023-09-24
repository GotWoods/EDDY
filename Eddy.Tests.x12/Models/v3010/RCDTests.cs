using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCD*w*9*bV*3*Pp*5*y3*dD*6*hb*Zi*1*q9*a1*9*z5*cr*4*la*uk";

		var expected = new RCD_ReceivingConditions()
		{
			AssignedIdentification = "w",
			QuantityUnitsReceived = 9,
			UnitOfMeasurementCode = "bV",
			QuantityUnitsReturned = 3,
			UnitOfMeasurementCode2 = "Pp",
			QuantityInQuestion = 5,
			UnitOfMeasurementCode3 = "y3",
			ReceivingConditionCode = "dD",
			QuantityInQuestion2 = 6,
			UnitOfMeasurementCode4 = "hb",
			ReceivingConditionCode2 = "Zi",
			QuantityInQuestion3 = 1,
			UnitOfMeasurementCode5 = "q9",
			ReceivingConditionCode3 = "a1",
			QuantityInQuestion4 = 9,
			UnitOfMeasurementCode6 = "z5",
			ReceivingConditionCode4 = "cr",
			QuantityInQuestion5 = 4,
			UnitOfMeasurementCode7 = "la",
			ReceivingConditionCode5 = "uk",
		};

		var actual = Map.MapObject<RCD_ReceivingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
