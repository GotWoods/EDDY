using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*s*o*8*eU*x*p*po*TT*2*1*9*WY*RU*3p*9*po*n*M";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "s",
			ChangeOrderSequenceNumber = "o",
			ReleaseNumber = "8",
			ReferenceIdentificationQualifier = "eU",
			ReferenceIdentification = "x",
			PurchaseOrderNumber = "p",
			SpecialServicesCode = "po",
			FOBPointCode = "TT",
			Percent = 2,
			Percent2 = 1,
			MonetaryAmount = 9,
			TermsTypeCode = "WY",
			SpecialServicesCode2 = "RU",
			UnitOrBasisForMeasurementCode = "3p",
			UnitPrice = 9,
			TermsTypeCode2 = "po",
			YesNoConditionOrResponseCode = "n",
			YesNoConditionOrResponseCode2 = "M",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eU", "x", true)]
	[InlineData("eU", "", false)]
	[InlineData("", "x", false)]
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
