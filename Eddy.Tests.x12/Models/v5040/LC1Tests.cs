using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class LC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LC1*1*Hu*2*h*Kk*9*6*1*1*9*ie*P";

		var expected = new LC1_LaneCommitments()
		{
			NumberOfShipments = 1,
			UnitOrBasisForMeasurementCode = "Hu",
			Number = 2,
			TransportationMethodTypeCode = "h",
			StandardCarrierAlphaCode = "Kk",
			NumberOfShipments2 = 9,
			YesNoConditionOrResponseCode = "6",
			LaneRanking = 1,
			FreightRate = 1,
			FreightRate2 = 9,
			RateValueQualifier = "ie",
			YesNoConditionOrResponseCode2 = "P",
		};

		var actual = Map.MapObject<LC1_LaneCommitments>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Hu", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Hu", false)]
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
			subject.RateValueQualifier = "ie";
			subject.FreightRate = 1;
			subject.FreightRate2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "ie", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "ie", true)]
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
			subject.NumberOfShipments = 1;
			subject.UnitOrBasisForMeasurementCode = "Hu";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || subject.FreightRate2 > 0)
		{
			subject.FreightRate2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "ie", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "ie", true)]
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
			subject.NumberOfShipments = 1;
			subject.UnitOrBasisForMeasurementCode = "Hu";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || subject.FreightRate > 0)
		{
			subject.FreightRate = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("ie", 1, 9, true)]
	[InlineData("ie", 0, 0, false)]
	[InlineData("", 1, 9, true)]
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
			subject.RateValueQualifier = "ie";
		if (freightRate2 > 0)
			subject.RateValueQualifier = "ie";
		//If one filled, all required
		if(subject.NumberOfShipments > 0 || subject.NumberOfShipments > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.NumberOfShipments = 1;
			subject.UnitOrBasisForMeasurementCode = "Hu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
