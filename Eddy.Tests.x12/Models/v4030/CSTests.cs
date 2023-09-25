using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*7*O*g*xH*4*r*o0*3o*8*6*2*H3*bs*ux*9*wj*6*U";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "7",
			ChangeOrderSequenceNumber = "O",
			ReleaseNumber = "g",
			ReferenceIdentificationQualifier = "xH",
			ReferenceIdentification = "4",
			PurchaseOrderNumber = "r",
			SpecialServicesCode = "o0",
			FOBPointCode = "3o",
			Percent = 8,
			Percent2 = 6,
			MonetaryAmount = 2,
			TermsTypeCode = "H3",
			SpecialServicesCode2 = "bs",
			UnitOrBasisForMeasurementCode = "ux",
			UnitPrice = 9,
			TermsTypeCode2 = "wj",
			YesNoConditionOrResponseCode = "6",
			YesNoConditionOrResponseCode2 = "U",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xH", "4", true)]
	[InlineData("xH", "", false)]
	[InlineData("", "4", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CS_ContractSummary();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
