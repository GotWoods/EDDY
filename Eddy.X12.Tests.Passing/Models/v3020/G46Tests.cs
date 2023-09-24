using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G46Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G46*b*ZK*8*ux*R*W*4*d*u*4*5";

		var expected = new G46_PromotionAllowanceCharge()
		{
			AllowanceOrChargeCode = "b",
			AllowanceOrChargeMethodOfHandlingCode = "ZK",
			AllowanceOrChargeRate = 8,
			UnitOfMeasurementCode = "ux",
			AllowanceOrChargeTotalAmount = "R",
			AllowanceChargePercentQualifier = "W",
			AllowanceOrChargePercent = 4,
			ExceptionNumber = "d",
			OptionNumber = "u",
			FreeFormMessage = "4",
			TermsDiscountDaysDue = 5,
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
		subject.AllowanceOrChargeMethodOfHandlingCode = "ZK";
		subject.AllowanceOrChargeCode = allowanceOrChargeCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 8;
			subject.UnitOfMeasurementCode = "ux";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "W";
			subject.AllowanceOrChargePercent = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZK", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 8;
			subject.UnitOfMeasurementCode = "ux";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "W";
			subject.AllowanceOrChargePercent = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "ux", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "ux", false)]
	public void Validation_AllAreRequiredAllowanceOrChargeRate(decimal allowanceOrChargeRate, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ZK";
		if (allowanceOrChargeRate > 0)
			subject.AllowanceOrChargeRate = allowanceOrChargeRate;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || !string.IsNullOrEmpty(subject.AllowanceChargePercentQualifier) || subject.AllowanceOrChargePercent > 0)
		{
			subject.AllowanceChargePercentQualifier = "W";
			subject.AllowanceOrChargePercent = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("W", 4, true)]
	[InlineData("W", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal allowanceOrChargePercent, bool isValidExpected)
	{
		var subject = new G46_PromotionAllowanceCharge();
		subject.AllowanceOrChargeCode = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ZK";
		subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
		if (allowanceOrChargePercent > 0)
			subject.AllowanceOrChargePercent = allowanceOrChargePercent;
		//If one is filled, all are required
		if(subject.AllowanceOrChargeRate > 0 || subject.AllowanceOrChargeRate > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.AllowanceOrChargeRate = 8;
			subject.UnitOfMeasurementCode = "ux";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
