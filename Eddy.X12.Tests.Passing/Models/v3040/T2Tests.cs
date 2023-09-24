using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class T2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T2*6*3*3*t*6*ir*6*la*HC*pv*z2*Ko";

		var expected = new T2_TransitInboundLading()
		{
			AssignedNumber = 6,
			LadingDescription = "3",
			Weight = 3,
			WeightQualifier = "t",
			FreightRate = 6,
			RateValueQualifier = "ir",
			FreightRate2 = 6,
			RateValueQualifier2 = "la",
			CityName = "HC",
			CityName2 = "pv",
			ThroughSurchargePercent = "z2",
			PaidInSurchargePercent = "Ko",
		};

		var actual = Map.MapObject<T2_TransitInboundLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "ir";
		}
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 6;
			subject.RateValueQualifier2 = "la";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "ir", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "ir", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 6;
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 6;
			subject.RateValueQualifier2 = "la";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "la", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "la", false)]
	public void Validation_AllAreRequiredFreightRate2(decimal freightRate2, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 6;
		if (freightRate2 > 0)
			subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "ir";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
