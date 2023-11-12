using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCS*Cd*PsvngL*3*IGlKT0*EO*0*R*2u*Sc*2*9*Nd";

		var expected = new BCS_BeginningSegmentForProjectCostReporting()
		{
			TransactionSetPurposeCode = "Cd",
			Date = "PsvngL",
			ContractNumber = "3",
			Date2 = "IGlKT0",
			ContractTypeCode = "EO",
			FreeFormDescription = "0",
			ReferenceNumber = "R",
			ProgramTypeCode = "2u",
			SecurityLevelCode = "Sc",
			Percent = 2,
			Percent2 = 9,
			UnitOrBasisForMeasurementCode = "Nd",
		};

		var actual = Map.MapObject<BCS_BeginningSegmentForProjectCostReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cd", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.Date = "PsvngL";
		subject.ContractNumber = "3";
		subject.Date2 = "IGlKT0";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PsvngL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "Cd";
		subject.ContractNumber = "3";
		subject.Date2 = "IGlKT0";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredContractNumber(string contractNumber, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "Cd";
		subject.Date = "PsvngL";
		subject.Date2 = "IGlKT0";
		//Test Parameters
		subject.ContractNumber = contractNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IGlKT0", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BCS_BeginningSegmentForProjectCostReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "Cd";
		subject.Date = "PsvngL";
		subject.ContractNumber = "3";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
