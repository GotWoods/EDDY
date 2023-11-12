using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*Q*P*V*5*1*pc*Ov*8rdl*sl*Nl*QbL4ziN*8";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "Q",
			DataMaintenanceNumber = "P",
			Name = "V",
			AddressInformation = "5",
			AddressInformation2 = "1",
			CityName = "pc",
			StateOrProvinceCode = "Ov",
			PostalCode = "8rdl",
			CountryCode = "sl",
			CommunicationNumberQualifier = "Nl",
			CommunicationNumber = "QbL4ziN",
			NoteIdentificationNumber = 8,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "P";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "QbL4ziN";
			subject.CommunicationNumberQualifier = "Nl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "Q";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "QbL4ziN";
			subject.CommunicationNumberQualifier = "Nl";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QbL4ziN", "Nl", true)]
	[InlineData("QbL4ziN", "", false)]
	[InlineData("", "Nl", false)]
	public void Validation_AllAreRequiredCommunicationNumber(string communicationNumber, string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "Q";
		subject.DataMaintenanceNumber = "P";
		subject.CommunicationNumber = communicationNumber;
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
