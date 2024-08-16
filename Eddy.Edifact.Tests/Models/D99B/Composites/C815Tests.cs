using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C815Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:B:b:p";

		var expected = new C815_AdditionalSafetyInformation()
		{
			AdditionalSafetyInformationCoded = "C",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "b",
			AdditionalSafetyInformation = "p",
		};

		var actual = Map.MapComposite<C815_AdditionalSafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredAdditionalSafetyInformationCoded(string additionalSafetyInformationCoded, bool isValidExpected)
	{
		var subject = new C815_AdditionalSafetyInformation();
		//Required fields
		//Test Parameters
		subject.AdditionalSafetyInformationCoded = additionalSafetyInformationCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
