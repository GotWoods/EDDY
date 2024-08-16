using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class BIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BII+X++p";

		var expected = new BII_StructureIdentification()
		{
			IndexingStructureCodeQualifier = "X",
			BillLevelIdentification = null,
			ItemIdentifier = "p",
		};

		var actual = Map.MapObject<BII_StructureIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredIndexingStructureCodeQualifier(string indexingStructureCodeQualifier, bool isValidExpected)
	{
		var subject = new BII_StructureIdentification();
		//Required fields
		subject.BillLevelIdentification = new C045_BillLevelIdentification();
		//Test Parameters
		subject.IndexingStructureCodeQualifier = indexingStructureCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredBillLevelIdentification(string billLevelIdentification, bool isValidExpected)
	{
		var subject = new BII_StructureIdentification();
		//Required fields
		subject.IndexingStructureCodeQualifier = "X";
		//Test Parameters
		if (billLevelIdentification != "") 
			subject.BillLevelIdentification = new C045_BillLevelIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
