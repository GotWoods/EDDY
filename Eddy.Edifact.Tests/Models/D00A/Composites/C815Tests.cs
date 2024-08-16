using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C815Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:B:7:I";

		var expected = new C815_AdditionalSafetyInformation()
		{
			AdditionalSafetyInformationDescriptionCode = "T",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "7",
			AdditionalSafetyInformationDescription = "I",
		};

		var actual = Map.MapComposite<C815_AdditionalSafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredAdditionalSafetyInformationDescriptionCode(string additionalSafetyInformationDescriptionCode, bool isValidExpected)
	{
		var subject = new C815_AdditionalSafetyInformation();
		//Required fields
		//Test Parameters
		subject.AdditionalSafetyInformationDescriptionCode = additionalSafetyInformationDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
