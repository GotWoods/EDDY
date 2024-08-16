using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C815Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:q:z:A";

		var expected = new C815_AdditionalSafetyInformation()
		{
			AdditionalSafetyInformationCoded = "Z",
			CodeListQualifier = "q",
			CodeListResponsibleAgencyCoded = "z",
			AdditionalSafetyInformation = "A",
		};

		var actual = Map.MapComposite<C815_AdditionalSafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredAdditionalSafetyInformationCoded(string additionalSafetyInformationCoded, bool isValidExpected)
	{
		var subject = new C815_AdditionalSafetyInformation();
		//Required fields
		//Test Parameters
		subject.AdditionalSafetyInformationCoded = additionalSafetyInformationCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
