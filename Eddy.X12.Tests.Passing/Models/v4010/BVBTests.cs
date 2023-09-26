using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BVBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVB*l4*Z*XK*Y*oZ*8*Dm";

		var expected = new BVB_BeginningSegmentForVehicleBayingOrder()
		{
			StandardCarrierAlphaCode = "l4",
			IdentificationCodeQualifier = "Z",
			IdentificationCode = "XK",
			BayTypeCode = "Y",
			CapacityQualifier = "oZ",
			Quantity = 8,
			TransactionSetPurposeCode = "Dm",
		};

		var actual = Map.MapObject<BVB_BeginningSegmentForVehicleBayingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = "XK";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "oZ";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "l4";
		subject.IdentificationCode = "XK";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "oZ";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XK", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "l4";
		subject.IdentificationCodeQualifier = "Z";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "oZ";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("oZ", 8, true)]
	[InlineData("oZ", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredCapacityQualifier(string capacityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "l4";
		subject.IdentificationCodeQualifier = "Z";
		subject.IdentificationCode = "XK";
		//Test Parameters
		subject.CapacityQualifier = capacityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
