using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMD*RN*Zk*g*rw*Vl*V*ebL6Uq*9*r";

		var expected = new TMD_TestMethod()
		{
			ProductProcessCharacteristicCode = "RN",
			AgencyQualifierCode = "Zk",
			ProductDescriptionCode = "g",
			TestAdministrationMethodCode = "rw",
			TestMediumCode = "Vl",
			Description = "V",
			Date = "ebL6Uq",
			ReferenceNumber = "9",
			SourceSubqualifier = "r",
		};

		var actual = Map.MapObject<TMD_TestMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Zk", "g", true)]
	[InlineData("Zk", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "Zk", true)]
	[InlineData("r", "", false)]
	[InlineData("", "Zk", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.AgencyQualifierCode = "Zk";
			subject.ProductDescriptionCode = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
