using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*a*B*5*U*4*J*8*y*4*K*7*b*L*8*qb*2*1";

		var expected = new V2_VesselInformation()
		{
			LocationIdentifier = "a",
			ReferenceIdentification = "B",
			Weight = 5,
			WeightUnitCode = "U",
			Weight2 = 4,
			WeightUnitCode2 = "J",
			Weight3 = 8,
			WeightUnitCode3 = "y",
			Weight4 = 4,
			WeightUnitCode4 = "K",
			Weight5 = 7,
			WeightUnitCode5 = "b",
			Name = "L",
			Length = 8,
			UnitOrBasisForMeasurementCode = "qb",
			Quantity = 2,
			Quantity2 = 1,
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "U", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "U", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 4;
			subject.WeightUnitCode2 = "J";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 4;
			subject.WeightUnitCode4 = "K";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 7;
			subject.WeightUnitCode5 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "J", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "J", false)]
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
			subject.WeightUnitCode = "U";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 4;
			subject.WeightUnitCode4 = "K";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 7;
			subject.WeightUnitCode5 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "y", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "y", false)]
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
			subject.WeightUnitCode = "U";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 4;
			subject.WeightUnitCode2 = "J";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 4;
			subject.WeightUnitCode4 = "K";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 7;
			subject.WeightUnitCode5 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "K", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "K", false)]
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
			subject.WeightUnitCode = "U";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 4;
			subject.WeightUnitCode2 = "J";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 7;
			subject.WeightUnitCode5 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "b", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "b", false)]
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
			subject.WeightUnitCode = "U";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 4;
			subject.WeightUnitCode2 = "J";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 8;
			subject.WeightUnitCode3 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 4;
			subject.WeightUnitCode4 = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
