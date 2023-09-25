using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2*t*2*g*qi*E*6*q*WXO*ycauhL*eu*c*9*7*Q";

		var expected = new W2_EquipmentIdentification()
		{
			EquipmentInitial = "t",
			EquipmentNumber = "2",
			CommodityCode = "g",
			EquipmentDescriptionCode = "qi",
			EquipmentStatusCode = "E",
			NetTons = 6,
			IntermodalServiceCode = "q",
			CarServiceOrderCode = "WXO",
			Date = "ycauhL",
			TypeOfLocomotiveMaintenanceCode = "eu",
			EquipmentInitial2 = "c",
			EquipmentNumber2 = "9",
			EquipmentNumberCheckDigit = 7,
			Position = "Q",
		};

		var actual = Map.MapObject<W2_EquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentNumber = "2";
		subject.EquipmentDescriptionCode = "qi";
		subject.EquipmentStatusCode = "E";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "ycauhL";
			subject.TypeOfLocomotiveMaintenanceCode = "eu";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "c";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "t";
		subject.EquipmentDescriptionCode = "qi";
		subject.EquipmentStatusCode = "E";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "ycauhL";
			subject.TypeOfLocomotiveMaintenanceCode = "eu";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "c";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qi", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "t";
		subject.EquipmentNumber = "2";
		subject.EquipmentStatusCode = "E";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "ycauhL";
			subject.TypeOfLocomotiveMaintenanceCode = "eu";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "c";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "t";
		subject.EquipmentNumber = "2";
		subject.EquipmentDescriptionCode = "qi";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "ycauhL";
			subject.TypeOfLocomotiveMaintenanceCode = "eu";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "c";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ycauhL", "eu", true)]
	[InlineData("ycauhL", "", false)]
	[InlineData("", "eu", false)]
	public void Validation_AllAreRequiredDate(string date, string typeOfLocomotiveMaintenanceCode, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "t";
		subject.EquipmentNumber = "2";
		subject.EquipmentDescriptionCode = "qi";
		subject.EquipmentStatusCode = "E";
		//Test Parameters
		subject.Date = date;
		subject.TypeOfLocomotiveMaintenanceCode = typeOfLocomotiveMaintenanceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "c";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "9", true)]
	[InlineData("c", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new W2_EquipmentIdentification();
		//Required fields
		subject.EquipmentInitial = "t";
		subject.EquipmentNumber = "2";
		subject.EquipmentDescriptionCode = "qi";
		subject.EquipmentStatusCode = "E";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.TypeOfLocomotiveMaintenanceCode))
		{
			subject.Date = "ycauhL";
			subject.TypeOfLocomotiveMaintenanceCode = "eu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
