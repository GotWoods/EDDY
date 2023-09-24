using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS*Ln*S8*R*8I*f*1";

		var expected = new MS_MiscellaneousServices()
		{
			AgencyQualifierCode = "Ln",
			SpecialServicesCode = "S8",
			Charge = "R",
			RateValueQualifier = "8I",
			Charge2 = "f",
			AssignedNumber = 1,
		};

		var actual = Map.MapObject<MS_MiscellaneousServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ln", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.SpecialServicesCode = "S8";
		subject.Charge = "R";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S8", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "Ln";
		subject.Charge = "R";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredCharge(string charge, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "Ln";
		subject.SpecialServicesCode = "S8";
		subject.Charge = charge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
