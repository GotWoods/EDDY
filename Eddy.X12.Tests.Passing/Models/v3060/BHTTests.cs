using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BHTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BHT*Ygsi*VH*L*ilw2Q2*zJbx*DV";

		var expected = new BHT_BeginningOfHierarchicalTransaction()
		{
			HierarchicalStructureCode = "Ygsi",
			TransactionSetPurposeCode = "VH",
			ReferenceIdentification = "L",
			Date = "ilw2Q2",
			Time = "zJbx",
			TransactionTypeCode = "DV",
		};

		var actual = Map.MapObject<BHT_BeginningOfHierarchicalTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ygsi", true)]
	public void Validation_RequiredHierarchicalStructureCode(string hierarchicalStructureCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.TransactionSetPurposeCode = "VH";
		//Test Parameters
		subject.HierarchicalStructureCode = hierarchicalStructureCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VH", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BHT_BeginningOfHierarchicalTransaction();
		//Required fields
		subject.HierarchicalStructureCode = "Ygsi";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
