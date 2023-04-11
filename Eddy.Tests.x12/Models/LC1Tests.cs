using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LC1*2*VY*7*l*7f*7*1*2*8*5*qG*3";

		var expected = new LC1_LaneCommitments()
		{
			NumberOfShipments = 2,
			UnitOrBasisForMeasurementCode = "VY",
			Number = 7,
			TransportationMethodTypeCode = "l",
			StandardCarrierAlphaCode = "7f",
			NumberOfShipments2 = 7,
			YesNoConditionOrResponseCode = "1",
			LaneRanking = 2,
			FreightRate = 8,
			FreightRate2 = 5,
			RateValueQualifier = "qG",
			YesNoConditionOrResponseCode2 = "3",
		};

		var actual = Map.MapObject<LC1_LaneCommitments>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "VY", true)]
	[InlineData(0, "VY", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredNumberOfShipments(int numberOfShipments, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		if (numberOfShipments > 0)
		subject.NumberOfShipments = numberOfShipments;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "qG", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "qG", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBFreightRate2(decimal freightRate2, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		if (freightRate2 > 0)
		subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier = rateValueQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("qG", 8, false)]
	[InlineData("",8, true)]
	[InlineData("qG", 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RateValueQualifier(string rateValueQualifier, decimal freightRate, decimal freightRate2, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		subject.RateValueQualifier = rateValueQualifier;
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		if (freightRate2 > 0)
		subject.FreightRate2 = freightRate2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
