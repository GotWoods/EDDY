using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Q6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q6*3*P*U*2*DyZ*3B*6*cpF*Pa*O*gH*ud";

		var expected = new Q6_ShipmentDetails()
		{
			Weight = 3,
			WeightUnitCode = "P",
			WeightQualifier = "U",
			LadingQuantity = 2,
			PackagingFormCode = "DyZ",
			ShipmentMethodOfPayment = "3B",
			NetAmountDue = "6",
			CurrencyCode = "cpF",
			UnitOfTimePeriodOrInterval = "Pa",
			ServiceStandard = "O",
			ServiceLevelCode = "gH",
			ServiceLevelCode2 = "ud",
		};

		var actual = Map.MapObject<Q6_ShipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Pa", "O", true)]
	[InlineData("Pa", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, string serviceStandard, bool isValidExpected)
	{
		var subject = new Q6_ShipmentDetails();
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		subject.ServiceStandard = serviceStandard;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ud", "gH", true)]
	[InlineData("ud", "", false)]
	[InlineData("", "gH", true)]
	public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new Q6_ShipmentDetails();
		subject.ServiceLevelCode2 = serviceLevelCode2;
		subject.ServiceLevelCode = serviceLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval) || !string.IsNullOrEmpty(subject.ServiceStandard))
		{
			subject.UnitOfTimePeriodOrInterval = "Pa";
			subject.ServiceStandard = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
