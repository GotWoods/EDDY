using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*7*f*l*3*D*gp*OB*jL6*ys*gD*d*9";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "7",
			DataMaintenanceNumber = "f",
			Name = "l",
			AddressInformation = "3",
			AddressInformation2 = "D",
			CityName = "gp",
			StateOrProvinceCode = "OB",
			PostalCode = "jL6",
			CountryCode = "ys",
			CommunicationNumberQualifier = "gD",
			CommunicationNumber = "d",
			NoteIdentificationNumber = 9,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "f";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "7";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gD", "d", true)]
	[InlineData("gD", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredCommunicationNumber(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "7";
		subject.DataMaintenanceNumber = "f";
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
