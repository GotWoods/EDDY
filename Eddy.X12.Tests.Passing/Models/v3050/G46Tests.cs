using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G46Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G46*V*zU*1*V2*R*c*7*p*v*R*Kf0";

		var expected = new G46_PromotionAllowanceCharge()
		{
			AllowanceOrChargeCode = "V",
			AllowanceOrChargeMethodOfHandlingCode = "zU",
			AllowanceOrChargeRate = 1,
			UnitOrBasisForMeasurementCode = "V2",
			Amount = "R",
			AllowanceChargePercentQualifier = "c",
			Percent = 7,
			ExceptionNumber = "p",
			OptionNumber = "v",
			Description = "R",
			PriceIdentifierCode = "Kf0",
		};

		var actual = Map.MapObject<G46_PromotionAllowanceCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "zU";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 1;
			subject.UnitOrBasisForMeasurementCode = "V2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.Percent > 0)
		{
			subject.AllowanceChargePercentQualifier = "c";
			subject.Percent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zU", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "V";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 1;
			subject.UnitOrBasisForMeasurementCode = "V2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.Percent > 0)
		{
			subject.AllowanceChargePercentQualifier = "c";
			subject.Percent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "V2", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "V2", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeRate(decimal allowanceOrChargeRate, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "V";
		subject.AllowanceOrChargeMethodOfHandlingCode = "zU";
		if (allowanceOrChargeRate > 0)
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.Percent > 0)
		{
			subject.AllowanceChargePercentQualifier = "c";
			subject.Percent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("c", 7, true)]
	[InlineData("c", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "V";
		subject.AllowanceOrChargeMethodOfHandlingCode = "zU";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 1;
			subject.UnitOrBasisForMeasurementCode = "V2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
