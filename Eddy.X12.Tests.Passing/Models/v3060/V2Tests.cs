using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*N*p*6*K*1*y*5*7*6*V*1*Z*l*9*uG*8*8";

		var expected = new V2_VesselInformation()
		{
			LocationIdentifier = "N",
			ReferenceIdentification = "p",
			Weight = 6,
			WeightUnitCode = "K",
			Weight2 = 1,
			WeightUnitCode2 = "y",
			Weight3 = 5,
			WeightUnitCode3 = "7",
			Weight4 = 6,
			WeightUnitCode4 = "V",
			Weight5 = 1,
			WeightUnitCode5 = "Z",
			Name = "l",
			Length = 9,
			UnitOrBasisForMeasurementCode = "uG",
			Quantity = 8,
			Quantity2 = 8,
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "K", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "K", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight > 0)
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 1;
			subject.WeightUnitCode2 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 5;
			subject.WeightUnitCode3 = "7";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "V";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 1;
			subject.WeightUnitCode5 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "y", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "y", false)]
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
			subject.WeightUnitCode = "K";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 5;
			subject.WeightUnitCode3 = "7";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "V";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 1;
			subject.WeightUnitCode5 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "7", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "7", false)]
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
			subject.WeightUnitCode = "K";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 1;
			subject.WeightUnitCode2 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "V";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 1;
			subject.WeightUnitCode5 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "V", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "V", false)]
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
			subject.WeightUnitCode = "K";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 1;
			subject.WeightUnitCode2 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 5;
			subject.WeightUnitCode3 = "7";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 1;
			subject.WeightUnitCode5 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Z", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Z", false)]
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
			subject.WeightUnitCode = "K";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 1;
			subject.WeightUnitCode2 = "y";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 5;
			subject.WeightUnitCode3 = "7";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 6;
			subject.WeightUnitCode4 = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
