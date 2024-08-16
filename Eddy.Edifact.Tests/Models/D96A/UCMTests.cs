using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UCMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCM+V++i+M+qd6+";

		var expected = new UCM_MessageResponse()
		{
			MessageReferenceNumber = "V",
			MessageIdentifier = null,
			ActionCoded = "i",
			SyntaxErrorCoded = "M",
			ServiceSegmentTagCoded = "qd6",
			DataElementIdentification = null,
		};

		var actual = Map.MapObject<UCM_MessageResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredMessageReferenceNumber(string messageReferenceNumber, bool isValidExpected)
	{
		var subject = new UCM_MessageResponse();
		//Required fields
		subject.MessageIdentifier = new S009_MessageIdentifier();
		subject.ActionCoded = "i";
		//Test Parameters
		subject.MessageReferenceNumber = messageReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMessageIdentifier(string messageIdentifier, bool isValidExpected)
	{
		var subject = new UCM_MessageResponse();
		//Required fields
		subject.MessageReferenceNumber = "V";
		subject.ActionCoded = "i";
		//Test Parameters
		if (messageIdentifier != "") 
			subject.MessageIdentifier = new S009_MessageIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredActionCoded(string actionCoded, bool isValidExpected)
	{
		var subject = new UCM_MessageResponse();
		//Required fields
		subject.MessageReferenceNumber = "V";
		subject.MessageIdentifier = new S009_MessageIdentifier();
		//Test Parameters
		subject.ActionCoded = actionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
