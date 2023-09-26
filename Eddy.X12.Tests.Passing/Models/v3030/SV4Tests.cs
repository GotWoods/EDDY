using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*m*wI*a*D*J*m*q*j*9*6*C*M*V*6*88*j*R*q*m";

		var expected = new SV4_DrugService()
		{
			ReferenceNumber = "m",
			ProductServiceIDQualifier = "wI",
			ProductServiceID = "a",
			ReferenceNumber2 = "D",
			YesNoConditionOrResponseCode = "J",
			DispenseAsWrittenCode = "m",
			LevelOfServiceCode = "q",
			PrescriptionOriginCode = "j",
			Description = "9",
			YesNoConditionOrResponseCode2 = "6",
			YesNoConditionOrResponseCode3 = "C",
			UnitDoseCode = "M",
			BasisOfCostDeterminationCode = "V",
			BasisOfDaysSupplyDeterminationCode = "6",
			DosageFormCode = "88",
			CopayStatusCode = "j",
			PatientLocationCode = "R",
			LevelOfCareCode = "q",
			PriorAuthorizationTypeCode = "m",
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "wI";
			subject.ProductServiceID = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wI", "a", true)]
	[InlineData("wI", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		subject.ReferenceNumber = "m";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
