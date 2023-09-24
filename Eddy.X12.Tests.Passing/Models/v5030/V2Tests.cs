using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*l*B*6*R*2*H*4*O*6*m*3*d*G*1*Q1*5*9";

		var expected = new V2_VesselInformation()
		{
			LocationIdentifier = "l",
			ReferenceIdentification = "B",
			Weight = 6,
			WeightUnitCode = "R",
			Weight2 = 2,
			WeightUnitCode2 = "H",
			Weight3 = 4,
			WeightUnitCode3 = "O",
			Weight4 = 6,
			WeightUnitCode4 = "m",
			Weight5 = 3,
			WeightUnitCode5 = "d",
			Name = "G",
			Length = 1,
			UnitOrBasisForMeasurementCode = "Q1",
			Quantity = 5,
			Quantity2 = 9,
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "R", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "R", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 2;
			subject.WeightUnitCode2 = "H";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 4;
			subject.WeightUnitCode3 = "O";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "m";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 3;
			subject.WeightUnitCode5 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "H", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "H", false)]
	public void Validation_AllAreRequiredWeight2(decimal weight2, string weightUnitCode2, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight2 > 0)
			subject.Weight2 = weight2;
		subject.WeightUnitCode2 = weightUnitCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 6;
			subject.WeightUnitCode = "R";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 4;
			subject.WeightUnitCode3 = "O";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "m";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 3;
			subject.WeightUnitCode5 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "O", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "O", false)]
	public void Validation_AllAreRequiredWeight3(decimal weight3, string weightUnitCode3, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight3 > 0)
			subject.Weight3 = weight3;
		subject.WeightUnitCode3 = weightUnitCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 6;
			subject.WeightUnitCode = "R";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 2;
			subject.WeightUnitCode2 = "H";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "m";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 3;
			subject.WeightUnitCode5 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "m", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "m", false)]
	public void Validation_AllAreRequiredWeight4(decimal weight4, string weightUnitCode4, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight4 > 0)
			subject.Weight4 = weight4;
		subject.WeightUnitCode4 = weightUnitCode4;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 6;
			subject.WeightUnitCode = "R";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 2;
			subject.WeightUnitCode2 = "H";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 4;
			subject.WeightUnitCode3 = "O";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 3;
			subject.WeightUnitCode5 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "d", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "d", false)]
	public void Validation_AllAreRequiredWeight5(decimal weight5, string weightUnitCode5, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight5 > 0)
			subject.Weight5 = weight5;
		subject.WeightUnitCode5 = weightUnitCode5;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 6;
			subject.WeightUnitCode = "R";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 2;
			subject.WeightUnitCode2 = "H";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 4;
			subject.WeightUnitCode3 = "O";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
