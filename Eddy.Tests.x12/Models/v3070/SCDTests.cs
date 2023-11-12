using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCD*2E*UshyTR*uT*suHGqw*QX*i*O";

		var expected = new SCD_SalesCommissionEmployeeDetail()
		{
			EmploymentStatusCode = "2E",
			Date = "UshyTR",
			EmploymentStatusCode2 = "uT",
			Date2 = "suHGqw",
			AgencyQualifierCode = "QX",
			IndustryCode = "i",
			GenderCode = "O",
		};

		var actual = Map.MapObject<SCD_SalesCommissionEmployeeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2E", true)]
	public void Validation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		//Required fields
		//Test Parameters
		subject.EmploymentStatusCode = employmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.AgencyQualifierCode = "QX";
			subject.IndustryCode = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("suHGqw", "uT", true)]
	[InlineData("suHGqw", "", false)]
	[InlineData("", "uT", true)]
	public void Validation_ARequiresBDate2(string date2, string employmentStatusCode2, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		//Required fields
		subject.EmploymentStatusCode = "2E";
		//Test Parameters
		subject.Date2 = date2;
		subject.EmploymentStatusCode2 = employmentStatusCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.AgencyQualifierCode = "QX";
			subject.IndustryCode = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QX", "i", true)]
	[InlineData("QX", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		//Required fields
		subject.EmploymentStatusCode = "2E";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
