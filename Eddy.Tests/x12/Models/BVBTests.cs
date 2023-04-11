using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BVBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVB*I9*k*oq*8*m8*8*1Y";

		var expected = new BVB_BeginningSegmentForVehicleBayingOrder()
		{
			StandardCarrierAlphaCode = "I9",
			IdentificationCodeQualifier = "k",
			IdentificationCode = "oq",
			BayTypeCode = "8",
			CapacityQualifier = "m8",
			Quantity = 8,
			TransactionSetPurposeCode = "1Y",
		};

		var actual = Map.MapObject<BVB_BeginningSegmentForVehicleBayingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("I9", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		subject.IdentificationCodeQualifier = "k";
		subject.IdentificationCode = "oq";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		subject.StandardCarrierAlphaCode = "I9";
		subject.IdentificationCode = "oq";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oq", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		subject.StandardCarrierAlphaCode = "I9";
		subject.IdentificationCodeQualifier = "k";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("m8", 8, true)]
	[InlineData("", 8, false)]
	[InlineData("m8", 0, false)]
	public void Validation_AllAreRequiredCapacityQualifier(string capacityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		subject.StandardCarrierAlphaCode = "I9";
		subject.IdentificationCodeQualifier = "k";
		subject.IdentificationCode = "oq";
		subject.CapacityQualifier = capacityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
