using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*Q*S*2*Fj*g*7*f0*QG*2*2*6*nN*Jj*DU*1*im*I*v";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "Q",
			ChangeOrderSequenceNumber = "S",
			ReleaseNumber = "2",
			ReferenceNumberQualifier = "Fj",
			ReferenceNumber = "g",
			PurchaseOrderNumber = "7",
			SpecialServicesCode = "f0",
			FOBPointCode = "QG",
			Percent = 2,
			Percent2 = 2,
			MonetaryAmount = 6,
			TermsTypeCode = "nN",
			ReportTypeCode = "Jj",
			UnitOrBasisForMeasurementCode = "DU",
			UnitPrice = 1,
			TermsTypeCode2 = "im",
			YesNoConditionOrResponseCode = "I",
			YesNoConditionOrResponseCode2 = "v",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fj", "g", true)]
	[InlineData("Fj", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new CS_ContractSummary();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
