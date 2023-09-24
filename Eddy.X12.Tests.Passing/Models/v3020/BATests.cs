using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA*MmZ*EChaCT*VVn83r*El4E*7*LjpIHC*tudPPr*nrLQ*h";

		var expected = new BA_BeginningSegmentForAdvanceConsist()
		{
			TransactionSetIdentifierCode = "MmZ",
			StandardPointLocationCode = "EChaCT",
			Date = "VVn83r",
			Time = "El4E",
			InterchangeTrainIdentification = "7",
			StandardPointLocationCode2 = "LjpIHC",
			Date2 = "tudPPr",
			Time2 = "nrLQ",
			TypeOfConsistCode = "h",
		};

		var actual = Map.MapObject<BA_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EChaCT", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.InterchangeTrainIdentification = "7";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "EChaCT";
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
