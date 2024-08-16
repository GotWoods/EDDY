using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UNGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNG+d++++V+l++4";

		var expected = new UNG_FunctionalGroupHeader()
		{
			FunctionalGroupIdentification = "d",
			ApplicationSendersIdentification = null,
			ApplicationRecipientsIdentification = null,
			DateTimeOfPreparation = null,
			FunctionalGroupReferenceNumber = "V",
			ControllingAgency = "l",
			MessageVersion = null,
			ApplicationPassword = "4",
		};

		var actual = Map.MapObject<UNG_FunctionalGroupHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredFunctionalGroupIdentification(string functionalGroupIdentification, bool isValidExpected)
	{
		var subject = new UNG_FunctionalGroupHeader();
		//Required fields
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.FunctionalGroupReferenceNumber = "V";
		subject.ControllingAgency = "l";
		subject.MessageVersion = new S008_MessageVersion();
		//Test Parameters
		subject.FunctionalGroupIdentification = functionalGroupIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredApplicationSendersIdentification(string applicationSendersIdentification, bool isValidExpected)
	{
		var subject = new UNG_FunctionalGroupHeader();
		//Required fields
		subject.FunctionalGroupIdentification = "d";
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.FunctionalGroupReferenceNumber = "V";
		subject.ControllingAgency = "l";
		subject.MessageVersion = new S008_MessageVersion();
		//Test Parameters
		if (applicationSendersIdentification != "") 
			subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredApplicationRecipientsIdentification(string applicationRecipientsIdentification, bool isValidExpected)
	{
		var subject = new UNG_FunctionalGroupHeader();
		//Required fields
		subject.FunctionalGroupIdentification = "d";
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.FunctionalGroupReferenceNumber = "V";
		subject.ControllingAgency = "l";
		subject.MessageVersion = new S008_MessageVersion();
		//Test Parameters
		if (applicationRecipientsIdentification != "") 
			subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateTimeOfPreparation(string dateTimeOfPreparation, bool isValidExpected)
	{
		var subject = new UNG_FunctionalGroupHeader();
		//Required fields
		subject.FunctionalGroupIdentification = "d";
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.FunctionalGroupReferenceNumber = "V";
		subject.ControllingAgency = "l";
		subject.MessageVersion = new S008_MessageVersion();
		//Test Parameters
		if (dateTimeOfPreparation != "") 
			subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredFunctionalGroupReferenceNumber(string functionalGroupReferenceNumber, bool isValidExpected)
	{
		var subject = new UNG_FunctionalGroupHeader();
		//Required fields
		subject.FunctionalGroupIdentification = "d";
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.ControllingAgency = "l";
		subject.MessageVersion = new S008_MessageVersion();
		//Test Parameters
		subject.FunctionalGroupReferenceNumber = functionalGroupReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredControllingAgency(string controllingAgency, bool isValidExpected)
	{
		var subject = new UNG_FunctionalGroupHeader();
		//Required fields
		subject.FunctionalGroupIdentification = "d";
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.FunctionalGroupReferenceNumber = "V";
		subject.MessageVersion = new S008_MessageVersion();
		//Test Parameters
		subject.ControllingAgency = controllingAgency;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMessageVersion(string messageVersion, bool isValidExpected)
	{
		var subject = new UNG_FunctionalGroupHeader();
		//Required fields
		subject.FunctionalGroupIdentification = "d";
		subject.ApplicationSendersIdentification = new S006_ApplicationSendersIdentification();
		subject.ApplicationRecipientsIdentification = new S007_ApplicationRecipientsIdentification();
		subject.DateTimeOfPreparation = new S004_DateTimeOfPreparation();
		subject.FunctionalGroupReferenceNumber = "V";
		subject.ControllingAgency = "l";
		//Test Parameters
		if (messageVersion != "") 
			subject.MessageVersion = new S008_MessageVersion();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
