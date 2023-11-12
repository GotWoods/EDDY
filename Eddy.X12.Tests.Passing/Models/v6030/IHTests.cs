using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class IHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IH*JFuvw*u*G*gl*D*CW*h*AL835W*AUqzZ4*vl*8*D";

		var expected = new IH_InterconnectMailbagHeader()
		{
			InterconnectMailbagVersionNumberCode = "JFuvw",
			InterconnectMailbagLogonID = "u",
			InterconnectMailbagPassword = "G",
			InterconnectMailbagIDQualifierCode = "gl",
			InterconnectMailbagSenderID = "D",
			InterconnectMailbagIDQualifierCode2 = "CW",
			InterconnectMailbagReceiverID = "h",
			InterconnectMailbagDate = "AL835W",
			InterconnectMailbagTime = "AUqzZ4",
			InterconnectMailbagTimeCode = "vl",
			InterconnectMailbagControlNumber = 8,
			InterconnectMailbagTestIndicatorCode = "D",
		};

		var actual = Map.MapObject<IH_InterconnectMailbagHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JFuvw", true)]
	public void Validation_RequiredInterconnectMailbagVersionNumberCode(string interconnectMailbagVersionNumberCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagVersionNumberCode = interconnectMailbagVersionNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gl", true)]
	public void Validation_RequiredInterconnectMailbagIDQualifierCode(string interconnectMailbagIDQualifierCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagIDQualifierCode = interconnectMailbagIDQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredInterconnectMailbagSenderID(string interconnectMailbagSenderID, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagSenderID = interconnectMailbagSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CW", true)]
	public void Validation_RequiredInterconnectMailbagIDQualifierCode2(string interconnectMailbagIDQualifierCode2, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagIDQualifierCode2 = interconnectMailbagIDQualifierCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredInterconnectMailbagReceiverID(string interconnectMailbagReceiverID, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagReceiverID = interconnectMailbagReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AL835W", true)]
	public void Validation_RequiredInterconnectMailbagDate(string interconnectMailbagDate, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagDate = interconnectMailbagDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AUqzZ4", true)]
	public void Validation_RequiredInterconnectMailbagTime(string interconnectMailbagTime, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagTime = interconnectMailbagTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vl", true)]
	public void Validation_RequiredInterconnectMailbagTimeCode(string interconnectMailbagTimeCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagControlNumber = 8;
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		subject.InterconnectMailbagTimeCode = interconnectMailbagTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredInterconnectMailbagControlNumber(int interconnectMailbagControlNumber, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagTestIndicatorCode = "D";
		//Test Parameters
		if (interconnectMailbagControlNumber > 0) 
			subject.InterconnectMailbagControlNumber = interconnectMailbagControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredInterconnectMailbagTestIndicatorCode(string interconnectMailbagTestIndicatorCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumberCode = "JFuvw";
		subject.InterconnectMailbagIDQualifierCode = "gl";
		subject.InterconnectMailbagSenderID = "D";
		subject.InterconnectMailbagIDQualifierCode2 = "CW";
		subject.InterconnectMailbagReceiverID = "h";
		subject.InterconnectMailbagDate = "AL835W";
		subject.InterconnectMailbagTime = "AUqzZ4";
		subject.InterconnectMailbagTimeCode = "vl";
		subject.InterconnectMailbagControlNumber = 8;
		//Test Parameters
		subject.InterconnectMailbagTestIndicatorCode = interconnectMailbagTestIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
