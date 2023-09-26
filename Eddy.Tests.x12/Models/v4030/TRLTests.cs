using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TRLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRL*V*vQXrtotg*BcF1*Q*EB";

		var expected = new TRL_EquipmentUsageInformation()
		{
			EquipmentStatusCode = "V",
			Date = "vQXrtotg",
			Time = "BcF1",
			ShipmentIdentificationNumber = "Q",
			RejectReasonCode = "EB",
		};

		var actual = Map.MapObject<TRL_EquipmentUsageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new TRL_EquipmentUsageInformation();
		//Required fields
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BcF1", "vQXrtotg", true)]
	[InlineData("BcF1", "", false)]
	[InlineData("", "vQXrtotg", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new TRL_EquipmentUsageInformation();
		//Required fields
		subject.EquipmentStatusCode = "V";
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
