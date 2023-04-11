using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F6XTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F6X*R*SF*cD*R*Zl*p*zsKYMVaw*RSy95gYi";

		var expected = new F6X_IdentificationAutomotive()
		{
			VehicleIdentificationNumber = "R",
			AutomotiveManufacturersCode = "SF",
			DealerCode = "cD",
			IdentificationCodeQualifier = "R",
			IdentificationCode = "Zl",
			InvoiceNumber = "p",
			Date = "zsKYMVaw",
			Date2 = "RSy95gYi",
		};

		var actual = Map.MapObject<F6X_IdentificationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		subject.AutomotiveManufacturersCode = "SF";
		subject.DealerCode = "cD";
		subject.IdentificationCodeQualifier = "R";
		subject.IdentificationCode = "Zl";
		subject.InvoiceNumber = "p";
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SF", true)]
	public void Validation_RequiredAutomotiveManufacturersCode(string automotiveManufacturersCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "R";
		subject.DealerCode = "cD";
		subject.IdentificationCodeQualifier = "R";
		subject.IdentificationCode = "Zl";
		subject.InvoiceNumber = "p";
		subject.AutomotiveManufacturersCode = automotiveManufacturersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cD", true)]
	public void Validation_RequiredDealerCode(string dealerCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "R";
		subject.AutomotiveManufacturersCode = "SF";
		subject.IdentificationCodeQualifier = "R";
		subject.IdentificationCode = "Zl";
		subject.InvoiceNumber = "p";
		subject.DealerCode = dealerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "R";
		subject.AutomotiveManufacturersCode = "SF";
		subject.DealerCode = "cD";
		subject.IdentificationCode = "Zl";
		subject.InvoiceNumber = "p";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zl", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "R";
		subject.AutomotiveManufacturersCode = "SF";
		subject.DealerCode = "cD";
		subject.IdentificationCodeQualifier = "R";
		subject.InvoiceNumber = "p";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		subject.VehicleIdentificationNumber = "R";
		subject.AutomotiveManufacturersCode = "SF";
		subject.DealerCode = "cD";
		subject.IdentificationCodeQualifier = "R";
		subject.IdentificationCode = "Zl";
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}