using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSS*3*gf*ZV*8*2*6*7*9*D";

		var expected = new SSS_SpecialServices()
		{
			AllowanceOrChargeIndicator = "3",
			AgencyQualifierCode = "gf",
			SpecialServicesCode = "ZV",
			ServiceMarksAndNumbers = "8",
			AllowanceOrChargeRate = 2,
			AllowanceOrChargeTotalAmount = "6",
			Description = "7",
			Quantity = 9,
			SourceSubqualifier = "D",
		};

		var actual = Map.MapObject<SSS_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AgencyQualifierCode = "gf";
		subject.SpecialServicesCode = "ZV";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gf", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "3";
		subject.SpecialServicesCode = "ZV";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZV", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "3";
		subject.AgencyQualifierCode = "gf";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
