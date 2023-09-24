using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMD*37*eB*7*ZH*nv*K*p7009n*N*9";

		var expected = new TMD_TestMethod()
		{
			ProductProcessCharacteristicCode = "37",
			AgencyQualifierCode = "eB",
			ProductDescriptionCode = "7",
			TestAdministrationMethodCode = "ZH",
			TestMediumCode = "nv",
			Description = "K",
			Date = "p7009n",
			ReferenceIdentification = "N",
			SourceSubqualifier = "9",
		};

		var actual = Map.MapObject<TMD_TestMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eB", "7", true)]
	[InlineData("eB", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "eB", true)]
	[InlineData("9", "", false)]
	[InlineData("", "eB", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.AgencyQualifierCode = "eB";
			subject.ProductDescriptionCode = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
