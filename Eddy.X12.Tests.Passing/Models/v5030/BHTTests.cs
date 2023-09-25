using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BHT*YJNi*1A*G*J1Ll4pAY*deqa*ye";

		var expected = new BHT_BeginningOfHierarchicalTransaction()
		{
			HierarchicalStructureCode = "YJNi",
			TransactionSetPurposeCode = "1A",
			ReferenceIdentification = "G",
			Date = "J1Ll4pAY",
			Time = "deqa",
			TransactionTypeCode = "ye",
		};

		var actual = Map.MapObject<BHT_BeginningOfHierarchicalTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YJNi", true)]
	public void Validation_RequiredHierarchicalStructureCode(string hierarchicalStructureCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.TransactionSetPurposeCode = "1A";
		//Test Parameters
		subject.HierarchicalStructureCode = hierarchicalStructureCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1A", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "YJNi";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
