using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class Q6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q6*5*3*i*1*tdP*Zr*Y*e0f*up*Q";

		var expected = new Q6_ShipmentDetails()
		{
			Weight = 5,
			WeightUnitCode = "3",
			WeightQualifier = "i",
			LadingQuantity = 1,
			PackagingFormCode = "tdP",
			ShipmentMethodOfPayment = "Zr",
			NetAmountDue = "Y",
			CurrencyCode = "e0f",
			UnitOfTimePeriodOrInterval = "up",
			ServiceStandard = "Q",
		};

		var actual = Map.MapObject<Q6_ShipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("up", "Q", true)]
	[InlineData("up", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string serviceStandard, bool isValidExpected)
	{
		var subject = new Q6_ShipmentDetails();
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.ServiceStandard = serviceStandard;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
