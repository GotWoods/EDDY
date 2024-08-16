using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UNBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNB+++++O++R+W+9+e+0";

		var expected = new UNB_InterchangeHeader()
		{
			SyntaxIdentifier = null,
			InterchangeSender = null,
			InterchangeRecipient = null,
			DateTimeOfPreparation = null,
			InterchangeControlReference = "O",
			RecipientsReferencePassword = null,
			ApplicationReference = "R",
			ProcessingPriorityCode = "W",
			AcknowledgementRequest = "9",
			CommunicationsAgreementID = "e",
			TestIndicator = "0",
		};

		var actual = Map.MapObject<UNB_InterchangeHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSyntaxIdentifier(string syntaxIdentifier, bool isValidExpected)
	{
		var subject = new UNB_InterchangeHeader();
		//Required fields
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.InterchangeControlReference = "O";
		//Test Parameters
		if (syntaxIdentifier != "") 
			subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInterchangeSender(string interchangeSender, bool isValidExpected)
	{
		var subject = new UNB_InterchangeHeader();
		//Required fields
		subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.InterchangeControlReference = "O";
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
		var subject = new UNB_InterchangeHeader();
		//Required fields
		subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.InterchangeControlReference = "O";
		//Test Parameters
		if (interchangeRecipient != "") 
			subject.InterchangeRecipient = new S003_InterchangeRecipient();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateTimeOfPreparation(string dateTimeOfPreparation, bool isValidExpected)
	{
		var subject = new UNB_InterchangeHeader();
		//Required fields
		subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.InterchangeControlReference = "O";
		//Test Parameters
		if (dateTimeOfPreparation != "") 
			subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredInterchangeControlReference(string interchangeControlReference, bool isValidExpected)
	{
		var subject = new UNB_InterchangeHeader();
		//Required fields
		subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		//Test Parameters
		subject.InterchangeControlReference = interchangeControlReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
