using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*M*b*b*d*0*QD*WB*rhJU*7T*Q3*gbqmdLZ*7";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "M",
			DataMaintenanceNumber = "b",
			Name = "b",
			AddressInformation = "d",
			AddressInformation2 = "0",
			CityName = "QD",
			StateOrProvinceCode = "WB",
			PostalCode = "rhJU",
			CountryCode = "7T",
			CommunicationNumberQualifier = "Q3",
			CommunicationNumber = "gbqmdLZ",
			NoteIdentificationNumber = 7,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "b";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "M";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
