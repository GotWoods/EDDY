using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MPI*h*Rf*B*0*7J*MB*u";

		var expected = new MPI_MilitaryPersonnelInformation()
		{
			InformationStatusCode = "h",
			EmploymentStatusCode = "Rf",
			GovernmentServiceAffiliationCode = "B",
			Description = "0",
			MilitaryServiceRankCode = "7J",
			DateTimePeriodFormatQualifier = "MB",
			DateTimePeriod = "u",
		};

		var actual = Map.MapObject<MPI_MilitaryPersonnelInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredInformationStatusCode(string informationStatusCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.EmploymentStatusCode = "Rf";
		subject.GovernmentServiceAffiliationCode = "B";
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "MB";
			subject.DateTimePeriod = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rf", true)]
	public void Validation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.InformationStatusCode = "h";
		subject.GovernmentServiceAffiliationCode = "B";
		//Test Parameters
		subject.EmploymentStatusCode = employmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "MB";
			subject.DateTimePeriod = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredGovernmentServiceAffiliationCode(string governmentServiceAffiliationCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.InformationStatusCode = "h";
		subject.EmploymentStatusCode = "Rf";
		//Test Parameters
		subject.GovernmentServiceAffiliationCode = governmentServiceAffiliationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "MB";
			subject.DateTimePeriod = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MB", "u", true)]
	[InlineData("MB", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.InformationStatusCode = "h";
		subject.EmploymentStatusCode = "Rf";
		subject.GovernmentServiceAffiliationCode = "B";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
