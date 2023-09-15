using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class F06Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F06*6*H*9*M*jXC*cgaunl*A1HvPP";

		var expected = new F06_IdentificationAutomotive()
		{
			VehicleIdentificationNumber = "6",
			ReferenceNumber = "H",
			ReferenceNumber2 = "9",
			ReferenceNumber3 = "M",
			CarriersDeliveryReceiptNumber = "jXC",
			Date = "cgaunl",
			Date2 = "A1HvPP",
		};

		var actual = Map.MapObject<F06_IdentificationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.ReferenceNumber = "H";
		subject.ReferenceNumber2 = "9";
		subject.ReferenceNumber3 = "M";
		subject.CarriersDeliveryReceiptNumber = "jXC";
		subject.Date = "cgaunl";
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "6";
		subject.ReferenceNumber2 = "9";
		subject.ReferenceNumber3 = "M";
		subject.CarriersDeliveryReceiptNumber = "jXC";
		subject.Date = "cgaunl";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "6";
		subject.ReferenceNumber = "H";
		subject.ReferenceNumber3 = "M";
		subject.CarriersDeliveryReceiptNumber = "jXC";
		subject.Date = "cgaunl";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceNumber3(string referenceNumber3, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "6";
		subject.ReferenceNumber = "H";
		subject.ReferenceNumber2 = "9";
		subject.CarriersDeliveryReceiptNumber = "jXC";
		subject.Date = "cgaunl";
		subject.ReferenceNumber3 = referenceNumber3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jXC", true)]
	public void Validation_RequiredCarriersDeliveryReceiptNumber(string carriersDeliveryReceiptNumber, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "6";
		subject.ReferenceNumber = "H";
		subject.ReferenceNumber2 = "9";
		subject.ReferenceNumber3 = "M";
		subject.Date = "cgaunl";
		subject.CarriersDeliveryReceiptNumber = carriersDeliveryReceiptNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cgaunl", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F06_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "6";
		subject.ReferenceNumber = "H";
		subject.ReferenceNumber2 = "9";
		subject.ReferenceNumber3 = "M";
		subject.CarriersDeliveryReceiptNumber = "jXC";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
