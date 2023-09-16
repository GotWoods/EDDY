using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class T2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T2*8*s*6*6*4*3T*8*VW*qe*2P*aG*Ht";

		var expected = new T2_TransitInboundLading()
		{
			AssignedNumber = 8,
			LadingDescription = "s",
			TransitPortionWeight = 6,
			WeightQualifier = "6",
			FreightRate = 4,
			RateValueQualifier = "3T",
			FreightRate2 = 8,
			RateValueQualifier2 = "VW",
			CityName = "qe",
			CityName2 = "2P",
			ThroughSurchargePercent = "aG",
			PaidInSurchargePercent = "Ht",
		};

		var actual = Map.MapObject<T2_TransitInboundLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 4;
			subject.RateValueQualifier = "3T";
		}
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 8;
			subject.RateValueQualifier2 = "VW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "3T", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "3T", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 8;
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 8;
			subject.RateValueQualifier2 = "VW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "VW", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "VW", false)]
	public void Validation_AllAreRequiredFreightRate2(decimal freightRate2, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 8;
		if (freightRate2 > 0)
			subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 4;
			subject.RateValueQualifier = "3T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
