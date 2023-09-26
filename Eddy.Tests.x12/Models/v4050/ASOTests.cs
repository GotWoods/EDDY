using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ASOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ASO*V*zX*G8*d*M**3*2*8*4V*J";

		var expected = new ASO_AssetOwnership()
		{
			PropertyOwnershipRightsCode = "V",
			TypeOfPersonalOrBusinessAssetCode = "zX",
			TypeOfPersonalOrBusinessAssetCode2 = "G8",
			FreeFormMessageText = "d",
			GeneralPropertyOwnershipCode = "M",
			AmountQualifyingDescription = null,
			MonetaryAmount = 3,
			PercentageAsDecimal = 2,
			Quantity = 8,
			ReferenceIdentificationQualifier = "4V",
			ReferenceIdentification = "J",
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
		subject.TypeOfPersonalOrBusinessAssetCode = "zX";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "4V";
			subject.ReferenceIdentification = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zX", true)]
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
			subject.ReferenceIdentificationQualifier = "4V";
			subject.ReferenceIdentification = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4V", "J", true)]
	[InlineData("4V", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.PropertyOwnershipRightsCode = "V";
		subject.TypeOfPersonalOrBusinessAssetCode = "zX";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
