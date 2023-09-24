using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*2*J*w*T*G*ew*82*HN5*CP*VI*C*9";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "2",
			DataMaintenanceNumber = "J",
			Name = "w",
			AddressInformation = "T",
			AddressInformation2 = "G",
			CityName = "ew",
			StateOrProvinceCode = "82",
			PostalCode = "HN5",
			CountryCode = "CP",
			CommunicationNumberQualifier = "VI",
			CommunicationNumber = "C",
			NoteIdentificationNumber = 9,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "J";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "2";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VI", "C", true)]
	[InlineData("VI", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredCommunicationNumber(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "2";
		subject.DataMaintenanceNumber = "J";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
