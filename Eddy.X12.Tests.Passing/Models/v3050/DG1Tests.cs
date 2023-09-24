using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DG1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DG1*z*E*x*E*M*4UAbj1*R2maCj*W";

		var expected = new DG1_DemurrageGuaranteeData()
		{
			EquipmentInitial = "z",
			EquipmentNumber = "E",
			BillOfLadingWaybillNumber = "x",
			ReferenceNumber = "E",
			AuthorizationIdentification = "M",
			Date = "4UAbj1",
			Date2 = "R2maCj",
			Amount = "W",
		};

		var actual = Map.MapObject<DG1_DemurrageGuaranteeData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentNumber = "E";
		subject.BillOfLadingWaybillNumber = "x";
		subject.AuthorizationIdentification = "M";
		subject.Date = "4UAbj1";
		subject.Date2 = "R2maCj";
		subject.Amount = "W";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "z";
		subject.BillOfLadingWaybillNumber = "x";
		subject.AuthorizationIdentification = "M";
		subject.Date = "4UAbj1";
		subject.Date2 = "R2maCj";
		subject.Amount = "W";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "E";
		subject.AuthorizationIdentification = "M";
		subject.Date = "4UAbj1";
		subject.Date2 = "R2maCj";
		subject.Amount = "W";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredAuthorizationIdentification(string authorizationIdentification, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "E";
		subject.BillOfLadingWaybillNumber = "x";
		subject.Date = "4UAbj1";
		subject.Date2 = "R2maCj";
		subject.Amount = "W";
		subject.AuthorizationIdentification = authorizationIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4UAbj1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "E";
		subject.BillOfLadingWaybillNumber = "x";
		subject.AuthorizationIdentification = "M";
		subject.Date2 = "R2maCj";
		subject.Amount = "W";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R2maCj", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "E";
		subject.BillOfLadingWaybillNumber = "x";
		subject.AuthorizationIdentification = "M";
		subject.Date = "4UAbj1";
		subject.Amount = "W";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "E";
		subject.BillOfLadingWaybillNumber = "x";
		subject.AuthorizationIdentification = "M";
		subject.Date = "4UAbj1";
		subject.Date2 = "R2maCj";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
