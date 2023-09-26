using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*m*H*U*Ta*w*2*Ce*De*9*6*5*mX*Uz*dM*3*wY*L*e";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "m",
			ChangeOrderSequenceNumber = "H",
			ReleaseNumber = "U",
			ReferenceIdentificationQualifier = "Ta",
			ReferenceIdentification = "w",
			PurchaseOrderNumber = "2",
			SpecialServicesCode = "Ce",
			FOBPointCode = "De",
			PercentageAsDecimal = 9,
			PercentageAsDecimal2 = 6,
			MonetaryAmount = 5,
			TermsTypeCode = "mX",
			SpecialServicesCode2 = "Uz",
			UnitOrBasisForMeasurementCode = "dM",
			UnitPrice = 3,
			TermsTypeCode2 = "wY",
			YesNoConditionOrResponseCode = "L",
			YesNoConditionOrResponseCode2 = "e",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ta", "w", true)]
	[InlineData("Ta", "", false)]
	[InlineData("", "w", false)]
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
