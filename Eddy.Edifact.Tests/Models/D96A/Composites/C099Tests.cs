using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C099Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:e:Y:H";

		var expected = new C099_FileDetails()
		{
			FileFormat = "x",
			Version = "e",
			DataFormatCoded = "Y",
			DataFormat = "H",
		};

		var actual = Map.MapComposite<C099_FileDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredFileFormat(string fileFormat, bool isValidExpected)
	{
		var subject = new C099_FileDetails();
		//Required fields
		//Test Parameters
		subject.FileFormat = fileFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
