using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DG1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DG1*o*N*W*9*b*55nLcB*CcpBM1*i";

		var expected = new DG1_DemurrageGuaranteeData()
		{
			EquipmentInitial = "o",
			EquipmentNumber = "N",
			BillOfLadingWaybillNumber = "W",
			ReferenceNumber = "9",
			AuthorizationIdentification = "b",
			AuthorizationDate = "55nLcB",
			Date = "CcpBM1",
			AllowanceOrChargeTotalAmount = "i",
		};

		var actual = Map.MapObject<DG1_DemurrageGuaranteeData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentNumber = "N";
		subject.BillOfLadingWaybillNumber = "W";
		subject.AuthorizationIdentification = "b";
		subject.AuthorizationDate = "55nLcB";
		subject.Date = "CcpBM1";
		subject.AllowanceOrChargeTotalAmount = "i";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "o";
		subject.BillOfLadingWaybillNumber = "W";
		subject.AuthorizationIdentification = "b";
		subject.AuthorizationDate = "55nLcB";
		subject.Date = "CcpBM1";
		subject.AllowanceOrChargeTotalAmount = "i";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "o";
		subject.EquipmentNumber = "N";
		subject.AuthorizationIdentification = "b";
		subject.AuthorizationDate = "55nLcB";
		subject.Date = "CcpBM1";
		subject.AllowanceOrChargeTotalAmount = "i";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredAuthorizationIdentification(string authorizationIdentification, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "o";
		subject.EquipmentNumber = "N";
		subject.BillOfLadingWaybillNumber = "W";
		subject.AuthorizationDate = "55nLcB";
		subject.Date = "CcpBM1";
		subject.AllowanceOrChargeTotalAmount = "i";
		subject.AuthorizationIdentification = authorizationIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("55nLcB", true)]
	public void Validation_RequiredAuthorizationDate(string authorizationDate, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "o";
		subject.EquipmentNumber = "N";
		subject.BillOfLadingWaybillNumber = "W";
		subject.AuthorizationIdentification = "b";
		subject.Date = "CcpBM1";
		subject.AllowanceOrChargeTotalAmount = "i";
		subject.AuthorizationDate = authorizationDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CcpBM1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "o";
		subject.EquipmentNumber = "N";
		subject.BillOfLadingWaybillNumber = "W";
		subject.AuthorizationIdentification = "b";
		subject.AuthorizationDate = "55nLcB";
		subject.AllowanceOrChargeTotalAmount = "i";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAllowanceOrChargeTotalAmount(string allowanceOrChargeTotalAmount, bool isValidExpected)
	{
		var subject = new DG1_DemurrageGuaranteeData();
		subject.EquipmentInitial = "o";
		subject.EquipmentNumber = "N";
		subject.BillOfLadingWaybillNumber = "W";
		subject.AuthorizationIdentification = "b";
		subject.AuthorizationDate = "55nLcB";
		subject.Date = "CcpBM1";
		subject.AllowanceOrChargeTotalAmount = allowanceOrChargeTotalAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
