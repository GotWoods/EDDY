using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSS*d*87*3y*i*1*0*j*6*f";

		var expected = new SSS_ProductSpecialServices()
		{
			AllowanceOrChargeIndicatorCode = "d",
			AgencyQualifierCode = "87",
			SpecialServicesCode = "3y",
			ServiceMarksAndNumbers = "i",
			AllowanceOrChargeRate = 1,
			Amount = "0",
			Description = "j",
			Quantity = 6,
			SourceSubqualifier = "f",
		};

		var actual = Map.MapObject<SSS_ProductSpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredAllowanceOrChargeIndicatorCode(string allowanceOrChargeIndicatorCode, bool isValidExpected)
	{
		var subject = new SSS_ProductSpecialServices();
		subject.AgencyQualifierCode = "87";
		subject.SpecialServicesCode = "3y";
		subject.AllowanceOrChargeIndicatorCode = allowanceOrChargeIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("87", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SSS_ProductSpecialServices();
		subject.AllowanceOrChargeIndicatorCode = "d";
		subject.SpecialServicesCode = "3y";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3y", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new SSS_ProductSpecialServices();
		subject.AllowanceOrChargeIndicatorCode = "d";
		subject.AgencyQualifierCode = "87";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
