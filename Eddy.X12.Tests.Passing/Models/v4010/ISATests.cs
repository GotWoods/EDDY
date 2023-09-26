using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*PD*7GxCbvr0UZ*gH*zVWRCyJFFB*6y*P1vWxyD3ffZfa66*vY*csVcknIkcaOADFp*CAoOkG*O0fv*1*ejVQd*666123179*j*m*E";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "PD",
			AuthorizationInformation = "7GxCbvr0UZ",
			SecurityInformationQualifier = "gH",
			SecurityInformation = "zVWRCyJFFB",
			InterchangeIDQualifier = "6y",
			InterchangeSenderID = "P1vWxyD3ffZfa66",
			InterchangeIDQualifier2 = "vY",
			InterchangeReceiverID = "csVcknIkcaOADFp",
			InterchangeDate = "CAoOkG",
			InterchangeTime = "O0fv",
			InterchangeControlStandardsIdentifier = "1",
			InterchangeControlVersionNumber = "ejVQd",
			InterchangeControlNumber = 666123179,
			AcknowledgmentRequested = "j",
			UsageIndicator = "m",
			ComponentElementSeparator = "E",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PD", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7GxCbvr0UZ", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gH", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zVWRCyJFFB", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6y", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P1vWxyD3ffZfa66", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vY", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("csVcknIkcaOADFp", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CAoOkG", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O0fv", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredInterchangeControlStandardsIdentifier(string interchangeControlStandardsIdentifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeControlStandardsIdentifier = interchangeControlStandardsIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ejVQd", true)]
	public void Validation_RequiredInterchangeControlVersionNumber(string interchangeControlVersionNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.InterchangeControlVersionNumber = interchangeControlVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(666123179, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredAcknowledgmentRequested(string acknowledgmentRequested, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.UsageIndicator = "m";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.AcknowledgmentRequested = acknowledgmentRequested;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredUsageIndicator(string usageIndicator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.ComponentElementSeparator = "E";
		//Test Parameters
		subject.UsageIndicator = usageIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "PD";
		subject.AuthorizationInformation = "7GxCbvr0UZ";
		subject.SecurityInformationQualifier = "gH";
		subject.SecurityInformation = "zVWRCyJFFB";
		subject.InterchangeIDQualifier = "6y";
		subject.InterchangeSenderID = "P1vWxyD3ffZfa66";
		subject.InterchangeIDQualifier2 = "vY";
		subject.InterchangeReceiverID = "csVcknIkcaOADFp";
		subject.InterchangeDate = "CAoOkG";
		subject.InterchangeTime = "O0fv";
		subject.InterchangeControlStandardsIdentifier = "1";
		subject.InterchangeControlVersionNumber = "ejVQd";
		subject.InterchangeControlNumber = 666123179;
		subject.AcknowledgmentRequested = "j";
		subject.UsageIndicator = "m";
		//Test Parameters
		subject.ComponentElementSeparator = componentElementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
