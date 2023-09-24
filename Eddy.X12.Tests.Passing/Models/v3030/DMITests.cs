using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*V*6*4*k*6*H7*ZC*ULr*HJ*rC*A*2";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "V",
			DataMaintenanceNumber = "6",
			Name = "4",
			AddressInformation = "k",
			AddressInformation2 = "6",
			CityName = "H7",
			StateOrProvinceCode = "ZC",
			PostalCode = "ULr",
			CountryCode = "HJ",
			CommunicationNumberQualifier = "rC",
			CommunicationNumber = "A",
			NoteIdentificationNumber = 2,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "6";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "A";
			subject.CommunicationNumberQualifier = "rC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "V";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "A";
			subject.CommunicationNumberQualifier = "rC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "rC", true)]
	[InlineData("A", "", false)]
	[InlineData("", "rC", false)]
	public void Validation_AllAreRequiredCommunicationNumber(string communicationNumber, string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "V";
		subject.DataMaintenanceNumber = "6";
		subject.CommunicationNumber = communicationNumber;
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
