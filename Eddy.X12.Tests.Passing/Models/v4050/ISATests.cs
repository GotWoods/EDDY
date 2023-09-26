using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*Kb*ubb5mjEgTE*e8*hjLxQsPM9x*Gp*2Sr86oEjw2ztwkX*Pm*GTJxbyhVzwFN7GZ*l1lVSx*nzzd*D*FU12b*998375198*t*S*n";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "Kb",
			AuthorizationInformation = "ubb5mjEgTE",
			SecurityInformationQualifier = "e8",
			SecurityInformation = "hjLxQsPM9x",
			InterchangeIDQualifier = "Gp",
			InterchangeSenderID = "2Sr86oEjw2ztwkX",
			InterchangeIDQualifier2 = "Pm",
			InterchangeReceiverID = "GTJxbyhVzwFN7GZ",
			InterchangeDate = "l1lVSx",
			InterchangeTime = "nzzd",
			RepetitionSeparator = "D",
			InterchangeControlVersionNumber = "FU12b",
			InterchangeControlNumber = 998375198,
			AcknowledgmentRequested = "t",
			InterchangeUsageIndicator = "S",
			ComponentElementSeparator = "n",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kb", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ubb5mjEgTE", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e8", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hjLxQsPM9x", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gp", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2Sr86oEjw2ztwkX", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pm", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GTJxbyhVzwFN7GZ", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l1lVSx", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nzzd", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredRepetitionSeparator(string repetitionSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.RepetitionSeparator = repetitionSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FU12b", true)]
	public void Validation_RequiredInterchangeControlVersionNumber(string interchangeControlVersionNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeControlVersionNumber = interchangeControlVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(998375198, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredAcknowledgmentRequested(string acknowledgmentRequested, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.InterchangeUsageIndicator = "S";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.AcknowledgmentRequested = acknowledgmentRequested;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredInterchangeUsageIndicator(string interchangeUsageIndicator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.ComponentElementSeparator = "n";
		//Test Parameters
		subject.InterchangeUsageIndicator = interchangeUsageIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "Kb";
		subject.AuthorizationInformation = "ubb5mjEgTE";
		subject.SecurityInformationQualifier = "e8";
		subject.SecurityInformation = "hjLxQsPM9x";
		subject.InterchangeIDQualifier = "Gp";
		subject.InterchangeSenderID = "2Sr86oEjw2ztwkX";
		subject.InterchangeIDQualifier2 = "Pm";
		subject.InterchangeReceiverID = "GTJxbyhVzwFN7GZ";
		subject.InterchangeDate = "l1lVSx";
		subject.InterchangeTime = "nzzd";
		subject.RepetitionSeparator = "D";
		subject.InterchangeControlVersionNumber = "FU12b";
		subject.InterchangeControlNumber = 998375198;
		subject.AcknowledgmentRequested = "t";
		subject.InterchangeUsageIndicator = "S";
		//Test Parameters
		subject.ComponentElementSeparator = componentElementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
