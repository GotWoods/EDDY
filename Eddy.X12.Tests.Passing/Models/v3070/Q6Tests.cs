using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class Q6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q6*9*l*g*9*L3N*aW*K*dPh*9I*m*Pu*cP";

		var expected = new Q6_ShipmentDetails()
		{
			Weight = 9,
			WeightUnitCode = "l",
			WeightQualifier = "g",
			LadingQuantity = 9,
			PackagingFormCode = "L3N",
			ShipmentMethodOfPayment = "aW",
			NetAmountDue = "K",
			CurrencyCode = "dPh",
			UnitOfTimePeriodOrInterval = "9I",
			ServiceStandard = "m",
			ServiceLevelCode = "Pu",
			ServiceLevelCode2 = "cP",
		};

		var actual = Map.MapObject<Q6_ShipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9I", "m", true)]
	[InlineData("9I", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string serviceStandard, bool isValidExpected)
	{
		var subject = new Q6_ShipmentDetails();
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.ServiceStandard = serviceStandard;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cP", "Pu", true)]
	[InlineData("cP", "", false)]
	[InlineData("", "Pu", true)]
	public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new Q6_ShipmentDetails();
		subject.ServiceLevelCode2 = serviceLevelCode2;
		subject.ServiceLevelCode = serviceLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.ServiceStandard))
		{
			subject.UnitOfTimePeriodOrInterval = "9I";
			subject.ServiceStandard = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
