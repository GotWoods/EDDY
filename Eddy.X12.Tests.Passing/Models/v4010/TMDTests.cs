using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMD*ZG*9f*o*5P*B8*o*TzO1Q8um*7*s";

		var expected = new TMD_TestMethod()
		{
			ProductProcessCharacteristicCode = "ZG",
			AgencyQualifierCode = "9f",
			ProductDescriptionCode = "o",
			TestAdministrationMethodCode = "5P",
			TestMediumCode = "B8",
			Description = "o",
			Date = "TzO1Q8um",
			ReferenceIdentification = "7",
			SourceSubqualifier = "s",
		};

		var actual = Map.MapObject<TMD_TestMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9f", "o", true)]
	[InlineData("9f", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "9f", true)]
	[InlineData("s", "", false)]
	[InlineData("", "9f", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.AgencyQualifierCode = "9f";
			subject.ProductDescriptionCode = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
