using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class F6XTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F6X*U*ue*Ka*D*n0*v*mBZRpFER*kXctLwT9";

		var expected = new F6X_IdentificationAutomotive()
		{
			VehicleIdentificationNumber = "U",
			AutomotiveManufacturersCode = "ue",
			DealerCode = "Ka",
			IdentificationCodeQualifier = "D",
			IdentificationCode = "n0",
			InvoiceNumber = "v",
			Date = "mBZRpFER",
			Date2 = "kXctLwT9",
		};

		var actual = Map.MapObject<F6X_IdentificationAutomotive>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.AutomotiveManufacturersCode = "ue";
		subject.DealerCode = "Ka";
		subject.IdentificationCodeQualifier = "D";
		subject.IdentificationCode = "n0";
		subject.InvoiceNumber = "v";
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ue", true)]
	public void Validation_RequiredAutomotiveManufacturersCode(string automotiveManufacturersCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "U";
		subject.DealerCode = "Ka";
		subject.IdentificationCodeQualifier = "D";
		subject.IdentificationCode = "n0";
		subject.InvoiceNumber = "v";
		//Test Parameters
		subject.AutomotiveManufacturersCode = automotiveManufacturersCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ka", true)]
	public void Validation_RequiredDealerCode(string dealerCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "U";
		subject.AutomotiveManufacturersCode = "ue";
		subject.IdentificationCodeQualifier = "D";
		subject.IdentificationCode = "n0";
		subject.InvoiceNumber = "v";
		//Test Parameters
		subject.DealerCode = dealerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "U";
		subject.AutomotiveManufacturersCode = "ue";
		subject.DealerCode = "Ka";
		subject.IdentificationCode = "n0";
		subject.InvoiceNumber = "v";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n0", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "U";
		subject.AutomotiveManufacturersCode = "ue";
		subject.DealerCode = "Ka";
		subject.IdentificationCodeQualifier = "D";
		subject.InvoiceNumber = "v";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredInvoiceNumber(string invoiceNumber, bool isValidExpected)
	{
		var subject = new F6X_IdentificationAutomotive();
		//Required fields
		subject.VehicleIdentificationNumber = "U";
		subject.AutomotiveManufacturersCode = "ue";
		subject.DealerCode = "Ka";
		subject.IdentificationCodeQualifier = "D";
		subject.IdentificationCode = "n0";
		//Test Parameters
		subject.InvoiceNumber = invoiceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
