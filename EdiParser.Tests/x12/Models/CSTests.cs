using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*Q*I*9*1r*n*7*OX*DD*7*6*5*2t*OR*Gg*9*Cx*r*L";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "Q",
			ChangeOrderSequenceNumber = "I",
			ReleaseNumber = "9",
			ReferenceIdentificationQualifier = "1r",
			ReferenceIdentification = "n",
			PurchaseOrderNumber = "7",
			SpecialServicesCode = "OX",
			FOBPointCode = "DD",
			PercentageAsDecimal = 7,
			PercentageAsDecimal2 = 6,
			MonetaryAmount = 5,
			TermsTypeCode = "2t",
			SpecialServicesCode2 = "OR",
			UnitOrBasisForMeasurementCode = "Gg",
			UnitPrice = 9,
			TermsTypeCode2 = "Cx",
			YesNoConditionOrResponseCode = "r",
			YesNoConditionOrResponseCode2 = "L",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("1r", "n", true)]
	[InlineData("", "n", false)]
	[InlineData("1r", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CS_ContractSummary();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
