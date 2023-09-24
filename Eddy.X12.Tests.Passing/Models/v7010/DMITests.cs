using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.Tests.Models.v7010;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*K*E*I*S*p*Jm*mO*paA*Jj*yH*C*7";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "K",
			DataMaintenanceNumber = "E",
			Name = "I",
			AddressInformation = "S",
			AddressInformation2 = "p",
			CityName = "Jm",
			StateOrProvinceCode = "mO",
			PostalCode = "paA",
			CountryCode = "Jj",
			CommunicationNumberQualifier = "yH",
			CommunicationNumber = "C",
			NoteIdentificationNumber = 7,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "E";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "K";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yH", "C", true)]
	[InlineData("yH", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredCommunicationNumber(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "K";
		subject.DataMaintenanceNumber = "E";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
