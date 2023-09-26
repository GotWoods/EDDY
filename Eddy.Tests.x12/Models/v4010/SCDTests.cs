using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCD*E7*jnxYWYTT*vN*kx8PTWgm*RF*4*L";

		var expected = new SCD_SalesCommissionEmployeeDetail()
		{
			EmploymentStatusCode = "E7",
			Date = "jnxYWYTT",
			EmploymentStatusCode2 = "vN",
			Date2 = "kx8PTWgm",
			AgencyQualifierCode = "RF",
			IndustryCode = "4",
			GenderCode = "L",
		};

		var actual = Map.MapObject<SCD_SalesCommissionEmployeeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E7", true)]
	public void Validation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		//Required fields
		//Test Parameters
		subject.EmploymentStatusCode = employmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.AgencyQualifierCode = "RF";
			subject.IndustryCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kx8PTWgm", "vN", true)]
	[InlineData("kx8PTWgm", "", false)]
	[InlineData("", "vN", true)]
	public void Validation_ARequiresBDate2(string date2, string employmentStatusCode2, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		//Required fields
		subject.EmploymentStatusCode = "E7";
		//Test Parameters
		subject.Date2 = date2;
		subject.EmploymentStatusCode2 = employmentStatusCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.AgencyQualifierCode = "RF";
			subject.IndustryCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RF", "4", true)]
	[InlineData("RF", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		//Required fields
		subject.EmploymentStatusCode = "E7";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
