using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C815Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:X:P:Z";

		var expected = new C815_AdditionalSafetyInformation()
		{
			AdditionalSafetyInformationDescriptionCode = "o",
			CodeListIdentificationCode = "X",
			CodeListResponsibleAgencyCode = "P",
			AdditionalSafetyInformationDescription = "Z",
		};

		var actual = Map.MapComposite<C815_AdditionalSafetyInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredAdditionalSafetyInformationDescriptionCode(string additionalSafetyInformationDescriptionCode, bool isValidExpected)
	{
		var subject = new C815_AdditionalSafetyInformation();
		//Required fields
		//Test Parameters
		subject.AdditionalSafetyInformationDescriptionCode = additionalSafetyInformationDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
