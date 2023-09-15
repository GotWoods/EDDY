using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G46Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G46*b*Eq*3*P2*v*c*7*2*j*w";

		var expected = new G46_PromotionAllowanceCharge()
		{
			AllowanceOrChargeCode = "b",
			AllowanceOrChargeMethodOfHandlingCode = "Eq",
			AllowanceOrChargeRate = 3,
			UnitOrBasisForMeasurementCode = "P2",
			AllowanceOrChargeTotalAmount = "v",
			AllowanceChargePercentQualifier = "c",
			AllowanceOrChargePercent = 7,
			ExceptionNumber = "2",
			OptionNumber = "j",
			FreeFormMessage = "w",
		};

		var actual = Map.MapObject<G46_PromotionAllowanceCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "Eq";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 3;
			subject.UnitOrBasisForMeasurementCode = "P2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "c";
			subject.AllowanceOrChargePercent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Eq", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 3;
			subject.UnitOrBasisForMeasurementCode = "P2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "c";
			subject.AllowanceOrChargePercent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "P2", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "P2", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeRate(decimal allowanceOrChargeRate, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "Eq";
		if (allowanceOrChargeRate > 0)
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "c";
			subject.AllowanceOrChargePercent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("c", 7, true)]
	[InlineData("c", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal allowanceOrChargePercent, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "Eq";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (allowanceOrChargePercent > 0)
			subject.AllowanceOrChargePercent = allowanceOrChargePercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 3;
			subject.UnitOrBasisForMeasurementCode = "P2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
