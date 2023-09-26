using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class MIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIR*G*F*y*3*3*h*MA*6*9*2*u*P1iSyK";

		var expected = new MIR_MortgageInsuranceResponse()
		{
			MortgageInsuranceApplicationType = "G",
			UnderwritingDecisionCode = "F",
			MortgageInsuranceCertificateTypeCode = "y",
			ReferenceNumber = "3",
			Percent = 3,
			Amount = "h",
			UnitOrBasisForMeasurementCode = "MA",
			Quantity = 6,
			Percent2 = 9,
			Percent3 = 2,
			MortgageInsuranceRenewalOptionCode = "u",
			Date = "P1iSyK",
		};

		var actual = Map.MapObject<MIR_MortgageInsuranceResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.UnderwritingDecisionCode = "F";
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MA";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredUnderwritingDecisionCode(string underwritingDecisionCode, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationType = "G";
		//Test Parameters
		subject.UnderwritingDecisionCode = underwritingDecisionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "MA";
			subject.Quantity = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("MA", 6, true)]
	[InlineData("MA", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new MIR_MortgageInsuranceResponse();
		//Required fields
		subject.MortgageInsuranceApplicationType = "G";
		subject.UnderwritingDecisionCode = "F";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
