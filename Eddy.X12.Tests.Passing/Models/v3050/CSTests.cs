using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CS*w*K*m*p0*n*M*3U*kD*6*8*8*5H*2D*g8*1*nD*m*z";

		var expected = new CS_ContractSummary()
		{
			ContractNumber = "w",
			ChangeOrderSequenceNumber = "K",
			ReleaseNumber = "m",
			ReferenceNumberQualifier = "p0",
			ReferenceNumber = "n",
			PurchaseOrderNumber = "M",
			SpecialServicesCode = "3U",
			FOBPointCode = "kD",
			Percent = 6,
			Percent2 = 8,
			MonetaryAmount = 8,
			TermsTypeCode = "5H",
			SpecialServicesCode2 = "2D",
			UnitOrBasisForMeasurementCode = "g8",
			UnitPrice = 1,
			TermsTypeCode2 = "nD",
			YesNoConditionOrResponseCode = "m",
			YesNoConditionOrResponseCode2 = "z",
		};

		var actual = Map.MapObject<CS_ContractSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p0", "n", true)]
	[InlineData("p0", "", false)]
	[InlineData("", "n", false)]
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
