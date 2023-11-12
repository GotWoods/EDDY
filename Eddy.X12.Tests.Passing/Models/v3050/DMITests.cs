using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DMITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DMI*q*Y*c*y*H*yX*Nt*Vxf*rB*yY*X*5";

		var expected = new DMI_DataMaintenanceInformation()
		{
			MaintenanceOperationCode = "q",
			DataMaintenanceNumber = "Y",
			Name = "c",
			AddressInformation = "y",
			AddressInformation2 = "H",
			CityName = "yX",
			StateOrProvinceCode = "Nt",
			PostalCode = "Vxf",
			CountryCode = "rB",
			CommunicationNumberQualifier = "yY",
			CommunicationNumber = "X",
			NoteIdentificationNumber = 5,
		};

		var actual = Map.MapObject<DMI_DataMaintenanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.DataMaintenanceNumber = "Y";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "X";
			subject.CommunicationNumberQualifier = "yY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredDataMaintenanceNumber(string dataMaintenanceNumber, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "q";
		subject.DataMaintenanceNumber = dataMaintenanceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumber) || !string.IsNullOrEmpty(subject.CommunicationNumberQualifier))
		{
			subject.CommunicationNumber = "X";
			subject.CommunicationNumberQualifier = "yY";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "yY", true)]
	[InlineData("X", "", false)]
	[InlineData("", "yY", false)]
	public void Validation_AllAreRequiredCommunicationNumber(string communicationNumber, string communicationNumberQualifier, bool isValidExpected)
	{
		var subject = new DMI_DataMaintenanceInformation();
		subject.MaintenanceOperationCode = "q";
		subject.DataMaintenanceNumber = "Y";
		subject.CommunicationNumber = communicationNumber;
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
