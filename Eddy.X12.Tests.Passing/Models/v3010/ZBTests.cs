using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ZBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZB*G*H*49*J92eVM*se*5*n";

		var expected = new ZB_BeginningSegmentForRevenueWaybillTraceResponse()
		{
			EquipmentInitial = "G",
			EquipmentNumber = "H",
			TransactionReferenceNumber = "49",
			TransactionReferenceDate = "J92eVM",
			StandardCarrierAlphaCode = "se",
			WaybillRequestResponseCode = "5",
			FreeFormMessage = "n",
		};

		var actual = Map.MapObject<ZB_BeginningSegmentForRevenueWaybillTraceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentNumber = "H";
		subject.TransactionReferenceNumber = "49";
		subject.TransactionReferenceDate = "J92eVM";
		subject.StandardCarrierAlphaCode = "se";
		subject.WaybillRequestResponseCode = "5";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.TransactionReferenceNumber = "49";
		subject.TransactionReferenceDate = "J92eVM";
		subject.StandardCarrierAlphaCode = "se";
		subject.WaybillRequestResponseCode = "5";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("49", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "H";
		subject.TransactionReferenceDate = "J92eVM";
		subject.StandardCarrierAlphaCode = "se";
		subject.WaybillRequestResponseCode = "5";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J92eVM", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "H";
		subject.TransactionReferenceNumber = "49";
		subject.StandardCarrierAlphaCode = "se";
		subject.WaybillRequestResponseCode = "5";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("se", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "H";
		subject.TransactionReferenceNumber = "49";
		subject.TransactionReferenceDate = "J92eVM";
		subject.WaybillRequestResponseCode = "5";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredWaybillRequestResponseCode(string waybillRequestResponseCode, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "H";
		subject.TransactionReferenceNumber = "49";
		subject.TransactionReferenceDate = "J92eVM";
		subject.StandardCarrierAlphaCode = "se";
		//Test Parameters
		subject.WaybillRequestResponseCode = waybillRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
