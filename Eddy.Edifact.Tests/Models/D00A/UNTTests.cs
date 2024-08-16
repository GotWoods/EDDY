using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UNTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNT+Y+8";

		var expected = new UNT_MessageTrailer()
		{
			NumberOfSegmentsInAMessage = "Y",
			MessageReferenceNumber = "8",
		};

		var actual = Map.MapObject<UNT_MessageTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredNumberOfSegmentsInAMessage(string numberOfSegmentsInAMessage, bool isValidExpected)
	{
		var subject = new UNT_MessageTrailer();
		//Required fields
		subject.MessageReferenceNumber = "8";
		//Test Parameters
		subject.NumberOfSegmentsInAMessage = numberOfSegmentsInAMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredMessageReferenceNumber(string messageReferenceNumber, bool isValidExpected)
	{
		var subject = new UNT_MessageTrailer();
		//Required fields
		subject.NumberOfSegmentsInAMessage = "Y";
		//Test Parameters
		subject.MessageReferenceNumber = messageReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
