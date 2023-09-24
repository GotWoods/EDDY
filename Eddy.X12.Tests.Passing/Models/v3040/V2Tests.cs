using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*l*N*2*F*4*B*7*S*2*h*4*8*D*2*0Q*9*9";

		var expected = new V2_VesselInformation()
		{
			LocationIdentifier = "l",
			ReferenceNumber = "N",
			Weight = 2,
			WeightUnitCode = "F",
			Weight2 = 4,
			WeightUnitCode2 = "B",
			Weight3 = 7,
			WeightUnitCode3 = "S",
			Weight4 = 2,
			WeightUnitCode4 = "h",
			Weight5 = 4,
			WeightUnitCode5 = "8",
			Name = "D",
			Length = 2,
			UnitOrBasisForMeasurementCode = "0Q",
			Quantity = 9,
			Quantity2 = 9,
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "F", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "F", false)]
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
			subject.WeightUnitCode2 = "B";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 7;
			subject.WeightUnitCode3 = "S";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "h";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 4;
			subject.WeightUnitCode5 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "B", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "B", false)]
	public void Validation_AllAreRequiredWeight2(decimal weight2, string weightUnitCode2, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight2 > 0)
			subject.Weight2 = weight2;
		subject.WeightUnitCode2 = weightUnitCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 2;
			subject.WeightUnitCode = "F";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 7;
			subject.WeightUnitCode3 = "S";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "h";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 4;
			subject.WeightUnitCode5 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "S", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "S", false)]
	public void Validation_AllAreRequiredWeight3(decimal weight3, string weightUnitCode3, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight3 > 0)
			subject.Weight3 = weight3;
		subject.WeightUnitCode3 = weightUnitCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 2;
			subject.WeightUnitCode = "F";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 4;
			subject.WeightUnitCode2 = "B";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "h";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 4;
			subject.WeightUnitCode5 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "h", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "h", false)]
	public void Validation_AllAreRequiredWeight4(decimal weight4, string weightUnitCode4, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight4 > 0)
			subject.Weight4 = weight4;
		subject.WeightUnitCode4 = weightUnitCode4;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 2;
			subject.WeightUnitCode = "F";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 4;
			subject.WeightUnitCode2 = "B";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 7;
			subject.WeightUnitCode3 = "S";
		}
		//If one is filled, all are required
		if(subject.Weight5 > 0 || subject.Weight5 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode5))
		{
			subject.Weight5 = 4;
			subject.WeightUnitCode5 = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "8", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "8", false)]
	public void Validation_AllAreRequiredWeight5(decimal weight5, string weightUnitCode5, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight5 > 0)
			subject.Weight5 = weight5;
		subject.WeightUnitCode5 = weightUnitCode5;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 2;
			subject.WeightUnitCode = "F";
		}
		//If one is filled, all are required
		if(subject.Weight2 > 0 || subject.Weight2 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode2))
		{
			subject.Weight2 = 4;
			subject.WeightUnitCode2 = "B";
		}
		//If one is filled, all are required
		if(subject.Weight3 > 0 || subject.Weight3 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode3))
		{
			subject.Weight3 = 7;
			subject.WeightUnitCode3 = "S";
		}
		//If one is filled, all are required
		if(subject.Weight4 > 0 || subject.Weight4 > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode4))
		{
			subject.Weight4 = 2;
			subject.WeightUnitCode4 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
