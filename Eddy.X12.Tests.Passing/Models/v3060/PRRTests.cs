using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PRRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRR*L*SP*t*Hgu*2*V2*X*p*ov*J*m";

		var expected = new PRR_ProblemReport()
		{
			AssignedIdentification = "L",
			AgencyQualifierCode = "SP",
			SourceSubqualifier = "t",
			ComplaintCode = "Hgu",
			Description = "2",
			AgencyQualifierCode2 = "V2",
			SourceSubqualifier2 = "X",
			ServiceClassificationCode = "p",
			AgencyQualifierCode3 = "ov",
			SourceSubqualifier3 = "J",
			SeverityConditionCode = "m",
		};

		var actual = Map.MapObject<PRR_ProblemReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SP", "Hgu", true)]
	[InlineData("SP", "", false)]
	[InlineData("", "Hgu", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string complaintCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ComplaintCode = complaintCode;
		//At Least one
		subject.Description = "2";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "SP", true)]
	[InlineData("t", "", false)]
	[InlineData("", "SP", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.ComplaintCode = "Hgu";
		//At Least one
		subject.ComplaintCode = "Hgu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Hgu", "2", true)]
	[InlineData("Hgu", "", true)]
	[InlineData("", "2", true)]
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
	[InlineData("V2", "p", true)]
	[InlineData("V2", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string serviceClassificationCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.ServiceClassificationCode = serviceClassificationCode;
		//At Least one
		subject.ComplaintCode = "Hgu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "V2", true)]
	[InlineData("X", "", false)]
	[InlineData("", "V2", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.ServiceClassificationCode = "p";
		//At Least one
		subject.ComplaintCode = "Hgu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ov", "m", true)]
	[InlineData("ov", "", false)]
	[InlineData("", "m", true)]
	public void Validation_ARequiresBAgencyQualifierCode3(string agencyQualifierCode3, string severityConditionCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		subject.SeverityConditionCode = severityConditionCode;
		//At Least one
		subject.ComplaintCode = "Hgu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "ov", true)]
	[InlineData("J", "", false)]
	[InlineData("", "ov", true)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		//A Requires B
		if (agencyQualifierCode3 != "")
			subject.SeverityConditionCode = "m";
		//At Least one
		subject.ComplaintCode = "Hgu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
