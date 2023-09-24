using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class MSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS*M1*Rx*v*bE*G*6";

		var expected = new MS_MiscellaneousServices()
		{
			AgencyQualifierCode = "M1",
			SpecialServicesCode = "Rx",
			AmountCharged = "v",
			RateValueQualifier = "bE",
			AmountCharged2 = "G",
			AssignedNumber = 6,
		};

		var actual = Map.MapObject<MS_MiscellaneousServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M1", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.SpecialServicesCode = "Rx";
		subject.AmountCharged = "v";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rx", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "M1";
		subject.AmountCharged = "v";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "M1";
		subject.SpecialServicesCode = "Rx";
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
