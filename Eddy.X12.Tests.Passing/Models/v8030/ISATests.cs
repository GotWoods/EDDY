using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.Tests.Models.v8030;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*vz*4L6D0GM09d*M9*0EMrG7SuG7*rl*vW2ktFcjSzX76Ju*Lt*OTIkHnmlGU5r8YW*2Oe6Jz*vltz*X*fJXO3*738629984*O*g*2";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "vz",
			AuthorizationInformation = "4L6D0GM09d",
			SecurityInformationQualifier = "M9",
			SecurityInformation = "0EMrG7SuG7",
			InterchangeIDQualifier = "rl",
			InterchangeSenderID = "vW2ktFcjSzX76Ju",
			InterchangeIDQualifier2 = "Lt",
			InterchangeReceiverID = "OTIkHnmlGU5r8YW",
			InterchangeDate = "2Oe6Jz",
			InterchangeTime = "vltz",
			RepetitionSeparator = "X",
			InterchangeControlVersionNumberCode = "fJXO3",
			InterchangeControlNumber = 738629984,
			AcknowledgmentRequestedCode = "O",
			InterchangeUsageIndicatorCode = "g",
			ComponentDataElementSeparator = "2",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vz", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4L6D0GM09d", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M9", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0EMrG7SuG7", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rl", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vW2ktFcjSzX76Ju", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lt", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OTIkHnmlGU5r8YW", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2Oe6Jz", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vltz", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredRepetitionSeparator(string repetitionSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.RepetitionSeparator = repetitionSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fJXO3", true)]
	public void Validation_RequiredInterchangeControlVersionNumberCode(string interchangeControlVersionNumberCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeControlVersionNumberCode = interchangeControlVersionNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(738629984, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAcknowledgmentRequestedCode(string acknowledgmentRequestedCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.InterchangeUsageIndicatorCode = "g";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.AcknowledgmentRequestedCode = acknowledgmentRequestedCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredInterchangeUsageIndicatorCode(string interchangeUsageIndicatorCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.ComponentDataElementSeparator = "2";
		//Test Parameters
		subject.InterchangeUsageIndicatorCode = interchangeUsageIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredComponentDataElementSeparator(string componentDataElementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "vz";
		subject.AuthorizationInformation = "4L6D0GM09d";
		subject.SecurityInformationQualifier = "M9";
		subject.SecurityInformation = "0EMrG7SuG7";
		subject.InterchangeIDQualifier = "rl";
		subject.InterchangeSenderID = "vW2ktFcjSzX76Ju";
		subject.InterchangeIDQualifier2 = "Lt";
		subject.InterchangeReceiverID = "OTIkHnmlGU5r8YW";
		subject.InterchangeDate = "2Oe6Jz";
		subject.InterchangeTime = "vltz";
		subject.RepetitionSeparator = "X";
		subject.InterchangeControlVersionNumberCode = "fJXO3";
		subject.InterchangeControlNumber = 738629984;
		subject.AcknowledgmentRequestedCode = "O";
		subject.InterchangeUsageIndicatorCode = "g";
		//Test Parameters
		subject.ComponentDataElementSeparator = componentDataElementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
