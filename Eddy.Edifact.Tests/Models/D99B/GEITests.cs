using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class GEITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GEI+b++P";

		var expected = new GEI_ProcessingInformation()
		{
			ProcessingInformationCodeQualifier = "b",
			ProcessingIndicator = null,
			ProcessTypeDescriptionCode = "P",
		};

		var actual = Map.MapObject<GEI_ProcessingInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredProcessingInformationCodeQualifier(string processingInformationCodeQualifier, bool isValidExpected)
	{
		var subject = new GEI_ProcessingInformation();
		//Required fields
		//Test Parameters
		subject.ProcessingInformationCodeQualifier = processingInformationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
