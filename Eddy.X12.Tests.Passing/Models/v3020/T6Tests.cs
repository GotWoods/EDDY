using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class T6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T6*6*2*6N*z2*8*Ed*mz";

		var expected = new T6_TransitInboundRates()
		{
			AssignedNumber = 6,
			FreightRate = 2,
			RateValueQualifier = "6N",
			CityName = "z2",
			FreightRate2 = 8,
			RateValueQualifier2 = "Ed",
			CityName2 = "mz",
		};

		var actual = Map.MapObject<T6_TransitInboundRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 2;
			subject.RateValueQualifier = "6N";
		}
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 8;
			subject.RateValueQualifier2 = "Ed";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "6N", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "6N", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		subject.AssignedNumber = 6;
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 8;
			subject.RateValueQualifier2 = "Ed";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Ed", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Ed", false)]
	public void Validation_AllAreRequiredFreightRate2(decimal freightRate2, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		subject.AssignedNumber = 6;
		if (freightRate2 > 0)
			subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 2;
			subject.RateValueQualifier = "6N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
