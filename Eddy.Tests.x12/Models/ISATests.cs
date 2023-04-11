//TODO: this test is very broken
// using Eddy.Core.Validation;
// using Eddy.x12.Mapping;
// using Eddy.x12.Models;
//
// namespace Eddy.Tests.x12.Models;
//
// public class ISATests
// {
// 	[Fact]
// 	public void Parse_ShouldReturnCorrectObject()
// 	{
// 		string x12Line = "ISA*Eh*8v43WscGFL*ME*aoGHErYyRl*YZ*vCZNLpX7qHcpFDm*2g*XIB3hZ2l7dsNdLp*MgxeJZ*oxhz*4*8RDGT*391922432*d*s*J";
//
// 		var expected = new ISA_InterchangeControlHeader()
// 		{
// 			AuthorizationInformationQualifier = "Eh",
// 			AuthorizationInformation = "8v43WscGFL",
// 			SecurityInformationQualifier = "ME",
// 			SecurityInformation = "aoGHErYyRl",
// 			InterchangeIDQualifier = "YZ",
// 			InterchangeSenderID = "vCZNLpX7qHcpFDm",
// 			InterchangeIDQualifier2 = "2g",
// 			InterchangeReceiverID = "XIB3hZ2l7dsNdLp",
// 			InterchangeDate = "MgxeJZ",
// 			InterchangeTime = "oxhz",
// 			RepetitionSeparator = "4",
// 			InterchangeControlVersionNumberCode = "8RDGT",
// 			InterchangeControlNumber = 391922432,
// 			AcknowledgmentRequestedCode = "d",
// 			InterchangeUsageIndicatorCode = "s",
// 			ComponentElementSeparator = "J",
// 		};
//
// 		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
// 		Assert.Equivalent(expected, actual);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("Eh", true)]
// 	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("8v43WscGFL", true)]
// 	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.AuthorizationInformation = authorizationInformation;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("ME", true)]
// 	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.SecurityInformationQualifier = securityInformationQualifier;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("aoGHErYyRl", true)]
// 	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.SecurityInformation = securityInformation;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("YZ", true)]
// 	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeIDQualifier = interchangeIDQualifier;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("vCZNLpX7qHcpFDm", true)]
// 	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeSenderID = interchangeSenderID;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("2g", true)]
// 	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("XIB3hZ2l7dsNdLp", true)]
// 	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeReceiverID = interchangeReceiverID;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("MgxeJZ", true)]
// 	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeDate = interchangeDate;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("oxhz", true)]
// 	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeTime = interchangeTime;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("4", true)]
// 	public void Validation_RequiredRepetitionSeparator(string repetitionSeparator, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.RepetitionSeparator = repetitionSeparator;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("8RDGT", true)]
// 	public void Validation_RequiredInterchangeControlVersionNumberCode(string interchangeControlVersionNumberCode, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeControlVersionNumberCode = interchangeControlVersionNumberCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData(0, false)]
// 	[InlineData(391922432, true)]
// 	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		if (interchangeControlNumber > 0)
// 		subject.InterchangeControlNumber = interchangeControlNumber;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("d", true)]
// 	public void Validation_RequiredAcknowledgmentRequestedCode(string acknowledgmentRequestedCode, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = "J";
// 		subject.AcknowledgmentRequestedCode = acknowledgmentRequestedCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("s", true)]
// 	public void Validation_RequiredInterchangeUsageIndicatorCode(string interchangeUsageIndicatorCode, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.ComponentElementSeparator = "J";
// 		subject.InterchangeUsageIndicatorCode = interchangeUsageIndicatorCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("J", true)]
// 	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "Eh";
// 		subject.AuthorizationInformation = "8v43WscGFL";
// 		subject.SecurityInformationQualifier = "ME";
// 		subject.SecurityInformation = "aoGHErYyRl";
// 		subject.InterchangeIDQualifier = "YZ";
// 		subject.InterchangeSenderID = "vCZNLpX7qHcpFDm";
// 		subject.InterchangeIDQualifier2 = "2g";
// 		subject.InterchangeReceiverID = "XIB3hZ2l7dsNdLp";
// 		subject.InterchangeDate = "MgxeJZ";
// 		subject.InterchangeTime = "oxhz";
// 		subject.RepetitionSeparator = "4";
// 		subject.InterchangeControlVersionNumberCode = "8RDGT";
// 		subject.InterchangeControlNumber = 391922432;
// 		subject.AcknowledgmentRequestedCode = "d";
// 		subject.InterchangeUsageIndicatorCode = "s";
// 		subject.ComponentElementSeparator = componentElementSeparator;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// }
