using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class T6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T6*6*8*bH*cr*9*gl*qQ";

		var expected = new T6_TransitInboundRates()
		{
			AssignedNumber = 6,
			FreightRate = 8,
			RateValueQualifier = "bH",
			CityName = "cr",
			FreightRate2 = 9,
			RateValueQualifier2 = "gl",
			CityName2 = "qQ",
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
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "bH", true)]
	[InlineData(0, "bH", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		subject.AssignedNumber = 6;
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "gl", true)]
	[InlineData(0, "gl", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredFreightRate2(decimal freightRate2, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		subject.AssignedNumber = 6;
		if (freightRate2 > 0)
		subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier2 = rateValueQualifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
