using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*b*B*y*GU*e*N*NE*nu*9*3*8*Cf*Gd*xc*1*bt*1*C";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "b",
			ChangeOrderSequenceNumber = "B",
			ReleaseNumber = "y",
			ReferenceNumberQualifier = "GU",
			ReferenceNumber = "e",
			PurchaseOrderNumber = "N",
			SpecialServicesCode = "NE",
			FOBPointCode = "nu",
			Percent = 9,
			Percent2 = 3,
			MonetaryAmount = 8,
			TermsTypeCode = "Cf",
			SpecialServicesCode2 = "Gd",
			UnitOrBasisForMeasurementCode = "xc",
			UnitPrice = 1,
			TermsTypeCode2 = "bt",
			YesNoConditionOrResponseCode = "1",
			YesNoConditionOrResponseCode2 = "C",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GU", "e", true)]
	[InlineData("GU", "", false)]
	[InlineData("", "e", false)]
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
