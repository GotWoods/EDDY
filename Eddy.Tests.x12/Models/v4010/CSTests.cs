using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*c*c*d*X6*d*h*QJ*lI*9*4*6*cl*ve*0k*4*3t*7*5";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "c",
			ChangeOrderSequenceNumber = "c",
			ReleaseNumber = "d",
			ReferenceIdentificationQualifier = "X6",
			ReferenceIdentification = "d",
			PurchaseOrderNumber = "h",
			SpecialServicesCode = "QJ",
			FOBPointCode = "lI",
			Percent = 9,
			Percent2 = 4,
			MonetaryAmount = 6,
			TermsTypeCode = "cl",
			SpecialServicesCode2 = "ve",
			UnitOrBasisForMeasurementCode = "0k",
			UnitPrice = 4,
			TermsTypeCode2 = "3t",
			YesNoConditionOrResponseCode = "7",
			YesNoConditionOrResponseCode2 = "5",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X6", "d", true)]
	[InlineData("X6", "", false)]
	[InlineData("", "d", false)]
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
