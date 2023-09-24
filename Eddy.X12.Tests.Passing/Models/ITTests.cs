using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT*8*3*2";

		var expected = new IT_InterconnectMailbagTrailer()
		{
			InterconnectMailbagControlNumber = 8,
			InterconnectMailbagAcknowledgmentCount = 3,
			InterconnectMailbagInterchangeCount = 2,
		};

		var actual = Map.MapObject<IT_InterconnectMailbagTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredInterconnectMailbagControlNumber(int interconnectMailbagControlNumber, bool isValidExpected)
	{
		var subject = new IT_InterconnectMailbagTrailer();
		subject.InterconnectMailbagAcknowledgmentCount = 3;
		subject.InterconnectMailbagInterchangeCount = 2;
		if (interconnectMailbagControlNumber > 0)
		subject.InterconnectMailbagControlNumber = interconnectMailbagControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredInterconnectMailbagAcknowledgmentCount(int interconnectMailbagAcknowledgmentCount, bool isValidExpected)
	{
		var subject = new IT_InterconnectMailbagTrailer();
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagInterchangeCount = 2;
		if (interconnectMailbagAcknowledgmentCount > 0)
		subject.InterconnectMailbagAcknowledgmentCount = interconnectMailbagAcknowledgmentCount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredInterconnectMailbagInterchangeCount(int interconnectMailbagInterchangeCount, bool isValidExpected)
	{
		var subject = new IT_InterconnectMailbagTrailer();
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagAcknowledgmentCount = 3;
		if (interconnectMailbagInterchangeCount > 0)
		subject.InterconnectMailbagInterchangeCount = interconnectMailbagInterchangeCount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
