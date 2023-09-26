using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOC*eb*1*L*k*Z*X1*x*Z*h*7*AY*3*Ig*1*MM*2*WI*6*5F*8*TE*df*n*Z";

		var expected = new LOC_Location()
		{
			ReferenceNumberQualifier = "eb",
			ReferenceNumber = "1",
			Description = "L",
			ReferenceNumber2 = "k",
			Category = "Z",
			ReferenceNumberQualifier2 = "X1",
			ReferenceNumber3 = "x",
			Description2 = "Z",
			ReferenceNumber4 = "h",
			MeasurementValue = 7,
			UnitOrBasisForMeasurementCode = "AY",
			MeasurementValue2 = 3,
			UnitOrBasisForMeasurementCode2 = "Ig",
			MeasurementValue3 = 1,
			UnitOrBasisForMeasurementCode3 = "MM",
			MeasurementValue4 = 2,
			UnitOrBasisForMeasurementCode4 = "WI",
			MeasurementValue5 = 6,
			UnitOrBasisForMeasurementCode5 = "5F",
			MeasurementValue6 = 8,
			UnitOrBasisForMeasurementCode6 = "TE",
			ReferenceNumberQualifier3 = "df",
			ReferenceNumber5 = "n",
			Description3 = "Z",
		};

		var actual = Map.MapObject<LOC_Location>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eb", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X1", "x", true)]
	[InlineData("X1", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber3 = referenceNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("AY", 7, true)]
	[InlineData("AY", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ig", 3, true)]
	[InlineData("Ig", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal measurementValue2, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (measurementValue2 > 0) 
			subject.MeasurementValue2 = measurementValue2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("MM", 1, true)]
	[InlineData("MM", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal measurementValue3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (measurementValue3 > 0) 
			subject.MeasurementValue3 = measurementValue3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("WI", 2, true)]
	[InlineData("WI", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal measurementValue4, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (measurementValue4 > 0) 
			subject.MeasurementValue4 = measurementValue4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5F", 6, true)]
	[InlineData("5F", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal measurementValue5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (measurementValue5 > 0) 
			subject.MeasurementValue5 = measurementValue5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("TE", 8, true)]
	[InlineData("TE", 0, false)]
	[InlineData("", 8, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode6(string unitOrBasisForMeasurementCode6, decimal measurementValue6, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
		if (measurementValue6 > 0) 
			subject.MeasurementValue6 = measurementValue6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "df";
			subject.ReferenceNumber5 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("df", "n", true)]
	[InlineData("df", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier3(string referenceNumberQualifier3, string referenceNumber5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "eb";
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.ReferenceNumberQualifier3 = referenceNumberQualifier3;
		subject.ReferenceNumber5 = referenceNumber5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier2 = "X1";
			subject.ReferenceNumber3 = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
