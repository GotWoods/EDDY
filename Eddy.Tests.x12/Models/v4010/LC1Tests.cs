using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LC1*5*pl*3*n*Xp*4*z*1*4*4*lw*3";

		var expected = new LC1_LaneCommitments()
		{
			NumberOfShipments = 5,
			UnitOrBasisForMeasurementCode = "pl",
			Number = 3,
			TransportationMethodTypeCode = "n",
			StandardCarrierAlphaCode = "Xp",
			NumberOfShipments2 = 4,
			YesNoConditionOrResponseCode = "z",
			LaneRanking = 1,
			FreightRate = 4,
			FreightRate2 = 4,
			RateValueQualifier = "lw",
			YesNoConditionOrResponseCode2 = "3",
		};

		var actual = Map.MapObject<LC1_LaneCommitments>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "pl", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "pl", false)]
	public void Validation_AllAreRequiredNumberOfShipments(int numberOfShipments, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		//Required fields
		//Test Parameters
		if (numberOfShipments > 0) 
			subject.NumberOfShipments = numberOfShipments;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.FreightRate > 0 || subject.FreightRate2 > 0)
		{
			subject.RateValueQualifier = "lw";
			subject.FreightRate = 4;
			subject.FreightRate2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "lw", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "lw", true)]
	public void Validation_ARequiresBFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		//Required fields
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one filled, all required
		if(subject.NumberOfShipments > 0 || subject.NumberOfShipments > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfShipments = 5;
			subject.UnitOrBasisForMeasurementCode = "pl";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || subject.FreightRate2 > 0)
		{
			subject.FreightRate2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "lw", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "lw", true)]
	public void Validation_ARequiresBFreightRate2(decimal freightRate2, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		//Required fields
		//Test Parameters
		if (freightRate2 > 0) 
			subject.FreightRate2 = freightRate2;
		subject.RateValueQualifier = rateValueQualifier;
		//If one filled, all required
		if(subject.NumberOfShipments > 0 || subject.NumberOfShipments > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfShipments = 5;
			subject.UnitOrBasisForMeasurementCode = "pl";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || subject.FreightRate > 0)
		{
			subject.FreightRate = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("lw", 4, 4, true)]
	[InlineData("lw", 0, 0, false)]
	[InlineData("", 4, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_RateValueQualifier(string rateValueQualifier, decimal freightRate, decimal freightRate2, bool isValidExpected)
	{
		var subject = new LC1_LaneCommitments();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		if (freightRate2 > 0) 
			subject.FreightRate2 = freightRate2;
		//A Requires B
		if (freightRate > 0)
			subject.RateValueQualifier = "lw";
		if (freightRate2 > 0)
			subject.RateValueQualifier = "lw";
		//If one filled, all required
		if(subject.NumberOfShipments > 0 || subject.NumberOfShipments > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfShipments = 5;
			subject.UnitOrBasisForMeasurementCode = "pl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
