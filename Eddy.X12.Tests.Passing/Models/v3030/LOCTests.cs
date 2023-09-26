using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOC*MG*B*s*3*m*69*z*e*k*7*XN*3*OS*6*Pt*9*Uz*1*O7*2*Wf*OE*j*Q";

		var expected = new LOC_Location()
		{
			ReferenceNumberQualifier = "MG",
			ReferenceNumber = "B",
			Description = "s",
			ReferenceNumber2 = "3",
			Category = "m",
			ReferenceNumberQualifier2 = "69",
			ReferenceNumber3 = "z",
			Description2 = "e",
			ReferenceNumber4 = "k",
			MeasurementValue = 7,
			UnitOrBasisForMeasurementCode = "XN",
			MeasurementValue2 = 3,
			UnitOrBasisForMeasurementCode2 = "OS",
			MeasurementValue3 = 6,
			UnitOrBasisForMeasurementCode3 = "Pt",
			MeasurementValue4 = 9,
			UnitOrBasisForMeasurementCode4 = "Uz",
			MeasurementValue5 = 1,
			UnitOrBasisForMeasurementCode5 = "O7",
			MeasurementValue6 = 2,
			UnitOrBasisForMeasurementCode6 = "Wf",
			ReferenceNumberQualifier3 = "OE",
			ReferenceNumber5 = "j",
			Description3 = "Q",
		};

		var actual = Map.MapObject<LOC_Location>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MG", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("69", "z", true)]
	[InlineData("69", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredReferenceNumber3(string referenceNumberQualifier2, string referenceNumber3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber3 = referenceNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("XN", 7, true)]
	[InlineData("XN", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal measurementValue, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("OS", 3, true)]
	[InlineData("OS", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal measurementValue2, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (measurementValue2 > 0) 
			subject.MeasurementValue2 = measurementValue2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Pt", 6, true)]
	[InlineData("Pt", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode3(string unitOrBasisForMeasurementCode3, decimal measurementValue3, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		if (measurementValue3 > 0) 
			subject.MeasurementValue3 = measurementValue3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Uz", 9, true)]
	[InlineData("Uz", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal measurementValue4, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (measurementValue4 > 0) 
			subject.MeasurementValue4 = measurementValue4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O7", 1, true)]
	[InlineData("O7", 0, false)]
	[InlineData("", 1, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode5(string unitOrBasisForMeasurementCode5, decimal measurementValue5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		if (measurementValue5 > 0) 
			subject.MeasurementValue5 = measurementValue5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Wf", 2, true)]
	[InlineData("Wf", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode6(string unitOrBasisForMeasurementCode6, decimal measurementValue6, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
		if (measurementValue6 > 0) 
			subject.MeasurementValue6 = measurementValue6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber5))
		{
			subject.ReferenceNumberQualifier3 = "OE";
			subject.ReferenceNumber5 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OE", "j", true)]
	[InlineData("OE", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier3(string referenceNumberQualifier3, string referenceNumber5, bool isValidExpected)
	{
		var subject = new LOC_Location();
		//Required fields
		subject.ReferenceNumberQualifier = "MG";
		subject.ReferenceNumber = "B";
		//Test Parameters
		subject.ReferenceNumberQualifier3 = referenceNumberQualifier3;
		subject.ReferenceNumber5 = referenceNumber5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
