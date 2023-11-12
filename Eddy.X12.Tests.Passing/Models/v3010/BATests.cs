using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA*L9b*iZa7Ku*zriG4o*oqUz*j*AgDCAu*F4Au6u*ssEJ*Y";

		var expected = new BA_BeginningSegmentForAdvanceConsist()
		{
			TransactionSetIdentifierCode = "L9b",
			StandardPointLocationCode = "iZa7Ku",
			EstimatedInterchangeDate = "zriG4o",
			EstimatedInterchangeTime = "oqUz",
			InterchangeTrainIdentification = "j",
			StandardPointLocationCode2 = "AgDCAu",
			EventDate = "F4Au6u",
			EventTime = "ssEJ",
			TypeOfConsistCode = "Y",
		};

		var actual = Map.MapObject<BA_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iZa7Ku", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.InterchangeTrainIdentification = "j";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "iZa7Ku";
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
