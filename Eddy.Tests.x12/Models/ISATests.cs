//TODO: ISA Test
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
// 		string x12Line = "ISA*qd*J4jx3oksba*8M*dPRh7QvjnU*qa*VGBELASo4iTXIXD*co*1cvjcsVoCyYS7wc*8cmqOU*aaQF*l*KvNT1*182646812*E*o*k";
//
// 		var expected = new ISA_InterchangeControlHeader()
// 		{
// 			AuthorizationInformationQualifier = "qd",
// 			AuthorizationInformation = "J4jx3oksba",
// 			SecurityInformationQualifier = "8M",
// 			SecurityInformation = "dPRh7QvjnU",
// 			InterchangeIDQualifier = "qa",
// 			InterchangeSenderID = "VGBELASo4iTXIXD",
// 			InterchangeIDQualifier2 = "co",
// 			InterchangeReceiverID = "1cvjcsVoCyYS7wc",
// 			InterchangeDate = "8cmqOU",
// 			InterchangeTime = "aaQF",
// 			RepetitionSeparator = "l",
// 			InterchangeControlVersionNumberCode = "KvNT1",
// 			InterchangeControlNumber = 182646812,
// 			AcknowledgmentRequestedCode = "E",
// 			InterchangeUsageIndicatorCode = "o",
// 			ComponentElementSeparator = "k",
// 		};
//
// 		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
// 		Assert.Equivalent(expected, actual);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("qd", true)]
// 	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("J4jx3oksba", true)]
// 	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.AuthorizationInformation = authorizationInformation;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("8M", true)]
// 	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.SecurityInformationQualifier = securityInformationQualifier;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("dPRh7QvjnU", true)]
// 	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.SecurityInformation = securityInformation;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("qa", true)]
// 	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeIDQualifier = interchangeIDQualifier;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("VGBELASo4iTXIXD", true)]
// 	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeSenderID = interchangeSenderID;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("co", true)]
// 	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("1cvjcsVoCyYS7wc", true)]
// 	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeReceiverID = interchangeReceiverID;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("8cmqOU", true)]
// 	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeDate = interchangeDate;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("aaQF", true)]
// 	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeTime = interchangeTime;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("l", true)]
// 	public void Validation_RequiredRepetitionSeparator(string repetitionSeparator, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.RepetitionSeparator = repetitionSeparator;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("KvNT1", true)]
// 	public void Validation_RequiredInterchangeControlVersionNumberCode(string interchangeControlVersionNumberCode, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeControlVersionNumberCode = interchangeControlVersionNumberCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData(0, false)]
// 	[InlineData(182646812, true)]
// 	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		if (interchangeControlNumber > 0)
// 		subject.InterchangeControlNumber = interchangeControlNumber;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("E", true)]
// 	public void Validation_RequiredAcknowledgmentRequestedCode(string acknowledgmentRequestedCode, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = "k";
// 		subject.AcknowledgmentRequestedCode = acknowledgmentRequestedCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("o", true)]
// 	public void Validation_RequiredInterchangeUsageIndicatorCode(string interchangeUsageIndicatorCode, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.ComponentElementSeparator = "k";
// 		subject.InterchangeUsageIndicatorCode = interchangeUsageIndicatorCode;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// 	[Theory]
// 	[InlineData("", false)]
// 	[InlineData("k", true)]
// 	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
// 	{
// 		var subject = new ISA_InterchangeControlHeader();
// 		subject.AuthorizationInformationQualifier = "qd";
// 		subject.AuthorizationInformation = "J4jx3oksba";
// 		subject.SecurityInformationQualifier = "8M";
// 		subject.SecurityInformation = "dPRh7QvjnU";
// 		subject.InterchangeIDQualifier = "qa";
// 		subject.InterchangeSenderID = "VGBELASo4iTXIXD";
// 		subject.InterchangeIDQualifier2 = "co";
// 		subject.InterchangeReceiverID = "1cvjcsVoCyYS7wc";
// 		subject.InterchangeDate = "8cmqOU";
// 		subject.InterchangeTime = "aaQF";
// 		subject.RepetitionSeparator = "l";
// 		subject.InterchangeControlVersionNumberCode = "KvNT1";
// 		subject.InterchangeControlNumber = 182646812;
// 		subject.AcknowledgmentRequestedCode = "E";
// 		subject.InterchangeUsageIndicatorCode = "o";
// 		subject.ComponentElementSeparator = componentElementSeparator;
// 		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
// 	}
//
// }
