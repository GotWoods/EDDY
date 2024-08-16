using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class EFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EFI+++Q+n";

		var expected = new EFI_ExternalFileLinkIdentification()
		{
			FileIdentification = null,
			FileDetails = null,
			SequencePositionIdentifier = "Q",
			FileCompressionTechniqueName = "n",
		};

		var actual = Map.MapObject<EFI_ExternalFileLinkIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredFileIdentification(string fileIdentification, bool isValidExpected)
	{
		var subject = new EFI_ExternalFileLinkIdentification();
		//Required fields
		//Test Parameters
		if (fileIdentification != "") 
			subject.FileIdentification = new C077_FileIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
