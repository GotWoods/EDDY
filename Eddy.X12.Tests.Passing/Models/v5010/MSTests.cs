using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class MSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS*Dr*sp*6*ZF*Y*1";

		var expected = new MS_MiscellaneousServices()
		{
			AgencyQualifierCode = "Dr",
			SpecialServicesCode = "sp",
			AmountCharged = "6",
			RateValueQualifier = "ZF",
			AmountCharged2 = "Y",
			AssignedNumber = 1,
		};

		var actual = Map.MapObject<MS_MiscellaneousServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dr", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.SpecialServicesCode = "sp";
		subject.AmountCharged = "6";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sp", true)]
	public void Validation_RequiredSpecialServicesCode(string specialServicesCode, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "Dr";
		subject.AmountCharged = "6";
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
	{
		var subject = new MS_MiscellaneousServices();
		subject.AgencyQualifierCode = "Dr";
		subject.SpecialServicesCode = "sp";
		subject.AmountCharged = amountCharged;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
