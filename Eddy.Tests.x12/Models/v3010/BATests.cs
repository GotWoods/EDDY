using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA*SK4*K6IkZo*8KdZGj*unAq*Z*XW5Pan*2b3WGE*vXrc*w";

		var expected = new BA_BeginningSegmentForAdvanceConsist()
		{
			TransactionSetIdentifierCode = "SK4",
			StandardPointLocationCode = "K6IkZo",
			EstimatedInterchangeDate = "8KdZGj",
			EstimatedInterchangeTime = "unAq",
			InterchangeTrainIdentification = "Z",
			StandardPointLocationCode2 = "XW5Pan",
			EventDate = "2b3WGE",
			EventTime = "vXrc",
			TypeOfConsistCode = "w",
		};

		var actual = Map.MapObject<BA_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K6IkZo", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.InterchangeTrainIdentification = "Z";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "K6IkZo";
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
