using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.Tests.Models.v6020;

public class MPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MPI*i*fg*G*k*dh*a2*R";

		var expected = new MPI_MilitaryPersonnelInformation()
		{
			InformationStatusCode = "i",
			EmploymentStatusCode = "fg",
			GovernmentServiceAffiliationCode = "G",
			Description = "k",
			MilitaryServiceRankCode = "dh",
			DateTimePeriodFormatQualifier = "a2",
			DateTimePeriod = "R",
		};

		var actual = Map.MapObject<MPI_MilitaryPersonnelInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredInformationStatusCode(string informationStatusCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.EmploymentStatusCode = "fg";
		subject.GovernmentServiceAffiliationCode = "G";
		//Test Parameters
		subject.InformationStatusCode = informationStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "a2";
			subject.DateTimePeriod = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fg", true)]
	public void Validation_RequiredEmploymentStatusCode(string employmentStatusCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.InformationStatusCode = "i";
		subject.GovernmentServiceAffiliationCode = "G";
		//Test Parameters
		subject.EmploymentStatusCode = employmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "a2";
			subject.DateTimePeriod = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredGovernmentServiceAffiliationCode(string governmentServiceAffiliationCode, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.InformationStatusCode = "i";
		subject.EmploymentStatusCode = "fg";
		//Test Parameters
		subject.GovernmentServiceAffiliationCode = governmentServiceAffiliationCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "a2";
			subject.DateTimePeriod = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a2", "R", true)]
	[InlineData("a2", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new MPI_MilitaryPersonnelInformation();
		//Required fields
		subject.InformationStatusCode = "i";
		subject.EmploymentStatusCode = "fg";
		subject.GovernmentServiceAffiliationCode = "G";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
