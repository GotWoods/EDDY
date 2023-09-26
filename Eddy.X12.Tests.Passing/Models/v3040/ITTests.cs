using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT*6*5*2";

		var expected = new IT_InterconnectMailbagTrailer()
		{
			InterconnectMailbagControlNumber = 6,
			InterconnectMailbagAcknowledgmentCount = 5,
			InterconnectMailbagInterchangeCount = 2,
		};

		var actual = Map.MapObject<IT_InterconnectMailbagTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredInterconnectMailbagControlNumber(int interconnectMailbagControlNumber, bool isValidExpected)
	{
		var subject = new IT_InterconnectMailbagTrailer();
		//Required fields
		subject.InterconnectMailbagAcknowledgmentCount = 5;
		subject.InterconnectMailbagInterchangeCount = 2;
		//Test Parameters
		if (interconnectMailbagControlNumber > 0) 
			subject.InterconnectMailbagControlNumber = interconnectMailbagControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredInterconnectMailbagAcknowledgmentCount(int interconnectMailbagAcknowledgmentCount, bool isValidExpected)
	{
		var subject = new IT_InterconnectMailbagTrailer();
		//Required fields
		subject.InterconnectMailbagControlNumber = 6;
		subject.InterconnectMailbagInterchangeCount = 2;
		//Test Parameters
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
		//Required fields
		subject.InterconnectMailbagControlNumber = 6;
		subject.InterconnectMailbagAcknowledgmentCount = 5;
		//Test Parameters
		if (interconnectMailbagInterchangeCount > 0) 
			subject.InterconnectMailbagInterchangeCount = interconnectMailbagInterchangeCount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
