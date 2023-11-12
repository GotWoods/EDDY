using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*mh*gSItEln7as*ik*HFZxNC8tTO*ql*qHC8FFThpTBC4iR*N9*JL8KKq4eZ7dApRa*4Z1Dl2*lRWr*o*i8Ym1*595846786*n*T*v";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "mh",
			AuthorizationInformation = "gSItEln7as",
			SecurityInformationQualifier = "ik",
			SecurityInformation = "HFZxNC8tTO",
			InterchangeIDQualifier = "ql",
			InterchangeSenderID = "qHC8FFThpTBC4iR",
			InterchangeIDQualifier2 = "N9",
			InterchangeReceiverID = "JL8KKq4eZ7dApRa",
			InterchangeDate = "4Z1Dl2",
			InterchangeTime = "lRWr",
			InterchangeControlStandardsIdentifier = "o",
			InterchangeControlVersionNumber = "i8Ym1",
			InterchangeControlNumber = 595846786,
			AcknowledgmentRequested = "n",
			TestIndicator = "T",
			ComponentElementSeparator = "v",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mh", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gSItEln7as", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ik", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HFZxNC8tTO", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ql", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qHC8FFThpTBC4iR", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N9", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JL8KKq4eZ7dApRa", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Z1Dl2", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lRWr", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredInterchangeControlStandardsIdentifier(string interchangeControlStandardsIdentifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeControlStandardsIdentifier = interchangeControlStandardsIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i8Ym1", true)]
	public void Validation_RequiredInterchangeControlVersionNumber(string interchangeControlVersionNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.InterchangeControlVersionNumber = interchangeControlVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(595846786, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAcknowledgmentRequested(string acknowledgmentRequested, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.TestIndicator = "T";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.AcknowledgmentRequested = acknowledgmentRequested;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTestIndicator(string testIndicator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.ComponentElementSeparator = "v";
		//Test Parameters
		subject.TestIndicator = testIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "mh";
		subject.AuthorizationInformation = "gSItEln7as";
		subject.SecurityInformationQualifier = "ik";
		subject.SecurityInformation = "HFZxNC8tTO";
		subject.InterchangeIDQualifier = "ql";
		subject.InterchangeSenderID = "qHC8FFThpTBC4iR";
		subject.InterchangeIDQualifier2 = "N9";
		subject.InterchangeReceiverID = "JL8KKq4eZ7dApRa";
		subject.InterchangeDate = "4Z1Dl2";
		subject.InterchangeTime = "lRWr";
		subject.InterchangeControlStandardsIdentifier = "o";
		subject.InterchangeControlVersionNumber = "i8Ym1";
		subject.InterchangeControlNumber = 595846786;
		subject.AcknowledgmentRequested = "n";
		subject.TestIndicator = "T";
		//Test Parameters
		subject.ComponentElementSeparator = componentElementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
