using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSS*k*8h*lw*9*5*1*q*7*T";

		var expected = new SSS_ProductSpecialServices()
		{
			AllowanceOrChargeIndicatorCode = "k",
			AgencyQualifierCode = "8h",
			SpecialServicesCode = "lw",
			ServiceMarksAndNumbers = "9",
			AllowanceOrChargeRate = 5,
			Amount = "1",
			Description = "q",
			Quantity = 7,
			SourceSubqualifier = "T",
		};

		var actual = Map.MapObject<SSS_ProductSpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredAllowanceOrChargeIndicatorCode(string allowanceOrChargeIndicatorCode, bool isValidExpected)
	{
		var subject = new SSS_ProductSpecialServices();
		subject.AgencyQualifierCode = "8h";
		subject.SpecialServicesCode = "lw";
		subject.AllowanceOrChargeIndicatorCode = allowanceOrChargeIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8h", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SSS_ProductSpecialServices();
		subject.AllowanceOrChargeIndicatorCode = "k";
		subject.SpecialServicesCode = "lw";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lw", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new SSS_ProductSpecialServices();
		subject.AllowanceOrChargeIndicatorCode = "k";
		subject.AgencyQualifierCode = "8h";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
