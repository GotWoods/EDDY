using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*yn*E145Cz7nni*g6*VXR68aCIuH*64*qce7pMYPCzoqadM*b2*WFh6qYul1EK0Iqb*W8Lw8d*MM7D*3*VYIAI*315977838*1*Y*W";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "yn",
			AuthorizationInformation = "E145Cz7nni",
			SecurityInformationQualifier = "g6",
			SecurityInformation = "VXR68aCIuH",
			InterchangeIDQualifier = "64",
			InterchangeSenderID = "qce7pMYPCzoqadM",
			InterchangeIDQualifier2 = "b2",
			InterchangeReceiverID = "WFh6qYul1EK0Iqb",
			InterchangeDate = "W8Lw8d",
			InterchangeTime = "MM7D",
			InterchangeControlStandardsIdentifier = "3",
			InterchangeControlVersionNumber = "VYIAI",
			InterchangeControlNumber = 315977838,
			AcknowledgmentRequested = "1",
			TestIndicator = "Y",
			SubelementSeparator = "W",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yn", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E145Cz7nni", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g6", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VXR68aCIuH", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("64", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qce7pMYPCzoqadM", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b2", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WFh6qYul1EK0Iqb", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W8Lw8d", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MM7D", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredInterchangeControlStandardsIdentifier(string interchangeControlStandardsIdentifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeControlStandardsIdentifier = interchangeControlStandardsIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VYIAI", true)]
	public void Validation_RequiredInterchangeControlVersionNumber(string interchangeControlVersionNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.InterchangeControlVersionNumber = interchangeControlVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(315977838, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredAcknowledgmentRequested(string acknowledgmentRequested, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.TestIndicator = "Y";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.AcknowledgmentRequested = acknowledgmentRequested;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredTestIndicator(string testIndicator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.SubelementSeparator = "W";
		//Test Parameters
		subject.TestIndicator = testIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredSubelementSeparator(string subelementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "yn";
		subject.AuthorizationInformation = "E145Cz7nni";
		subject.SecurityInformationQualifier = "g6";
		subject.SecurityInformation = "VXR68aCIuH";
		subject.InterchangeIDQualifier = "64";
		subject.InterchangeSenderID = "qce7pMYPCzoqadM";
		subject.InterchangeIDQualifier2 = "b2";
		subject.InterchangeReceiverID = "WFh6qYul1EK0Iqb";
		subject.InterchangeDate = "W8Lw8d";
		subject.InterchangeTime = "MM7D";
		subject.InterchangeControlStandardsIdentifier = "3";
		subject.InterchangeControlVersionNumber = "VYIAI";
		subject.InterchangeControlNumber = 315977838;
		subject.AcknowledgmentRequested = "1";
		subject.TestIndicator = "Y";
		//Test Parameters
		subject.SubelementSeparator = subelementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
