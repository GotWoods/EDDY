using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G46Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G46*1*ze*4*KT*t*b*5*c*D*d*Gz2";

		var expected = new G46_PromotionAllowanceCharge()
		{
			AllowanceOrChargeCode = "1",
			AllowanceOrChargeMethodOfHandlingCode = "ze",
			AllowanceOrChargeRate = 4,
			UnitOrBasisForMeasurementCode = "KT",
			AllowanceOrChargeTotalAmount = "t",
			AllowanceChargePercentQualifier = "b",
			AllowanceOrChargePercent = 5,
			ExceptionNumber = "c",
			OptionNumber = "D",
			FreeFormMessage = "d",
			PriceIdentifierCode = "Gz2",
		};

		var actual = Map.MapObject<G46_PromotionAllowanceCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredAllowanceOrChargeCode(string allowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeMethodOfHandlingCode = "ze";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 4;
			subject.UnitOrBasisForMeasurementCode = "KT";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "b";
			subject.AllowanceOrChargePercent = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ze", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "1";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 4;
			subject.UnitOrBasisForMeasurementCode = "KT";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "b";
			subject.AllowanceOrChargePercent = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "KT", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "KT", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeRate(decimal allowanceOrChargeRate, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "1";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ze";
		if (allowanceOrChargeRate > 0)
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "b";
			subject.AllowanceOrChargePercent = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("b", 5, true)]
	[InlineData("b", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal allowanceOrChargePercent, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "1";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ze";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (allowanceOrChargePercent > 0)
			subject.AllowanceOrChargePercent = allowanceOrChargePercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 4;
			subject.UnitOrBasisForMeasurementCode = "KT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
