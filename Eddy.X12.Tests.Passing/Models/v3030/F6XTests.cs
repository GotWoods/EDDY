using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class F6XTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F6X*m*MT*Gy*m*kL*a*bPzaai*JGDLYJ";

		var expected = new F6X_IdentificationAutomotive()
		{
			VehicleIdentificationNumber = "m",
			AutomotiveManufacturersCode = "MT",
			DealerCode = "Gy",
			IdentificationCodeQualifier = "m",
			IdentificationCode = "kL",
			InvoiceNumber = "a",
			Date = "bPzaai",
			Date2 = "JGDLYJ",
		};

		var actual = Map.MapObject<F6X_IdentificationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.AutomotiveManufacturersCode = "MT";
		subject.DealerCode = "Gy";
		subject.IdentificationCodeQualifier = "m";
		subject.IdentificationCode = "kL";
		subject.InvoiceNumber = "a";
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MT", true)]
	public void Validation_RequiredAutomotiveManufacturersCode(string automotiveManufacturersCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "m";
		subject.DealerCode = "Gy";
		subject.IdentificationCodeQualifier = "m";
		subject.IdentificationCode = "kL";
		subject.InvoiceNumber = "a";
		//Test Parameters
		subject.AutomotiveManufacturersCode = automotiveManufacturersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gy", true)]
	public void Validation_RequiredDealerCode(string dealerCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "m";
		subject.AutomotiveManufacturersCode = "MT";
		subject.IdentificationCodeQualifier = "m";
		subject.IdentificationCode = "kL";
		subject.InvoiceNumber = "a";
		//Test Parameters
		subject.DealerCode = dealerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "m";
		subject.AutomotiveManufacturersCode = "MT";
		subject.DealerCode = "Gy";
		subject.IdentificationCode = "kL";
		subject.InvoiceNumber = "a";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kL", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "m";
		subject.AutomotiveManufacturersCode = "MT";
		subject.DealerCode = "Gy";
		subject.IdentificationCodeQualifier = "m";
		subject.InvoiceNumber = "a";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "m";
		subject.AutomotiveManufacturersCode = "MT";
		subject.DealerCode = "Gy";
		subject.IdentificationCodeQualifier = "m";
		subject.IdentificationCode = "kL";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
