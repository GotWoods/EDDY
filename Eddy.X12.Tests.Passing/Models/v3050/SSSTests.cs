using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSS*0*xg*vg*4*1*9*u*4*D";

		var expected = new SSS_SpecialServices()
		{
			AllowanceOrChargeIndicator = "0",
			AgencyQualifierCode = "xg",
			SpecialServicesCode = "vg",
			ServiceMarksAndNumbers = "4",
			AllowanceOrChargeRate = 1,
			Amount = "9",
			Description = "u",
			Quantity = 4,
			SourceSubqualifier = "D",
		};

		var actual = Map.MapObject<SSS_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AgencyQualifierCode = "xg";
		subject.SpecialServicesCode = "vg";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xg", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "0";
		subject.SpecialServicesCode = "vg";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vg", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "0";
		subject.AgencyQualifierCode = "xg";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
