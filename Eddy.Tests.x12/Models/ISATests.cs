using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*GD*PNeAAx6gtO*cs*dQyJKszkDI*v9*ox6ghj4Si2irh66*cm*D46OQZlZ8ZigwXQ*XPrZnr*saGg*G*cGYOX*269679616*P*q*f";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "GD",
			AuthorizationInformation = "PNeAAx6gtO",
			SecurityInformationQualifier = "cs",
			SecurityInformation = "dQyJKszkDI",
			InterchangeIDQualifier = "v9",
			InterchangeSenderID = "ox6ghj4Si2irh66",
			InterchangeIDQualifier2 = "cm",
			InterchangeReceiverID = "D46OQZlZ8ZigwXQ",
			InterchangeDate = "XPrZnr",
			InterchangeTime = "saGg",
			RepetitionSeparator = "G",
			InterchangeControlVersionNumberCode = "cGYOX",
			InterchangeControlNumber = 269679616,
			AcknowledgmentRequestedCode = "P",
			InterchangeUsageIndicatorCode = "q",
			ComponentElementSeparator = "f",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GD", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PNeAAx6gtO", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cs", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dQyJKszkDI", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v9", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ox6ghj4Si2irh66", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cm", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D46OQZlZ8ZigwXQ", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XPrZnr", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("saGg", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredRepetitionSeparator(string repetitionSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.RepetitionSeparator = repetitionSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cGYOX", true)]
	public void Validation_RequiredInterchangeControlVersionNumberCode(string interchangeControlVersionNumberCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeControlVersionNumberCode = interchangeControlVersionNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(269679616, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		if (interchangeControlNumber > 0)
		subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAcknowledgmentRequestedCode(string acknowledgmentRequestedCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = "f";
		subject.AcknowledgmentRequestedCode = acknowledgmentRequestedCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredInterchangeUsageIndicatorCode(string interchangeUsageIndicatorCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.ComponentElementSeparator = "f";
		subject.InterchangeUsageIndicatorCode = interchangeUsageIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		subject.AuthorizationInformationQualifier = "GD";
		subject.AuthorizationInformation = "PNeAAx6gtO";
		subject.SecurityInformationQualifier = "cs";
		subject.SecurityInformation = "dQyJKszkDI";
		subject.InterchangeIDQualifier = "v9";
		subject.InterchangeSenderID = "ox6ghj4Si2irh66";
		subject.InterchangeIDQualifier2 = "cm";
		subject.InterchangeReceiverID = "D46OQZlZ8ZigwXQ";
		subject.InterchangeDate = "XPrZnr";
		subject.InterchangeTime = "saGg";
		subject.RepetitionSeparator = "G";
		subject.InterchangeControlVersionNumberCode = "cGYOX";
		subject.InterchangeControlNumber = 269679616;
		subject.AcknowledgmentRequestedCode = "P";
		subject.InterchangeUsageIndicatorCode = "q";
		subject.ComponentElementSeparator = componentElementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
