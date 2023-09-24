using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*r*d*5*V*3*N*8*4*2*6*6*B*9*9*TM*3*4";

		var expected = new V2_VesselInformation()
		{
			LocationIdentifier = "r",
			ReferenceIdentification = "d",
			Weight = 5,
			WeightUnitCode = "V",
			Weight2 = 3,
			WeightUnitCode2 = "N",
			Weight3 = 8,
			WeightUnitCode3 = "4",
			Weight4 = 2,
			WeightUnitCode4 = "6",
			Weight5 = 6,
			WeightUnitCode5 = "B",
			Name = "9",
			Length = 9,
			UnitOrBasisForMeasurementCode = "TM",
			Quantity = 3,
			Quantity2 = 4,
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "V", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "V", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 3;
			subject.WeightUnitCode2 = "N";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "4";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "6";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 6;
			subject.WeightUnitCode5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "N", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "N", false)]
	public void Validation_AllAreRequiredWeight2(decimal weight2, string weightUnitCode2, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight2 > 0)
			subject.Weight2 = weight2;
		subject.WeightUnitCode2 = weightUnitCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "V";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "4";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "6";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 6;
			subject.WeightUnitCode5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "4", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "4", false)]
	public void Validation_AllAreRequiredWeight3(decimal weight3, string weightUnitCode3, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight3 > 0)
			subject.Weight3 = weight3;
		subject.WeightUnitCode3 = weightUnitCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "V";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 3;
			subject.WeightUnitCode2 = "N";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "6";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 6;
			subject.WeightUnitCode5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "6", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "6", false)]
	public void Validation_AllAreRequiredWeight4(decimal weight4, string weightUnitCode4, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight4 > 0)
			subject.Weight4 = weight4;
		subject.WeightUnitCode4 = weightUnitCode4;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "V";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 3;
			subject.WeightUnitCode2 = "N";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "4";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 6;
			subject.WeightUnitCode5 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "B", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "B", false)]
	public void Validation_AllAreRequiredWeight5(decimal weight5, string weightUnitCode5, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight5 > 0)
			subject.Weight5 = weight5;
		subject.WeightUnitCode5 = weightUnitCode5;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "V";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 3;
			subject.WeightUnitCode2 = "N";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "4";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
