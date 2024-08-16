using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class BIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BII+F++O";

		var expected = new BII_StructureIdentification()
		{
			IndexingStructureQualifier = "F",
			BillLevelIdentification = null,
			ItemNumber = "O",
		};

		var actual = Map.MapObject<BII_StructureIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredIndexingStructureQualifier(string indexingStructureQualifier, bool isValidExpected)
	{
		var subject = new BII_StructureIdentification();
		//Required fields
		subject.BillLevelIdentification = new C045_BillLevelIdentification();
		//Test Parameters
		subject.IndexingStructureQualifier = indexingStructureQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredBillLevelIdentification(string billLevelIdentification, bool isValidExpected)
	{
		var subject = new BII_StructureIdentification();
		//Required fields
		subject.IndexingStructureQualifier = "F";
		//Test Parameters
		if (billLevelIdentification != "") 
			subject.BillLevelIdentification = new C045_BillLevelIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
