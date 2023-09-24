using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRR*R*hv*M*ply*W*aX*y*j*Vb*l*O";

		var expected = new PRR_ProblemReport()
		{
			AssignedIdentification = "R",
			AgencyQualifierCode = "hv",
			SourceSubqualifier = "M",
			ComplaintCode = "ply",
			Description = "W",
			AgencyQualifierCode2 = "aX",
			SourceSubqualifier2 = "y",
			ServiceClassificationCode = "j",
			AgencyQualifierCode3 = "Vb",
			SourceSubqualifier3 = "l",
			SeverityConditionCode = "O",
		};

		var actual = Map.MapObject<PRR_ProblemReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "ply", true)]
	[InlineData("hv", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string complaintCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ComplaintCode = complaintCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "hv", true)]
	[InlineData("M", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("ply","W", true)]
	[InlineData("", "W", true)]
	[InlineData("ply", "", true)]
	public void Validation_AtLeastOneComplaintCode(string complaintCode, string description, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		subject.ComplaintCode = complaintCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "j", true)]
	[InlineData("aX", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string serviceClassificationCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.ServiceClassificationCode = serviceClassificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "aX", true)]
	[InlineData("y", "", false)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "O", true)]
	[InlineData("Vb", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode3(string agencyQualifierCode3, string severityConditionCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		subject.SeverityConditionCode = severityConditionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Vb", true)]
	[InlineData("l", "", false)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
