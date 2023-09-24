using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*m*i*W*d*W*Lu*AT*rCV*Yb*cZ*6*9";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "m",
			DataMaintenanceNumber = "i",
			Name = "W",
			AddressInformation = "d",
			AddressInformation2 = "W",
			CityName = "Lu",
			StateOrProvinceCode = "AT",
			PostalCode = "rCV",
			CountryCode = "Yb",
			CommunicationNumberQualifier = "cZ",
			CommunicationNumber = "6",
			NoteIdentificationNumber = 9,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "i";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "6";
			subject.CommunicationNumberQualifier = "cZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "m";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "6";
			subject.CommunicationNumberQualifier = "cZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "cZ", true)]
	[InlineData("6", "", false)]
	[InlineData("", "cZ", false)]
	public void Validation_AllAreRequiredCommunicationNumber(string communicationNumber, string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "m";
		subject.DataMaintenanceNumber = "i";
		subject.CommunicationNumber = communicationNumber;
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
