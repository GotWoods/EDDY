using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCI+p+++C+2+x++a+i";

		var expected = new UCI_InterchangeResponse()
		{
			InterchangeControlReference = "p",
			InterchangeSender = null,
			InterchangeRecipient = null,
			ActionCoded = "C",
			SyntaxErrorCoded = "2",
			ServiceSegmentTagCoded = "x",
			DataElementIdentification = null,
			SecurityReferenceNumber = "a",
			SecuritySegmentPosition = "i",
		};

		var actual = Map.MapObject<UCI_InterchangeResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredInterchangeControlReference(string interchangeControlReference, bool isValidExpected)
	{
		var subject = new UCI_InterchangeResponse();
		//Required fields
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.ActionCoded = "C";
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
		subject.InterchangeControlReference = "p";
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.ActionCoded = "C";
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
		subject.InterchangeControlReference = "p";
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.ActionCoded = "C";
		//Test Parameters
		if (interchangeRecipient != "") 
			subject.InterchangeRecipient = new S003_InterchangeRecipient();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredActionCoded(string actionCoded, bool isValidExpected)
	{
		var subject = new UCI_InterchangeResponse();
		//Required fields
		subject.InterchangeControlReference = "p";
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		//Test Parameters
		subject.ActionCoded = actionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
