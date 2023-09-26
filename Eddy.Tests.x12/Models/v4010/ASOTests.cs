using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ASOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ASO*H*Y5*j0*E*2**8*4*1*Sa*1";

		var expected = new ASO_AssetOwnership()
		{
			PropertyOwnershipRightsCode = "H",
			TypeOfPersonalOrBusinessAssetCode = "Y5",
			TypeOfPersonalOrBusinessAssetCode2 = "j0",
			FreeFormMessageText = "E",
			GeneralPropertyOwnershipCode = "2",
			AmountQualifyingDescription = null,
			MonetaryAmount = 8,
			Percent = 4,
			Quantity = 1,
			ReferenceIdentificationQualifier = "Sa",
			ReferenceIdentification = "1",
		};

		var actual = Map.MapObject<ASO_AssetOwnership>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "Y5";
		//Test Parameters
		subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Sa";
			subject.ReferenceIdentification = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y5", true)]
	public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.PropertyOwnershipRightsCode = "H";
		//Test Parameters
		subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Sa";
			subject.ReferenceIdentification = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sa", "1", true)]
	[InlineData("Sa", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new ASO_AssetOwnership();
		//Required fields
		subject.PropertyOwnershipRightsCode = "H";
		subject.TypeOfPersonalOrBusinessAssetCode = "Y5";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
