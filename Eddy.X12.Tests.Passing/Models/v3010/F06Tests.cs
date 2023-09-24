using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F06*ipNy1YCqLMbY4B1kX*8*i*j*ZuO*Hpm3db*DNDLbC";

		var expected = new F06_IdentificationAutomotive()
		{
			VehicleIdentificationNumber = "ipNy1YCqLMbY4B1kX",
			ReferenceNumber = "8",
			ReferenceNumber2 = "i",
			ReferenceNumber3 = "j",
			CarriersDeliveryReceiptNumber = "ZuO",
			Date = "Hpm3db",
			Date2 = "DNDLbC",
		};

		var actual = Map.MapObject<F06_IdentificationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ipNy1YCqLMbY4B1kX", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.ReferenceNumber = "8";
		subject.ReferenceNumber2 = "i";
		subject.ReferenceNumber3 = "j";
		subject.CarriersDeliveryReceiptNumber = "ZuO";
		subject.Date = "Hpm3db";
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "ipNy1YCqLMbY4B1kX";
		subject.ReferenceNumber2 = "i";
		subject.ReferenceNumber3 = "j";
		subject.CarriersDeliveryReceiptNumber = "ZuO";
		subject.Date = "Hpm3db";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "ipNy1YCqLMbY4B1kX";
		subject.ReferenceNumber = "8";
		subject.ReferenceNumber3 = "j";
		subject.CarriersDeliveryReceiptNumber = "ZuO";
		subject.Date = "Hpm3db";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredReferenceNumber3(string referenceNumber3, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "ipNy1YCqLMbY4B1kX";
		subject.ReferenceNumber = "8";
		subject.ReferenceNumber2 = "i";
		subject.CarriersDeliveryReceiptNumber = "ZuO";
		subject.Date = "Hpm3db";
		subject.ReferenceNumber3 = referenceNumber3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZuO", true)]
	public void Validation_RequiredCarriersDeliveryReceiptNumber(string carriersDeliveryReceiptNumber, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "ipNy1YCqLMbY4B1kX";
		subject.ReferenceNumber = "8";
		subject.ReferenceNumber2 = "i";
		subject.ReferenceNumber3 = "j";
		subject.Date = "Hpm3db";
		subject.CarriersDeliveryReceiptNumber = carriersDeliveryReceiptNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hpm3db", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "ipNy1YCqLMbY4B1kX";
		subject.ReferenceNumber = "8";
		subject.ReferenceNumber2 = "i";
		subject.ReferenceNumber3 = "j";
		subject.CarriersDeliveryReceiptNumber = "ZuO";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
