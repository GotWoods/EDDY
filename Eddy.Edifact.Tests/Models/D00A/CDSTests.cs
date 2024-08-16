using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDS++x+C";

		var expected = new CDS_CodeSetIdentification()
		{
			CodeSetIdentification = null,
			DesignatedClassCode = "x",
			MaintenanceOperationCode = "C",
		};

		var actual = Map.MapObject<CDS_CodeSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCodeSetIdentification(string codeSetIdentification, bool isValidExpected)
	{
		var subject = new CDS_CodeSetIdentification();
		//Required fields
		//Test Parameters
		if (codeSetIdentification != "") 
			subject.CodeSetIdentification = new C702_CodeSetIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
