using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDS++T+O";

		var expected = new CDS_CodeSetIdentification()
		{
			CodeSetIdentification = null,
			ClassDesignatorCoded = "T",
			MaintenanceOperationCoded = "O",
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
