using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA*Bzn*LARji3*TVvGZD*mZ61*c*zeyvWQ*5DCO3m*ESwX*0";

		var expected = new BA_BeginningSegmentForAdvanceConsist()
		{
			TransactionSetIdentifierCode = "Bzn",
			StandardPointLocationCode = "LARji3",
			Date = "TVvGZD",
			Time = "mZ61",
			InterchangeTrainIdentification = "c",
			StandardPointLocationCode2 = "zeyvWQ",
			Date2 = "5DCO3m",
			Time2 = "ESwX",
			TypeOfConsistCode = "0",
		};

		var actual = Map.MapObject<BA_BeginningSegmentForAdvanceConsist>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LARji3", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.InterchangeTrainIdentification = "c";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BA_BeginningSegmentForAdvanceConsist();
		subject.StandardPointLocationCode = "LARji3";
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
