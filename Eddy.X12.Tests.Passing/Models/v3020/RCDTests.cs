using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCD*q*3*I6*1*Eu*4*zV*rd*4*7S*iE*1*D6*dF*3*DP*Lu*7*rf*vC*3";

		var expected = new RCD_ReceivingConditions()
		{
			AssignedIdentification = "q",
			QuantityUnitsReceivedOrAccepted = 3,
			UnitOfMeasurementCode = "I6",
			QuantityUnitsReturned = 1,
			UnitOfMeasurementCode2 = "Eu",
			QuantityInQuestion = 4,
			UnitOfMeasurementCode3 = "zV",
			ReceivingConditionCode = "rd",
			QuantityInQuestion2 = 4,
			UnitOfMeasurementCode4 = "7S",
			ReceivingConditionCode2 = "iE",
			QuantityInQuestion3 = 1,
			UnitOfMeasurementCode5 = "D6",
			ReceivingConditionCode3 = "dF",
			QuantityInQuestion4 = 3,
			UnitOfMeasurementCode6 = "DP",
			ReceivingConditionCode4 = "Lu",
			QuantityInQuestion5 = 7,
			UnitOfMeasurementCode7 = "rf",
			ReceivingConditionCode5 = "vC",
			Quantity = 3,
		};

		var actual = Map.MapObject<RCD_ReceivingConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "I6", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "I6", true)]
	public void Validation_ARequiresBQuantityUnitsReceivedOrAccepted(decimal quantityUnitsReceivedOrAccepted, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		//Required fields
		//Test Parameters
		if (quantityUnitsReceivedOrAccepted > 0) 
			subject.QuantityUnitsReceivedOrAccepted = quantityUnitsReceivedOrAccepted;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Eu", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Eu", true)]
	public void Validation_ARequiresBQuantityUnitsReturned(decimal quantityUnitsReturned, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new RCD_ReceivingConditions();
		//Required fields
		//Test Parameters
		if (quantityUnitsReturned > 0) 
			subject.QuantityUnitsReturned = quantityUnitsReturned;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
