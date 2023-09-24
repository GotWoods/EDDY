using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMD*R5*TT*I*kh*iy*T*je8lR6s8*1*H";

		var expected = new TMD_TestMethod()
		{
			ProductProcessCharacteristicCode = "R5",
			AgencyQualifierCode = "TT",
			ProductDescriptionCode = "I",
			TestAdministrationMethodCode = "kh",
			TestMediumCode = "iy",
			Description = "T",
			Date = "je8lR6s8",
			ReferenceIdentification = "1",
			SourceSubqualifier = "H",
		};

		var actual = Map.MapObject<TMD_TestMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TT", "I", true)]
	[InlineData("TT", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "TT", true)]
	[InlineData("H", "", false)]
	[InlineData("", "TT", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.AgencyQualifierCode = "TT";
			subject.ProductDescriptionCode = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
