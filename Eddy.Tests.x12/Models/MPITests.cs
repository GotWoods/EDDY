using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MPI*g*lo*B*M*9F*jM*s";

		var expected = new MPI_MilitaryPersonnelInformation()
		{
			InformationStatusCode = "g",
			EmploymentStatusCode = "lo",
			GovernmentServiceAffiliationCode = "B",
			Description = "M",
			MilitaryServiceRankCode = "9F",
			DateTimePeriodFormatQualifier = "jM",
			DateTimePeriod = "s",
		};

		var actual = Map.MapObject<MPI_MilitaryPersonnelInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredInformationStatusCode(string informationStatusCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		subject.EmploymentStatusCode = "lo";
		subject.GovernmentServiceAffiliationCode = "B";
		subject.InformationStatusCode = informationStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lo", true)]
	public void Validation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		subject.InformationStatusCode = "g";
		subject.GovernmentServiceAffiliationCode = "B";
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredGovernmentServiceAffiliationCode(string governmentServiceAffiliationCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		subject.InformationStatusCode = "g";
		subject.EmploymentStatusCode = "lo";
		subject.GovernmentServiceAffiliationCode = governmentServiceAffiliationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("jM", "s", true)]
	[InlineData("", "s", false)]
	[InlineData("jM", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		subject.InformationStatusCode = "g";
		subject.EmploymentStatusCode = "lo";
		subject.GovernmentServiceAffiliationCode = "B";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
