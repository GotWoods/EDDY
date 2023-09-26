using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class F6XTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F6X*B*CC*9Z*g*IH*Q*FSX9YOxR*EUD1QLuo";

		var expected = new F6X_IdentificationAutomotive()
		{
			VehicleIdentificationNumber = "B",
			AutomotiveManufacturersCode = "CC",
			DealerCode = "9Z",
			IdentificationCodeQualifier = "g",
			IdentificationCode = "IH",
			InvoiceNumber = "Q",
			Date = "FSX9YOxR",
			Date2 = "EUD1QLuo",
		};

		var actual = Map.MapObject<F6X_IdentificationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.AutomotiveManufacturersCode = "CC";
		subject.DealerCode = "9Z";
		subject.IdentificationCodeQualifier = "g";
		subject.IdentificationCode = "IH";
		subject.InvoiceNumber = "Q";
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CC", true)]
	public void Validation_RequiredAutomotiveManufacturersCode(string automotiveManufacturersCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "B";
		subject.DealerCode = "9Z";
		subject.IdentificationCodeQualifier = "g";
		subject.IdentificationCode = "IH";
		subject.InvoiceNumber = "Q";
		//Test Parameters
		subject.AutomotiveManufacturersCode = automotiveManufacturersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Z", true)]
	public void Validation_RequiredDealerCode(string dealerCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "B";
		subject.AutomotiveManufacturersCode = "CC";
		subject.IdentificationCodeQualifier = "g";
		subject.IdentificationCode = "IH";
		subject.InvoiceNumber = "Q";
		//Test Parameters
		subject.DealerCode = dealerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "B";
		subject.AutomotiveManufacturersCode = "CC";
		subject.DealerCode = "9Z";
		subject.IdentificationCode = "IH";
		subject.InvoiceNumber = "Q";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IH", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "B";
		subject.AutomotiveManufacturersCode = "CC";
		subject.DealerCode = "9Z";
		subject.IdentificationCodeQualifier = "g";
		subject.InvoiceNumber = "Q";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "B";
		subject.AutomotiveManufacturersCode = "CC";
		subject.DealerCode = "9Z";
		subject.IdentificationCodeQualifier = "g";
		subject.IdentificationCode = "IH";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
