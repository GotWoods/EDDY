using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2*L*Q*t*WO*F*7*y*j0U*LXyZhx*rV*A*C*6*1";

		var expected = new W2_EquipmentIdentification()
		{
			EquipmentInitial = "L",
			EquipmentNumber = "Q",
			CommodityCode = "t",
			EquipmentDescriptionCode = "WO",
			EquipmentStatusCode = "F",
			NetTons = 7,
			TOFCIntermodalCodeQualifier = "y",
			CarServiceOrderCode = "j0U",
			EventDate = "LXyZhx",
			TypeOfLocomotiveMaintenanceCode = "rV",
			EquipmentInitial2 = "A",
			EquipmentNumber2 = "C",
			EquipmentNumberCheckDigit = 6,
			Position = "1",
		};

		var actual = Map.MapObject<W2_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentNumber = "Q";
		subject.EquipmentDescriptionCode = "WO";
		subject.EquipmentStatusCode = "F";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "L";
		subject.EquipmentDescriptionCode = "WO";
		subject.EquipmentStatusCode = "F";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WO", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "Q";
		subject.EquipmentStatusCode = "F";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "Q";
		subject.EquipmentDescriptionCode = "WO";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
