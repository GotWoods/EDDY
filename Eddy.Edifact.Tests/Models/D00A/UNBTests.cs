using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UNBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNB+++++c++h+g+0+w+v";

		var expected = new UNB_InterchangeHeader()
		{
			SyntaxIdentifier = null,
			InterchangeSender = null,
			InterchangeRecipient = null,
			DateAndTimeOfPreparation = null,
			InterchangeControlReference = "c",
			RecipientReferencePasswordDetails = null,
			ApplicationReference = "h",
			ProcessingPriorityCode = "g",
			AcknowledgementRequest = "0",
			InterchangeAgreementIdentifier = "w",
			TestIndicator = "v",
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
		subject.DateAndTimeOfPreparation = new S004_DateAndTimeOfPreparation();
		subject.InterchangeControlReference = "c";
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
		subject.DateAndTimeOfPreparation = new S004_DateAndTimeOfPreparation();
		subject.InterchangeControlReference = "c";
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
		subject.DateAndTimeOfPreparation = new S004_DateAndTimeOfPreparation();
		subject.InterchangeControlReference = "c";
		//Test Parameters
		if (interchangeRecipient != "") 
			subject.InterchangeRecipient = new S003_InterchangeRecipient();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateAndTimeOfPreparation(string dateAndTimeOfPreparation, bool isValidExpected)
	{
		var subject = new UNB_InterchangeHeader();
		//Required fields
		subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.InterchangeControlReference = "c";
		//Test Parameters
		if (dateAndTimeOfPreparation != "") 
			subject.DateAndTimeOfPreparation = new S004_DateAndTimeOfPreparation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredInterchangeControlReference(string interchangeControlReference, bool isValidExpected)
	{
		var subject = new UNB_InterchangeHeader();
		//Required fields
		subject.SyntaxIdentifier = new S001_SyntaxIdentifier();
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		subject.DateAndTimeOfPreparation = new S004_DateAndTimeOfPreparation();
		//Test Parameters
		subject.InterchangeControlReference = interchangeControlReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
