using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USB+f+++";

		var expected = new USB_SecuredDataIdentification()
		{
			ResponseTypeCoded = "f",
			SecurityDateAndTime = null,
			InterchangeSender = null,
			InterchangeRecipient = null,
		};

		var actual = Map.MapObject<USB_SecuredDataIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredResponseTypeCoded(string responseTypeCoded, bool isValidExpected)
	{
		var subject = new USB_SecuredDataIdentification();
		//Required fields
		subject.InterchangeSender = new S002_InterchangeSender();
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
		//Test Parameters
		subject.ResponseTypeCoded = responseTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInterchangeSender(string interchangeSender, bool isValidExpected)
	{
		var subject = new USB_SecuredDataIdentification();
		//Required fields
		subject.ResponseTypeCoded = "f";
		subject.InterchangeRecipient = new S003_InterchangeRecipient();
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
		var subject = new USB_SecuredDataIdentification();
		//Required fields
		subject.ResponseTypeCoded = "f";
		subject.InterchangeSender = new S002_InterchangeSender();
		//Test Parameters
		if (interchangeRecipient != "") 
			subject.InterchangeRecipient = new S003_InterchangeRecipient();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
