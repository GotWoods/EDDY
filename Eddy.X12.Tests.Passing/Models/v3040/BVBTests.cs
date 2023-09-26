using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BVBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVB*S4*s*T9*J*IF*1*Zf";

		var expected = new BVB_BeginningSegmentForVehicleBayingOrder()
		{
			StandardCarrierAlphaCode = "S4",
			IdentificationCodeQualifier = "s",
			IdentificationCode = "T9",
			BayTypeCode = "J",
			CapacityQualifier = "IF",
			Quantity = 1,
			TransactionSetPurposeCode = "Zf",
		};

		var actual = Map.MapObject<BVB_BeginningSegmentForVehicleBayingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.IdentificationCodeQualifier = "s";
		subject.IdentificationCode = "T9";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "IF";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "S4";
		subject.IdentificationCode = "T9";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "IF";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T9", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "S4";
		subject.IdentificationCodeQualifier = "s";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "IF";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("IF", 1, true)]
	[InlineData("IF", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredCapacityQualifier(string capacityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "S4";
		subject.IdentificationCodeQualifier = "s";
		subject.IdentificationCode = "T9";
		//Test Parameters
		subject.CapacityQualifier = capacityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
