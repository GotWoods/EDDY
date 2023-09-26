using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ISATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISA*du*aj4W9oSAnd*Rn*P0ICvYpUh3*gr*TkALp997ao0ww00*3f*nv8gGcFCs9KsL7u*14itCC*DXXz*n*hod5V*227886853*S*X*b";

		var expected = new ISA_InterchangeControlHeader()
		{
			AuthorizationInformationQualifier = "du",
			AuthorizationInformation = "aj4W9oSAnd",
			SecurityInformationQualifier = "Rn",
			SecurityInformation = "P0ICvYpUh3",
			InterchangeIDQualifier = "gr",
			InterchangeSenderID = "TkALp997ao0ww00",
			InterchangeIDQualifier2 = "3f",
			InterchangeReceiverID = "nv8gGcFCs9KsL7u",
			InterchangeDate = "14itCC",
			InterchangeTime = "DXXz",
			RepetitionSeparator = "n",
			InterchangeControlVersionNumberCode = "hod5V",
			InterchangeControlNumber = 227886853,
			AcknowledgmentRequestedCode = "S",
			InterchangeUsageIndicatorCode = "X",
			ComponentElementSeparator = "b",
		};

		var actual = Map.MapObject<ISA_InterchangeControlHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("du", true)]
	public void Validation_RequiredAuthorizationInformationQualifier(string authorizationInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.AuthorizationInformationQualifier = authorizationInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aj4W9oSAnd", true)]
	public void Validation_RequiredAuthorizationInformation(string authorizationInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.AuthorizationInformation = authorizationInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rn", true)]
	public void Validation_RequiredSecurityInformationQualifier(string securityInformationQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.SecurityInformationQualifier = securityInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P0ICvYpUh3", true)]
	public void Validation_RequiredSecurityInformation(string securityInformation, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.SecurityInformation = securityInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gr", true)]
	public void Validation_RequiredInterchangeIDQualifier(string interchangeIDQualifier, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeIDQualifier = interchangeIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TkALp997ao0ww00", true)]
	public void Validation_RequiredInterchangeSenderID(string interchangeSenderID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeSenderID = interchangeSenderID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3f", true)]
	public void Validation_RequiredInterchangeIDQualifier2(string interchangeIDQualifier2, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeIDQualifier2 = interchangeIDQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nv8gGcFCs9KsL7u", true)]
	public void Validation_RequiredInterchangeReceiverID(string interchangeReceiverID, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeReceiverID = interchangeReceiverID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("14itCC", true)]
	public void Validation_RequiredInterchangeDate(string interchangeDate, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeDate = interchangeDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DXXz", true)]
	public void Validation_RequiredInterchangeTime(string interchangeTime, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeTime = interchangeTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredRepetitionSeparator(string repetitionSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.RepetitionSeparator = repetitionSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hod5V", true)]
	public void Validation_RequiredInterchangeControlVersionNumberCode(string interchangeControlVersionNumberCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeControlVersionNumberCode = interchangeControlVersionNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(227886853, true)]
	public void Validation_RequiredInterchangeControlNumber(int interchangeControlNumber, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		if (interchangeControlNumber > 0) 
			subject.InterchangeControlNumber = interchangeControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredAcknowledgmentRequestedCode(string acknowledgmentRequestedCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.InterchangeUsageIndicatorCode = "X";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.AcknowledgmentRequestedCode = acknowledgmentRequestedCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredInterchangeUsageIndicatorCode(string interchangeUsageIndicatorCode, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.ComponentElementSeparator = "b";
		//Test Parameters
		subject.InterchangeUsageIndicatorCode = interchangeUsageIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredComponentElementSeparator(string componentElementSeparator, bool isValidExpected)
	{
		var subject = new ISA_InterchangeControlHeader();
		//Required fields
		subject.AuthorizationInformationQualifier = "du";
		subject.AuthorizationInformation = "aj4W9oSAnd";
		subject.SecurityInformationQualifier = "Rn";
		subject.SecurityInformation = "P0ICvYpUh3";
		subject.InterchangeIDQualifier = "gr";
		subject.InterchangeSenderID = "TkALp997ao0ww00";
		subject.InterchangeIDQualifier2 = "3f";
		subject.InterchangeReceiverID = "nv8gGcFCs9KsL7u";
		subject.InterchangeDate = "14itCC";
		subject.InterchangeTime = "DXXz";
		subject.RepetitionSeparator = "n";
		subject.InterchangeControlVersionNumberCode = "hod5V";
		subject.InterchangeControlNumber = 227886853;
		subject.AcknowledgmentRequestedCode = "S";
		subject.InterchangeUsageIndicatorCode = "X";
		//Test Parameters
		subject.ComponentElementSeparator = componentElementSeparator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
