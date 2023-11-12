using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DG1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DG1*Y*I*B*b*3*atupKr*ulzfM3*N";

		var expected = new DG1_DemurrageGuaranteeData()
		{
			EquipmentInitial = "Y",
			EquipmentNumber = "I",
			BillOfLadingWaybillNumber = "B",
			ReferenceIdentification = "b",
			AuthorizationIdentification = "3",
			Date = "atupKr",
			Date2 = "ulzfM3",
			Amount = "N",
		};

		var actual = Map.MapObject<DG1_DemurrageGuaranteeData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentNumber = "I";
		subject.BillOfLadingWaybillNumber = "B";
		subject.AuthorizationIdentification = "3";
		subject.Date = "atupKr";
		subject.Date2 = "ulzfM3";
		subject.Amount = "N";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "Y";
		subject.BillOfLadingWaybillNumber = "B";
		subject.AuthorizationIdentification = "3";
		subject.Date = "atupKr";
		subject.Date2 = "ulzfM3";
		subject.Amount = "N";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "I";
		subject.AuthorizationIdentification = "3";
		subject.Date = "atupKr";
		subject.Date2 = "ulzfM3";
		subject.Amount = "N";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAuthorizationIdentification(string authorizationIdentification, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "I";
		subject.BillOfLadingWaybillNumber = "B";
		subject.Date = "atupKr";
		subject.Date2 = "ulzfM3";
		subject.Amount = "N";
		subject.AuthorizationIdentification = authorizationIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("atupKr", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "I";
		subject.BillOfLadingWaybillNumber = "B";
		subject.AuthorizationIdentification = "3";
		subject.Date2 = "ulzfM3";
		subject.Amount = "N";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ulzfM3", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "I";
		subject.BillOfLadingWaybillNumber = "B";
		subject.AuthorizationIdentification = "3";
		subject.Date = "atupKr";
		subject.Amount = "N";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "I";
		subject.BillOfLadingWaybillNumber = "B";
		subject.AuthorizationIdentification = "3";
		subject.Date = "atupKr";
		subject.Date2 = "ulzfM3";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
