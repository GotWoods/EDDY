using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*V*m*U*4*h*BU*w1*FFo*5y*65*2*6";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "V",
			DataMaintenanceNumber = "m",
			Name = "U",
			AddressInformation = "4",
			AddressInformation2 = "h",
			CityName = "BU",
			StateOrProvinceCode = "w1",
			PostalCode = "FFo",
			CountryCode = "5y",
			CommunicationNumberQualifier = "65",
			CommunicationNumber = "2",
			NoteIdentificationNumber = 6,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "m";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validatation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "V";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("65", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("65", "", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "V";
		subject.DataMaintenanceNumber = "m";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
