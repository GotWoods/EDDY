using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCI+A+++m+c+1hx+";

		var expected = new UCI_InterchangeResponse()
		{
			InterchangeControlReference = "A",
			InterchangeSender = null,
			InterchangeRecipient = null,
			ActionCoded = "m",
			SyntaxErrorCoded = "c",
			ServiceSegmentTagCoded = "1hx",
			DataElementIdentification = null,
		};

		var actual = Map.MapObject<UCI_InterchangeResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInterchangeControlReference(string interchangeControlReference, bool isValidExpected)
	{
		var subject = new UCI_InterchangeResponse();
		//Required fields
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.ActionCoded = "m";
		//Test Parameters
		subject.InterchangeControlReference = interchangeControlReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInterchangeSender(string interchangeSender, bool isValidExpected)
	{
		var subject = new UCI_InterchangeResponse();
		//Required fields
		subject.InterchangeControlReference = "A";
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.ActionCoded = "m";
		//Test Parameters
		if (interchangeSender != "") 
			subject.InterchangeSender = new S002_InterchangeSender();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInterchangeRecipient(string interchangeRecipient, bool isValidExpected)
	{
		var subject = new UCI_InterchangeResponse();
		//Required fields
		subject.InterchangeControlReference = "A";
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.ActionCoded = "m";
		//Test Parameters
		if (interchangeRecipient != "") 
			subject.InterchangeRecipient = new S003_InterchangeRecipient();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredActionCoded(string actionCoded, bool isValidExpected)
	{
		var subject = new UCI_InterchangeResponse();
		//Required fields
		subject.InterchangeControlReference = "A";
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		//Test Parameters
		subject.ActionCoded = actionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
