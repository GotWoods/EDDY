using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PRRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRR*W*tp*J*14u*d*KC*5*l*t";

		var expected = new PRR_ProblemReport()
		{
			AssignedIdentification = "W",
			AgencyQualifierCode = "tp",
			SourceSubqualifier = "J",
			ComplaintCode = "14u",
			Description = "d",
			AgencyQualifierCode2 = "KC",
			SourceSubqualifier2 = "5",
			ServiceClassificationCode = "l",
			SeverityConditionCode = "t",
		};

		var actual = Map.MapObject<PRR_ProblemReport>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tp", "14u", true)]
	[InlineData("tp", "", false)]
	[InlineData("", "14u", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string complaintCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ComplaintCode = complaintCode;
		//At Least one
		subject.Description = "d";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "tp", true)]
	[InlineData("J", "", false)]
	[InlineData("", "tp", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.ComplaintCode = "14u";
		//At Least one
		subject.ComplaintCode = "14u";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("14u", "d", true)]
	[InlineData("14u", "", true)]
	[InlineData("", "d", true)]
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
	[InlineData("5", "KC", true)]
	[InlineData("5", "", false)]
	[InlineData("", "KC", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new PRR_ProblemReport();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//At Least one
		subject.ComplaintCode = "14u";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
