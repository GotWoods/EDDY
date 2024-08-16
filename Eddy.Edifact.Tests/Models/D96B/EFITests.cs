using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class EFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EFI+++7";

		var expected = new EFI_ExternalFileLinkIdentification()
		{
			FileIdentification = null,
			FileDetails = null,
			SequenceNumber = "7",
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
