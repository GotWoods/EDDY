using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*0*G*7*Q*W*tu*Xf*3Jn*bc*R9*4*5";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "0",
			DataMaintenanceNumber = "G",
			Name = "7",
			AddressInformation = "Q",
			AddressInformation2 = "W",
			CityName = "tu",
			StateOrProvinceCode = "Xf",
			PostalCode = "3Jn",
			CountryCode = "bc",
			CommunicationNumberQualifier = "R9",
			CommunicationNumber = "4",
			NoteIdentificationNumber = 5,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "G";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "R9";
			subject.CommunicationNumber = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "0";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier) || !string.IsNullOrEmpty(subject.CommunicationNumber))
		{
			subject.CommunicationNumberQualifier = "R9";
			subject.CommunicationNumber = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R9", "4", true)]
	[InlineData("R9", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "0";
		subject.DataMaintenanceNumber = "G";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
