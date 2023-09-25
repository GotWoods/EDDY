using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PRRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRR*D*mT*R*k97*O*yL*Z*G*kw*B*1";

		var expected = new PRR_ProblemReport()
		{
			AssignedIdentification = "D",
			AgencyQualifierCode = "mT",
			SourceSubqualifier = "R",
			ComplaintCode = "k97",
			Description = "O",
			AgencyQualifierCode2 = "yL",
			SourceSubqualifier2 = "Z",
			ServiceClassificationCode = "G",
			AgencyQualifierCode3 = "kw",
			SourceSubqualifier3 = "B",
			SeverityConditionCode = "1",
		};

		var actual = Map.MapObject<PRR_ProblemReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mT", "k97", true)]
	[InlineData("mT", "", false)]
	[InlineData("", "k97", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string complaintCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ComplaintCode = complaintCode;
		//At Least one
		subject.Description = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "mT", true)]
	[InlineData("R", "", false)]
	[InlineData("", "mT", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.ComplaintCode = "k97";
		//At Least one
		subject.ComplaintCode = "k97";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("k97", "O", true)]
	[InlineData("k97", "", true)]
	[InlineData("", "O", true)]
	public void Validation_AtLeastOneComplaintCode(string complaintCode, string description, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.ComplaintCode = complaintCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yL", "G", true)]
	[InlineData("yL", "", false)]
	[InlineData("", "G", true)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string serviceClassificationCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.ServiceClassificationCode = serviceClassificationCode;
		//At Least one
		subject.ComplaintCode = "k97";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "yL", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "yL", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.ServiceClassificationCode = "G";
		//At Least one
		subject.ComplaintCode = "k97";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kw", "1", true)]
	[InlineData("kw", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBAgencyQualifierCode3(string agencyQualifierCode3, string severityConditionCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		subject.SeverityConditionCode = severityConditionCode;
		//At Least one
		subject.ComplaintCode = "k97";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "kw", true)]
	[InlineData("B", "", false)]
	[InlineData("", "kw", true)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		//A Requires B
		if (agencyQualifierCode3 != "")
			subject.SeverityConditionCode = "1";
		//At Least one
		subject.ComplaintCode = "k97";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
