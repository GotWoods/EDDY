using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C099Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:S:K:9";

		var expected = new C099_FileDetails()
		{
			FileFormatName = "m",
			VersionIdentifier = "S",
			DataFormatDescriptionCode = "K",
			DataFormatDescription = "9",
		};

		var actual = Map.MapComposite<C099_FileDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredFileFormatName(string fileFormatName, bool isValidExpected)
	{
		var subject = new C099_FileDetails();
		//Required fields
		//Test Parameters
		subject.FileFormatName = fileFormatName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
