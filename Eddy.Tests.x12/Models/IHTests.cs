using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IH*0YfxS*k*E*Mf*k*ER*q*kivYQS*hGNWFs*86*4*O";

		var expected = new IH_InterconnectMailbagHeader()
		{
			InterconnectMailbagVersionNumberCode = "0YfxS",
			InterconnectMailbagLogonID = "k",
			InterconnectMailbagPassword = "E",
			InterconnectMailbagIDQualifierCode = "Mf",
			InterconnectMailbagSenderID = "k",
			InterconnectMailbagIDQualifierCode2 = "ER",
			InterconnectMailbagReceiverID = "q",
			InterconnectMailbagDate = "kivYQS",
			InterconnectMailbagTime = "hGNWFs",
			InterconnectMailbagTimeCode = "86",
			InterconnectMailbagControlNumber = 4,
			InterconnectMailbagTestIndicatorCode = "O",
		};

		var actual = Map.MapObject<IH_InterconnectMailbagHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0YfxS", true)]
	public void Validation_RequiredInterconnectMailbagVersionNumberCode(string interconnectMailbagVersionNumberCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagVersionNumberCode = interconnectMailbagVersionNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mf", true)]
	public void Validation_RequiredInterconnectMailbagIDQualifierCode(string interconnectMailbagIDQualifierCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagIDQualifierCode = interconnectMailbagIDQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredInterconnectMailbagSenderID(string interconnectMailbagSenderID, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagSenderID = interconnectMailbagSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ER", true)]
	public void Validation_RequiredInterconnectMailbagIDQualifierCode2(string interconnectMailbagIDQualifierCode2, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagIDQualifierCode2 = interconnectMailbagIDQualifierCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredInterconnectMailbagReceiverID(string interconnectMailbagReceiverID, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagReceiverID = interconnectMailbagReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kivYQS", true)]
	public void Validation_RequiredInterconnectMailbagDate(string interconnectMailbagDate, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagDate = interconnectMailbagDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hGNWFs", true)]
	public void Validation_RequiredInterconnectMailbagTime(string interconnectMailbagTime, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagTime = interconnectMailbagTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("86", true)]
	public void Validation_RequiredInterconnectMailbagTimeCode(string interconnectMailbagTimeCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = "O";
		subject.InterconnectMailbagTimeCode = interconnectMailbagTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredInterconnectMailbagControlNumber(int interconnectMailbagControlNumber, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagTestIndicatorCode = "O";
		if (interconnectMailbagControlNumber > 0)
		subject.InterconnectMailbagControlNumber = interconnectMailbagControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredInterconnectMailbagTestIndicatorCode(string interconnectMailbagTestIndicatorCode, bool isValidExpected)
	{
		var subject = new IH_InterconnectMailbagHeader();
		subject.InterconnectMailbagVersionNumberCode = "0YfxS";
		subject.InterconnectMailbagIDQualifierCode = "Mf";
		subject.InterconnectMailbagSenderID = "k";
		subject.InterconnectMailbagIDQualifierCode2 = "ER";
		subject.InterconnectMailbagReceiverID = "q";
		subject.InterconnectMailbagDate = "kivYQS";
		subject.InterconnectMailbagTime = "hGNWFs";
		subject.InterconnectMailbagTimeCode = "86";
		subject.InterconnectMailbagControlNumber = 4;
		subject.InterconnectMailbagTestIndicatorCode = interconnectMailbagTestIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
