using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCS*dR*HS9IqV*G*SihCdQ*Zw*G*Y*W6*eY*3*7*02";

		var expected = new BCS_BeginningSegmentForProjectCostReporting()
		{
			TransactionSetPurposeCode = "dR",
			Date = "HS9IqV",
			ContractNumber = "G",
			Date2 = "SihCdQ",
			ContractTypeCode = "Zw",
			Description = "G",
			ReferenceNumber = "Y",
			ProgramTypeCode = "W6",
			SecurityLevelCode = "eY",
			Percent = 3,
			Percent2 = 7,
			UnitOrBasisForMeasurementCode = "02",
		};

		var actual = Map.MapObject<BCS_BeginningSegmentForProjectCostReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dR", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.Date = "HS9IqV";
		subject.ContractNumber = "G";
		subject.Date2 = "SihCdQ";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HS9IqV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "dR";
		subject.ContractNumber = "G";
		subject.Date2 = "SihCdQ";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "dR";
		subject.Date = "HS9IqV";
		subject.Date2 = "SihCdQ";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SihCdQ", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "dR";
		subject.Date = "HS9IqV";
		subject.ContractNumber = "G";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
