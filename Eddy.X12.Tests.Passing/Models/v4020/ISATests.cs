using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*KW*YML3kmNJVo*kg*kLL8j2jH4F*yJ*jGr7Bgb0DbaVect*G1*xfiQJ5xqj2wfPZ1*kIKIVk*Sra6*W*SQNnc*423625274*q*Y*f";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "KW",
			AuthorizationInformation = "YML3kmNJVo",
			SecurityInformationQualifier = "kg",
			SecurityInformation = "kLL8j2jH4F",
			InterchangeIDQualifier = "yJ",
			InterchangeSenderID = "jGr7Bgb0DbaVect",
			InterchangeIDQualifier2 = "G1",
			InterchangeReceiverID = "xfiQJ5xqj2wfPZ1",
			InterchangeDate = "kIKIVk",
			InterchangeTime = "Sra6",
			RepetitionSeparator = "W",
			InterchangeControlVersionNumber = "SQNnc",
			InterchangeControlNumber = 423625274,
			AcknowledgmentRequested = "q",
			UsageIndicator = "Y",
			ComponentElementSeparator = "f",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KW", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YML3kmNJVo", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kg", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kLL8j2jH4F", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yJ", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jGr7Bgb0DbaVect", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G1", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xfiQJ5xqj2wfPZ1", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kIKIVk", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sra6", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredRepetitionSeparator(string repetitionSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.RepetitionSeparator = repetitionSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SQNnc", true)]
	public void Validation_RequiredInterchangeControlVersionNumber(string interchangeControlVersionNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.InterchangeControlVersionNumber = interchangeControlVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(423625274, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredAcknowledgmentRequested(string acknowledgmentRequested, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.UsageIndicator = "Y";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.AcknowledgmentRequested = acknowledgmentRequested;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredUsageIndicator(string usageIndicator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.ComponentElementSeparator = "f";
		//Test Parameters
		subject.UsageIndicator = usageIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "KW";
		subject.AuthorizationInformation = "YML3kmNJVo";
		subject.SecurityInformationQualifier = "kg";
		subject.SecurityInformation = "kLL8j2jH4F";
		subject.InterchangeIDQualifier = "yJ";
		subject.InterchangeSenderID = "jGr7Bgb0DbaVect";
		subject.InterchangeIDQualifier2 = "G1";
		subject.InterchangeReceiverID = "xfiQJ5xqj2wfPZ1";
		subject.InterchangeDate = "kIKIVk";
		subject.InterchangeTime = "Sra6";
		subject.RepetitionSeparator = "W";
		subject.InterchangeControlVersionNumber = "SQNnc";
		subject.InterchangeControlNumber = 423625274;
		subject.AcknowledgmentRequested = "q";
		subject.UsageIndicator = "Y";
		//Test Parameters
		subject.ComponentElementSeparator = componentElementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
