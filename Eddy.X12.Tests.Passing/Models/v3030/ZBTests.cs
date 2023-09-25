using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ZBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZB*8*n*E*vjSEGR*Wz*F*a";

		var expected = new ZB_BeginningSegmentForRevenueWaybillTraceResponse()
		{
			EquipmentInitial = "8",
			EquipmentNumber = "n",
			TransactionReferenceNumber = "E",
			TransactionReferenceDate = "vjSEGR",
			StandardCarrierAlphaCode = "Wz",
			WaybillResponseCode = "F",
			FreeFormMessage = "a",
		};

		var actual = Map.MapObject<ZB_BeginningSegmentForRevenueWaybillTraceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentNumber = "n";
		subject.TransactionReferenceNumber = "E";
		subject.TransactionReferenceDate = "vjSEGR";
		subject.StandardCarrierAlphaCode = "Wz";
		subject.WaybillResponseCode = "F";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "8";
		subject.TransactionReferenceNumber = "E";
		subject.TransactionReferenceDate = "vjSEGR";
		subject.StandardCarrierAlphaCode = "Wz";
		subject.WaybillResponseCode = "F";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "8";
		subject.EquipmentNumber = "n";
		subject.TransactionReferenceDate = "vjSEGR";
		subject.StandardCarrierAlphaCode = "Wz";
		subject.WaybillResponseCode = "F";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vjSEGR", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "8";
		subject.EquipmentNumber = "n";
		subject.TransactionReferenceNumber = "E";
		subject.StandardCarrierAlphaCode = "Wz";
		subject.WaybillResponseCode = "F";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wz", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "8";
		subject.EquipmentNumber = "n";
		subject.TransactionReferenceNumber = "E";
		subject.TransactionReferenceDate = "vjSEGR";
		subject.WaybillResponseCode = "F";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZB_BeginningSegmentForRevenueWaybillTraceResponse();
		//Required fields
		subject.EquipmentInitial = "8";
		subject.EquipmentNumber = "n";
		subject.TransactionReferenceNumber = "E";
		subject.TransactionReferenceDate = "vjSEGR";
		subject.StandardCarrierAlphaCode = "Wz";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
