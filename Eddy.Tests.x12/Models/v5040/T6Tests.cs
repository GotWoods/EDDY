using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class T6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T6*1*9*Zi*7c*7*WV*8p";

		var expected = new T6_TransitInboundRates()
		{
			AssignedNumber = 1,
			FreightRate = 9,
			RateValueQualifier = "Zi",
			CityName = "7c",
			FreightRate2 = 7,
			RateValueQualifier2 = "WV",
			CityName2 = "8p",
		};

		var actual = Map.MapObject<T6_TransitInboundRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "Zi";
		}
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 7;
			subject.RateValueQualifier2 = "WV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "Zi", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "Zi", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		subject.AssignedNumber = 1;
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.FreightRate2 > 0 || subject.FreightRate2 > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier2))
		{
			subject.FreightRate2 = 7;
			subject.RateValueQualifier2 = "WV";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "WV", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "WV", false)]
	public void Validation_AllAreRequiredFreightRate2(decimal freightRate2, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		subject.AssignedNumber = 1;
		if (freightRate2 > 0)
			subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier2 = rateValueQualifier2;
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "Zi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
