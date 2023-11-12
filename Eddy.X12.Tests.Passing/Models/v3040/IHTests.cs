using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IH*F2dPY*a*f*WA*N*h3*l*RH9WOW*QNOdUD*4k*2*E";

		var expected = new IH_InterconnectMailbagHeader()
		{
			InterconnectMailbagVersionNumber = "F2dPY",
			InterconnectMailbagLogonID = "a",
			InterconnectMailbagPassword = "f",
			InterconnectMailbagIDQualifierCode = "WA",
			InterconnectMailbagSenderID = "N",
			InterconnectMailbagIDQualifierCode2 = "h3",
			InterconnectMailbagReceiverID = "l",
			InterconnectMailbagDate = "RH9WOW",
			InterconnectMailbagTime = "QNOdUD",
			InterconnectMailbagTimeCode = "4k",
			InterconnectMailbagControlNumber = 2,
			InterconnectMailbagTestIndicator = "E",
		};

		var actual = Map.MapObject<IH_InterconnectMailbagHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F2dPY", true)]
	public void Validation_RequiredInterconnectMailbagVersionNumber(string interconnectMailbagVersionNumber, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagVersionNumber = interconnectMailbagVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WA", true)]
	public void Validation_RequiredInterconnectMailbagIDQualifierCode(string interconnectMailbagIDQualifierCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagIDQualifierCode = interconnectMailbagIDQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredInterconnectMailbagSenderID(string interconnectMailbagSenderID, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagSenderID = interconnectMailbagSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h3", true)]
	public void Validation_RequiredInterconnectMailbagIDQualifierCode2(string interconnectMailbagIDQualifierCode2, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagIDQualifierCode2 = interconnectMailbagIDQualifierCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredInterconnectMailbagReceiverID(string interconnectMailbagReceiverID, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagReceiverID = interconnectMailbagReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RH9WOW", true)]
	public void Validation_RequiredInterconnectMailbagDate(string interconnectMailbagDate, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagDate = interconnectMailbagDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QNOdUD", true)]
	public void Validation_RequiredInterconnectMailbagTime(string interconnectMailbagTime, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagTime = interconnectMailbagTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4k", true)]
	public void Validation_RequiredInterconnectMailbagTimeCode(string interconnectMailbagTimeCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagControlNumber = 2;
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		subject.InterconnectMailbagTimeCode = interconnectMailbagTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredInterconnectMailbagControlNumber(int interconnectMailbagControlNumber, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagTestIndicator = "E";
		//Test Parameters
		if (interconnectMailbagControlNumber > 0) 
			subject.InterconnectMailbagControlNumber = interconnectMailbagControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredInterconnectMailbagTestIndicator(string interconnectMailbagTestIndicator, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		//Required fields
		subject.InterconnectMailbagVersionNumber = "F2dPY";
		subject.InterconnectMailbagIDQualifierCode = "WA";
		subject.InterconnectMailbagSenderID = "N";
		subject.InterconnectMailbagIDQualifierCode2 = "h3";
		subject.InterconnectMailbagReceiverID = "l";
		subject.InterconnectMailbagDate = "RH9WOW";
		subject.InterconnectMailbagTime = "QNOdUD";
		subject.InterconnectMailbagTimeCode = "4k";
		subject.InterconnectMailbagControlNumber = 2;
		//Test Parameters
		subject.InterconnectMailbagTestIndicator = interconnectMailbagTestIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
