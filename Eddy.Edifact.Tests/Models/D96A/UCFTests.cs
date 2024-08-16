using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UCFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCF+A+++c+Z+tHT+";

		var expected = new UCF_FunctionalGroupResponse()
		{
			FunctionalGroupReferenceNumber = "A",
			ApplicationSendersIdentification = null,
			ApplicationRecipientsIdentification = null,
			ActionCoded = "c",
			SyntaxErrorCoded = "Z",
			ServiceSegmentTagCoded = "tHT",
			DataElementIdentification = null,
		};

		var actual = Map.MapObject<UCF_FunctionalGroupResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredFunctionalGroupReferenceNumber(string functionalGroupReferenceNumber, bool isValidExpected)
	{
		var subject = new UCF_FunctionalGroupResponse();
		//Required fields
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.ActionCoded = "c";
		//Test Parameters
		subject.FunctionalGroupReferenceNumber = functionalGroupReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredApplicationSendersIdentification(string applicationSendersIdentification, bool isValidExpected)
	{
		var subject = new UCF_FunctionalGroupResponse();
		//Required fields
		subject.FunctionalGroupReferenceNumber = "A";
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.ActionCoded = "c";
		//Test Parameters
		if (applicationSendersIdentification != "") 
			subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredApplicationRecipientsIdentification(string applicationRecipientsIdentification, bool isValidExpected)
	{
		var subject = new UCF_FunctionalGroupResponse();
		//Required fields
		subject.FunctionalGroupReferenceNumber = "A";
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ActionCoded = "c";
		//Test Parameters
		if (applicationRecipientsIdentification != "") 
			subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredActionCoded(string actionCoded, bool isValidExpected)
	{
		var subject = new UCF_FunctionalGroupResponse();
		//Required fields
		subject.FunctionalGroupReferenceNumber = "A";
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		//Test Parameters
		subject.ActionCoded = actionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
