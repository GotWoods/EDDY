using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CID*a*sD*LF*I*E*K*p";

		var expected = new CID_CharacteristicClassID()
		{
			MeasurementQualifier = "a",
			ProductProcessCharacteristicCode = "sD",
			AgencyQualifierCode = "LF",
			ProductDescriptionCode = "I",
			Description = "E",
			SourceSubqualifier = "K",
			YesNoConditionOrResponseCode = "p",
		};

		var actual = Map.MapObject<CID_CharacteristicClassID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LF", "I", true)]
	[InlineData("LF", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new CID_CharacteristicClassID();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		//If one is filled, at least one more is required
		if(!string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode) || !string.IsNullOrEmpty(subject.YesNoConditionOrResponseCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.YesNoConditionOrResponseCode = "p";
			subject.ProductDescriptionCode = "I";
			subject.Description = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("p", "I", "E", true)]
	[InlineData("p", "", "", false)]
	[InlineData("", "I", "E", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_YesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new CID_CharacteristicClassID();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.AgencyQualifierCode = "LF";
			subject.ProductDescriptionCode = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
