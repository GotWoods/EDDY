using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BHT*KaJf*fZ*D*ZVoo6K*eYQ6";

		var expected = new BHT_BeginningOfHierarchicalTransaction()
		{
			HierarchicalStructureCode = "KaJf",
			TransactionSetPurposeCode = "fZ",
			ReferenceNumber = "D",
			Date = "ZVoo6K",
			Time = "eYQ6",
		};

		var actual = Map.MapObject<BHT_BeginningOfHierarchicalTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KaJf", true)]
	public void Validation_RequiredHierarchicalStructureCode(string hierarchicalStructureCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.TransactionSetPurposeCode = "fZ";
		subject.ReferenceNumber = "D";
		subject.Date = "ZVoo6K";
		//Test Parameters
		subject.HierarchicalStructureCode = hierarchicalStructureCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fZ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "KaJf";
		subject.ReferenceNumber = "D";
		subject.Date = "ZVoo6K";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "KaJf";
		subject.TransactionSetPurposeCode = "fZ";
		subject.Date = "ZVoo6K";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZVoo6K", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "KaJf";
		subject.TransactionSetPurposeCode = "fZ";
		subject.ReferenceNumber = "D";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
