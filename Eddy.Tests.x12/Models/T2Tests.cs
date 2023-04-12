using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class T2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T2*6*U*5*2*3*bx*6*Ho*Eq*Ls*56*gR";

		var expected = new T2_TransitInboundLading()
		{
			AssignedNumber = 6,
			LadingDescription = "U",
			Weight = 5,
			WeightQualifier = "2",
			FreightRate = 3,
			RateValueQualifier = "bx",
			FreightRate2 = 6,
			RateValueQualifier2 = "Ho",
			CityName = "Eq",
			CityName2 = "Ls",
			ThroughSurchargePercent = "56",
			PaidInSurchargePercent = "gR",
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
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "bx", true)]
	[InlineData(0, "bx", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 6;
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "Ho", true)]
	[InlineData(0, "Ho", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredFreightRate2(decimal freightRate2, string rateValueQualifier2, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		subject.AssignedNumber = 6;
		if (freightRate2 > 0)
		subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier2 = rateValueQualifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
