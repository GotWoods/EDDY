using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C099Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:Z:L:7";

		var expected = new C099_FileDetails()
		{
			FileFormat = "d",
			Version = "Z",
			DataFormatDescriptionCode = "L",
			DataFormatDescription = "7",
		};

		var actual = Map.MapComposite<C099_FileDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredFileFormat(string fileFormat, bool isValidExpected)
	{
		var subject = new C099_FileDetails();
		//Required fields
		//Test Parameters
		subject.FileFormat = fileFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
