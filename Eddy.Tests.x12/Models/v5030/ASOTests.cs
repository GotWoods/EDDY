using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ASOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ASO*r*25*1i*Y*5**8*3*3*fw*9";

		var expected = new ASO_AssetOwnership()
		{
			PropertyOwnershipRightsCode = "r",
			TypeOfPersonalOrBusinessAssetCode = "25",
			TypeOfPersonalOrBusinessAssetCode2 = "1i",
			FreeFormMessageText = "Y",
			GeneralPropertyOwnershipCode = "5",
			AmountQualifyingDescription = null,
			MonetaryAmount = 8,
			PercentageAsDecimal = 3,
			Quantity = 3,
			ReferenceIdentificationQualifier = "fw",
			ReferenceIdentification = "9",
		};

		var actual = Map.MapObject<ASO_AssetOwnership>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "25";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "fw";
			subject.ReferenceIdentification = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("25", true)]
	public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.PropertyOwnershipRightsCode = "r";
		//Test Parameters
		subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "fw";
			subject.ReferenceIdentification = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fw", "9", true)]
	[InlineData("fw", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.PropertyOwnershipRightsCode = "r";
		subject.TypeOfPersonalOrBusinessAssetCode = "25";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
