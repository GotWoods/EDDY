using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BVBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVB*z8*S*Ui*k*ha*4*HS";

		var expected = new BVB_BeginningSegmentForVehicleBayingOrder()
		{
			StandardCarrierAlphaCode = "z8",
			IdentificationCodeQualifier = "S",
			IdentificationCode = "Ui",
			BayTypeCode = "k",
			CapacityQualifier = "ha",
			Quantity = 4,
			TransactionSetPurposeCode = "HS",
		};

		var actual = Map.MapObject<BVB_BeginningSegmentForVehicleBayingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.IdentificationCodeQualifier = "S";
		subject.IdentificationCode = "Ui";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "ha";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "z8";
		subject.IdentificationCode = "Ui";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "ha";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ui", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "z8";
		subject.IdentificationCodeQualifier = "S";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CapacityQualifier) || !string.IsNullOrEmpty(subject.CapacityQualifier) || subject.Quantity > 0)
		{
			subject.CapacityQualifier = "ha";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ha", 4, true)]
	[InlineData("ha", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredCapacityQualifier(string capacityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new BVB_BeginningSegmentForVehicleBayingOrder();
		//Required fields
		subject.StandardCarrierAlphaCode = "z8";
		subject.IdentificationCodeQualifier = "S";
		subject.IdentificationCode = "Ui";
		//Test Parameters
		subject.CapacityQualifier = capacityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
