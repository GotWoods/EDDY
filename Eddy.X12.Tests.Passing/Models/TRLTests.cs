using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TRLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRL*K*G1uokEQX*CrNU*f*3a";

		var expected = new TRL_EquipmentUsageInformation()
		{
			EquipmentStatusCode = "K",
			Date = "G1uokEQX",
			Time = "CrNU",
			ShipmentIdentificationNumber = "f",
			RejectReasonCode = "3a",
		};

		var actual = Map.MapObject<TRL_EquipmentUsageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new TRL_EquipmentUsageInformation();
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "G1uokEQX", true)]
	[InlineData("CrNU", "", false)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new TRL_EquipmentUsageInformation();
		subject.EquipmentStatusCode = "K";
		subject.Time = time;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
