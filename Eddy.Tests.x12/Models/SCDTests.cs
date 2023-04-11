using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCD*de*hsTtlxoh*Th*Q5juwN5g*Yt*I*c";

		var expected = new SCD_SalesCommissionEmployeeDetail()
		{
			EmploymentStatusCode = "de",
			Date = "hsTtlxoh",
			EmploymentStatusCode2 = "Th",
			Date2 = "Q5juwN5g",
			AgencyQualifierCode = "Yt",
			IndustryCode = "I",
			GenderCode = "c",
		};

		var actual = Map.MapObject<SCD_SalesCommissionEmployeeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("de", true)]
	public void Validation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Th", true)]
	[InlineData("Q5juwN5g", "", false)]
	public void Validation_ARequiresBDate2(string date2, string employmentStatusCode2, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		subject.EmploymentStatusCode = "de";
		subject.Date2 = date2;
		subject.EmploymentStatusCode2 = employmentStatusCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Yt", "I", true)]
	[InlineData("", "I", false)]
	[InlineData("Yt", "", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SCD_SalesCommissionEmployeeDetail();
		subject.EmploymentStatusCode = "de";
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
