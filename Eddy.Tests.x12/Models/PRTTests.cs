using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRT*4Sp*JX*i*Z";

		var expected = new PRT_PartDisposition()
		{
			DispositionCode = "4Sp",
			AgencyQualifierCode = "JX",
			SourceSubqualifier = "i",
			YesNoConditionOrResponseCode = "Z",
		};

		var actual = Map.MapObject<PRT_PartDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Sp", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new PRT_PartDisposition();
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "JX", true)]
	[InlineData("i", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PRT_PartDisposition();
		subject.DispositionCode = "4Sp";
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
