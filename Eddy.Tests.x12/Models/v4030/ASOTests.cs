using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ASOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ASO*V*KK*8k*r*q**6*2*4*Hn*8";

		var expected = new ASO_AssetOwnership()
		{
			PropertyOwnershipRightsCode = "V",
			TypeOfPersonalOrBusinessAssetCode = "KK",
			TypeOfPersonalOrBusinessAssetCode2 = "8k",
			FreeFormMessageText = "r",
			GeneralPropertyOwnershipCode = "q",
			AmountQualifyingDescription = null,
			MonetaryAmount = 6,
			Percent = 2,
			Quantity = 4,
			ReferenceIdentificationQualifier = "Hn",
			ReferenceIdentification = "8",
		};

		var actual = Map.MapObject<ASO_AssetOwnership>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "KK";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Hn";
			subject.ReferenceIdentification = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KK", true)]
	public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.PropertyOwnershipRightsCode = "V";
		//Test Parameters
		subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Hn";
			subject.ReferenceIdentification = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hn", "8", true)]
	[InlineData("Hn", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.PropertyOwnershipRightsCode = "V";
		subject.TypeOfPersonalOrBusinessAssetCode = "KK";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
