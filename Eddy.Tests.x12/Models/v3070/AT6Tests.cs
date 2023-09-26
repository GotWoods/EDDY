using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT6*R9*p*TPt";

		var expected = new AT6_InternationalManifestInformation()
		{
			InternationalDutiableStatusCode = "R9",
			ImportExportCode = "p",
			TransportationTermsCode = "TPt",
		};

		var actual = Map.MapObject<AT6_InternationalManifestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R9", true)]
	public void Validation_RequiredInternationalDutiableStatusCode(string internationalDutiableStatusCode, bool isValidExpected)
	{
		var subject = new AT6_InternationalManifestInformation();
		//Required fields
		subject.ImportExportCode = "p";
		//Test Parameters
		subject.InternationalDutiableStatusCode = internationalDutiableStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredImportExportCode(string importExportCode, bool isValidExpected)
	{
		var subject = new AT6_InternationalManifestInformation();
		//Required fields
		subject.InternationalDutiableStatusCode = "R9";
		//Test Parameters
		subject.ImportExportCode = importExportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
