using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UNTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNT+q+q";

		var expected = new UNT_MessageTrailer()
		{
			NumberOfSegmentsInTheMessage = "q",
			MessageReferenceNumber = "q",
		};

		var actual = Map.MapObject<UNT_MessageTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredNumberOfSegmentsInTheMessage(string numberOfSegmentsInTheMessage, bool isValidExpected)
	{
		var subject = new UNT_MessageTrailer();
		//Required fields
		subject.MessageReferenceNumber = "q";
		//Test Parameters
		subject.NumberOfSegmentsInTheMessage = numberOfSegmentsInTheMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredMessageReferenceNumber(string messageReferenceNumber, bool isValidExpected)
	{
		var subject = new UNT_MessageTrailer();
		//Required fields
		subject.NumberOfSegmentsInTheMessage = "q";
		//Test Parameters
		subject.MessageReferenceNumber = messageReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
