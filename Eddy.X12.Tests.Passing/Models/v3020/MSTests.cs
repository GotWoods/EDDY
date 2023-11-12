using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class MSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS*vC*Ir*p*HC*G*7";

		var expected = new MS_MiscellaneousServices()
		{
			AgencyQualifierCode = "vC",
			SpecialServicesCode = "Ir",
			Charge = "p",
			RateValueQualifier = "HC",
			Charge2 = "G",
			AssignedNumber = 7,
		};

		var actual = Map.MapObject<MS_MiscellaneousServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vC", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.SpecialServicesCode = "Ir";
		subject.Charge = "p";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ir", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "vC";
		subject.Charge = "p";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "vC";
		subject.SpecialServicesCode = "Ir";
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
