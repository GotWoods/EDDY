using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*g*8*d*jf*k*L*As*Ss*5*9*4*9I*Rl*YK*7*sS*0*e";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "g",
			ChangeOrderSequenceNumber = "8",
			ReleaseNumber = "d",
			ReferenceIdentificationQualifier = "jf",
			ReferenceIdentification = "k",
			PurchaseOrderNumber = "L",
			SpecialServicesCode = "As",
			FOBPointCode = "Ss",
			PercentageAsDecimal = 5,
			PercentageAsDecimal2 = 9,
			MonetaryAmount = 4,
			TermsTypeCode = "9I",
			SpecialServicesCode2 = "Rl",
			UnitOrBasisForMeasurementCode = "YK",
			UnitPrice = 7,
			TermsTypeCode2 = "sS",
			YesNoConditionOrResponseCode = "0",
			YesNoConditionOrResponseCode2 = "e",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jf", "k", true)]
	[InlineData("jf", "", false)]
	[InlineData("", "k", false)]
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
