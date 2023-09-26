using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class MIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIR*v*e*5*U*4*N*s0*9*7*3*T*dc86D8";

		var expected = new MIR_MortgageInsuranceResponse()
		{
			MortgageInsuranceApplicationType = "v",
			UnderwritingDecisionCode = "e",
			MortgageInsuranceCertificateTypeCode = "5",
			ReferenceNumber = "U",
			Percent = 4,
			Amount = "N",
			UnitOrBasisForMeasurementCode = "s0",
			Quantity = 9,
			Percent2 = 7,
			Percent3 = 3,
			MortgageInsuranceRenewalOptionCode = "T",
			Date = "dc86D8",
		};

		var actual = Map.MapObject<MIR_MortgageInsuranceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.UnderwritingDecisionCode = "e";
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "s0";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredUnderwritingDecisionCode(string underwritingDecisionCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationType = "v";
		//Test Parameters
		subject.UnderwritingDecisionCode = underwritingDecisionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "s0";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("s0", 9, true)]
	[InlineData("s0", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationType = "v";
		subject.UnderwritingDecisionCode = "e";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
