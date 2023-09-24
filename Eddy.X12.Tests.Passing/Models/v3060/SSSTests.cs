using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SSS*7*KU*eY*J*4*z*1*1*z";

		var expected = new SSS_SpecialServices()
		{
			AllowanceOrChargeIndicator = "7",
			AgencyQualifierCode = "KU",
			SpecialServicesCode = "eY",
			ServiceMarksAndNumbers = "J",
			AllowanceOrChargeRate = 4,
			Amount = "z",
			Description = "1",
			Quantity = 1,
			SourceSubqualifier = "z",
		};

		var actual = Map.MapObject<SSS_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredAllowanceOrChargeIndicator(string allowanceOrChargeIndicator, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AgencyQualifierCode = "KU";
		subject.SpecialServicesCode = "eY";
		subject.AllowanceOrChargeIndicator = allowanceOrChargeIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KU", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "7";
		subject.SpecialServicesCode = "eY";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eY", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new SSS_SpecialServices();
		subject.AllowanceOrChargeIndicator = "7";
		subject.AgencyQualifierCode = "KU";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
