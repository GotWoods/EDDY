using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G31Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G31*3*YI*5*H4*7*Tu*5*O";

		var expected = new G31_TotalInvoiceQuantity()
		{
			NumberOfUnitsShipped = 3,
			UnitOfMeasurementCode = "YI",
			Weight = 5,
			UnitOfMeasurementCode2 = "H4",
			Volume = 7,
			UnitOfMeasurementCode3 = "Tu",
			EquivalentWeight = 5,
			PriceBracketIdentifier = "O",
		};

		var actual = Map.MapObject<G31_TotalInvoiceQuantity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.UnitOfMeasurementCode = "YI";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOfMeasurementCode2 = "H4";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOfMeasurementCode3 = "Tu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YI", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 3;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOfMeasurementCode2 = "H4";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOfMeasurementCode3 = "Tu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "H4", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "H4", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 3;
		subject.UnitOfMeasurementCode = "YI";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOfMeasurementCode3 = "Tu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Tu", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Tu", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 3;
		subject.UnitOfMeasurementCode = "YI";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOfMeasurementCode2 = "H4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "H4", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "H4", true)]
	public void Validation_ARequiresBEquivalentWeight(decimal equivalentWeight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G31_TotalInvoiceQuantity();
		subject.NumberOfUnitsShipped = 3;
		subject.UnitOfMeasurementCode = "YI";
		if (equivalentWeight > 0)
			subject.EquivalentWeight = equivalentWeight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 5;
			subject.UnitOfMeasurementCode2 = "H4";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOfMeasurementCode3 = "Tu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
