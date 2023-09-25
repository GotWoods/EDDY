using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class F6XTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F6X*8*jE*ty*c*uR*7*3zr4Lw*aGMzzh";

		var expected = new F6X_IdentificationAutomotive()
		{
			VehicleIdentificationNumber = "8",
			AutomotiveManufacturersCode = "jE",
			DealerCode = "ty",
			IdentificationCodeQualifier = "c",
			IdentificationCode = "uR",
			InvoiceNumber = "7",
			Date = "3zr4Lw",
			Date2 = "aGMzzh",
		};

		var actual = Map.MapObject<F6X_IdentificationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.AutomotiveManufacturersCode = "jE";
		subject.DealerCode = "ty";
		subject.IdentificationCodeQualifier = "c";
		subject.IdentificationCode = "uR";
		subject.InvoiceNumber = "7";
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jE", true)]
	public void Validation_RequiredAutomotiveManufacturersCode(string automotiveManufacturersCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "8";
		subject.DealerCode = "ty";
		subject.IdentificationCodeQualifier = "c";
		subject.IdentificationCode = "uR";
		subject.InvoiceNumber = "7";
		//Test Parameters
		subject.AutomotiveManufacturersCode = automotiveManufacturersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ty", true)]
	public void Validation_RequiredDealerCode(string dealerCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "8";
		subject.AutomotiveManufacturersCode = "jE";
		subject.IdentificationCodeQualifier = "c";
		subject.IdentificationCode = "uR";
		subject.InvoiceNumber = "7";
		//Test Parameters
		subject.DealerCode = dealerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "8";
		subject.AutomotiveManufacturersCode = "jE";
		subject.DealerCode = "ty";
		subject.IdentificationCode = "uR";
		subject.InvoiceNumber = "7";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uR", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "8";
		subject.AutomotiveManufacturersCode = "jE";
		subject.DealerCode = "ty";
		subject.IdentificationCodeQualifier = "c";
		subject.InvoiceNumber = "7";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "8";
		subject.AutomotiveManufacturersCode = "jE";
		subject.DealerCode = "ty";
		subject.IdentificationCodeQualifier = "c";
		subject.IdentificationCode = "uR";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
