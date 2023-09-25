using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BHT*c6rs*JR*6*bdX19Y*PL0M";

		var expected = new BHT_BeginningOfHierarchicalTransaction()
		{
			HierarchicalStructureCode = "c6rs",
			TransactionSetPurposeCode = "JR",
			ReferenceNumber = "6",
			Date = "bdX19Y",
			Time = "PL0M",
		};

		var actual = Map.MapObject<BHT_BeginningOfHierarchicalTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c6rs", true)]
	public void Validation_RequiredHierarchicalStructureCode(string hierarchicalStructureCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.TransactionSetPurposeCode = "JR";
		subject.ReferenceNumber = "6";
		subject.Date = "bdX19Y";
		//Test Parameters
		subject.HierarchicalStructureCode = hierarchicalStructureCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JR", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "c6rs";
		subject.ReferenceNumber = "6";
		subject.Date = "bdX19Y";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "c6rs";
		subject.TransactionSetPurposeCode = "JR";
		subject.Date = "bdX19Y";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bdX19Y", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "c6rs";
		subject.TransactionSetPurposeCode = "JR";
		subject.ReferenceNumber = "6";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
