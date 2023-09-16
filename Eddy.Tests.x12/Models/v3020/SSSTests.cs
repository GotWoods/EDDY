using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSS*b*IM*Xv*x*2*8*t*5";

		var expected = new SSS_SpecialServices()
		{
			AllowanceOrChargeIndicator = "b",
			AgencyQualifierCode = "IM",
			SpecialServicesCode = "Xv",
			ServiceMarksAndNumbers = "x",
			AllowanceOrChargeRate = 2,
			AllowanceOrChargeTotalAmount = "8",
			Description = "t",
			Quantity = 5,
		};

		var actual = Map.MapObject<SSS_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AgencyQualifierCode = "IM";
		subject.SpecialServicesCode = "Xv";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IM", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "b";
		subject.SpecialServicesCode = "Xv";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xv", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "b";
		subject.AgencyQualifierCode = "IM";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
