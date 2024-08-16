using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UNHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNH+l++k++++";

		var expected = new UNH_MessageHeader()
		{
			MessageReferenceNumber = "l",
			MessageIdentifier = null,
			CommonAccessReference = "k",
			StatusOfTheTransfer = null,
			MessageSubsetIdentification = null,
			MessageImplementationGuidelineIdentification = null,
			ScenarioIdentification = null,
		};

		var actual = Map.MapObject<UNH_MessageHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredMessageReferenceNumber(string messageReferenceNumber, bool isValidExpected)
	{
		var subject = new UNH_MessageHeader();
		//Required fields
		subject.MessageIdentifier = new S009_MessageIdentifier();
		//Test Parameters
		subject.MessageReferenceNumber = messageReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMessageIdentifier(string messageIdentifier, bool isValidExpected)
	{
		var subject = new UNH_MessageHeader();
		//Required fields
		subject.MessageReferenceNumber = "l";
		//Test Parameters
		if (messageIdentifier != "") 
			subject.MessageIdentifier = new S009_MessageIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
