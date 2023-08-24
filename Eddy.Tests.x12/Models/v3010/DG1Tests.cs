using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DG1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DG1*b*k*7*L*I*e9ZD3f*1Iyy6i*K";

		var expected = new DG1_DemurrageGuaranteeData()
		{
			EquipmentInitial = "b",
			EquipmentNumber = "k",
			BillOfLadingWaybillNumber = "7",
			ReferenceNumber = "L",
			AuthorizationIdentification = "I",
			AuthorizationDate = "e9ZD3f",
			Date = "1Iyy6i",
			AllowanceOrChargeTotalAmount = "K",
		};

		var actual = Map.MapObject<DG1_DemurrageGuaranteeData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentNumber = "k";
		subject.BillOfLadingWaybillNumber = "7";
		subject.AuthorizationIdentification = "I";
		subject.AuthorizationDate = "e9ZD3f";
		subject.Date = "1Iyy6i";
		subject.AllowanceOrChargeTotalAmount = "K";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "b";
		subject.BillOfLadingWaybillNumber = "7";
		subject.AuthorizationIdentification = "I";
		subject.AuthorizationDate = "e9ZD3f";
		subject.Date = "1Iyy6i";
		subject.AllowanceOrChargeTotalAmount = "K";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "k";
		subject.AuthorizationIdentification = "I";
		subject.AuthorizationDate = "e9ZD3f";
		subject.Date = "1Iyy6i";
		subject.AllowanceOrChargeTotalAmount = "K";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAuthorizationIdentification(string authorizationIdentification, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "k";
		subject.BillOfLadingWaybillNumber = "7";
		subject.AuthorizationDate = "e9ZD3f";
		subject.Date = "1Iyy6i";
		subject.AllowanceOrChargeTotalAmount = "K";
		subject.AuthorizationIdentification = authorizationIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e9ZD3f", true)]
	public void Validation_RequiredAuthorizationDate(string authorizationDate, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "k";
		subject.BillOfLadingWaybillNumber = "7";
		subject.AuthorizationIdentification = "I";
		subject.Date = "1Iyy6i";
		subject.AllowanceOrChargeTotalAmount = "K";
		subject.AuthorizationDate = authorizationDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1Iyy6i", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "k";
		subject.BillOfLadingWaybillNumber = "7";
		subject.AuthorizationIdentification = "I";
		subject.AuthorizationDate = "e9ZD3f";
		subject.AllowanceOrChargeTotalAmount = "K";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredAllowanceOrChargeTotalAmount(string allowanceOrChargeTotalAmount, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "k";
		subject.BillOfLadingWaybillNumber = "7";
		subject.AuthorizationIdentification = "I";
		subject.AuthorizationDate = "e9ZD3f";
		subject.Date = "1Iyy6i";
		subject.AllowanceOrChargeTotalAmount = allowanceOrChargeTotalAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
