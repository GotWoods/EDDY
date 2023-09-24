using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class T2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T2*9*n*8*Q*1*wL*8*wE*rC*mh*Km*oI";

		var expected = new T2_TransitInboundLading()
		{
			AssignedNumber = 9,
			LadingDescription = "n",
			Weight = 8,
			WeightQualifier = "Q",
			FreightRate = 1,
			RateValueQualifier = "wL",
			FreightRate2 = 8,
			RateValueQualifier2 = "wE",
			CityName = "rC",
			CityName2 = "mh",
			ThroughSurchargePercent = "Km",
			PaidInSurchargePercent = "oI",
		};

		var actual = Map.MapObject<T2_TransitInboundLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "wL";
		}
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 8;
			subject.RateValueQualifier2 = "wE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "wL", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "wL", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 9;
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 8;
			subject.RateValueQualifier2 = "wE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "wE", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "wE", false)]
	public void Validation_AllAreRequiredFreightRate2(decimal freightRate2, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 9;
		if (freightRate2 > 0)
			subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 1;
			subject.RateValueQualifier = "wL";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
