using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*b*n*t*8*2*4*m*9*5*9*M*7*c*1*Rm*7*9";

		var expected = new V2_VesselInformation()
		{
			LocationIdentifier = "b",
			ReferenceNumber = "n",
			WeightUnitQualifier = "t",
			Weight = 8,
			WeightUnitQualifier2 = "2",
			Weight2 = 4,
			WeightUnitQualifier3 = "m",
			Weight3 = 9,
			WeightUnitQualifier4 = "5",
			Weight4 = 9,
			WeightUnitQualifier5 = "M",
			Weight5 = 7,
			Name = "c",
			Length = 1,
			UnitOfMeasurementCode = "Rm",
			Quantity = 7,
			Quantity2 = 9,
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("t", 8, true)]
	[InlineData("t", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier(string weightUnitQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.WeightUnitQualifier = weightUnitQualifier;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight2 > 0)
		{
			subject.WeightUnitQualifier2 = "2";
			subject.Weight2 = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier3) || !string.IsNullOrEmpty(subject.WeightUnitQualifier3) || subject.Weight3 > 0)
		{
			subject.WeightUnitQualifier3 = "m";
			subject.Weight3 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier4) || !string.IsNullOrEmpty(subject.WeightUnitQualifier4) || subject.Weight4 > 0)
		{
			subject.WeightUnitQualifier4 = "5";
			subject.Weight4 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier5) || !string.IsNullOrEmpty(subject.WeightUnitQualifier5) || subject.Weight5 > 0)
		{
			subject.WeightUnitQualifier5 = "M";
			subject.Weight5 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 4, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier2(string weightUnitQualifier2, decimal weight2, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.WeightUnitQualifier2 = weightUnitQualifier2;
		if (weight2 > 0)
			subject.Weight2 = weight2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier = "t";
			subject.Weight = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier3) || !string.IsNullOrEmpty(subject.WeightUnitQualifier3) || subject.Weight3 > 0)
		{
			subject.WeightUnitQualifier3 = "m";
			subject.Weight3 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier4) || !string.IsNullOrEmpty(subject.WeightUnitQualifier4) || subject.Weight4 > 0)
		{
			subject.WeightUnitQualifier4 = "5";
			subject.Weight4 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier5) || !string.IsNullOrEmpty(subject.WeightUnitQualifier5) || subject.Weight5 > 0)
		{
			subject.WeightUnitQualifier5 = "M";
			subject.Weight5 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("m", 9, true)]
	[InlineData("m", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier3(string weightUnitQualifier3, decimal weight3, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.WeightUnitQualifier3 = weightUnitQualifier3;
		if (weight3 > 0)
			subject.Weight3 = weight3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier = "t";
			subject.Weight = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight2 > 0)
		{
			subject.WeightUnitQualifier2 = "2";
			subject.Weight2 = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier4) || !string.IsNullOrEmpty(subject.WeightUnitQualifier4) || subject.Weight4 > 0)
		{
			subject.WeightUnitQualifier4 = "5";
			subject.Weight4 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier5) || !string.IsNullOrEmpty(subject.WeightUnitQualifier5) || subject.Weight5 > 0)
		{
			subject.WeightUnitQualifier5 = "M";
			subject.Weight5 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5", 9, true)]
	[InlineData("5", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier4(string weightUnitQualifier4, decimal weight4, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.WeightUnitQualifier4 = weightUnitQualifier4;
		if (weight4 > 0)
			subject.Weight4 = weight4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier = "t";
			subject.Weight = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight2 > 0)
		{
			subject.WeightUnitQualifier2 = "2";
			subject.Weight2 = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier3) || !string.IsNullOrEmpty(subject.WeightUnitQualifier3) || subject.Weight3 > 0)
		{
			subject.WeightUnitQualifier3 = "m";
			subject.Weight3 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier5) || !string.IsNullOrEmpty(subject.WeightUnitQualifier5) || subject.Weight5 > 0)
		{
			subject.WeightUnitQualifier5 = "M";
			subject.Weight5 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("M", 7, true)]
	[InlineData("M", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredWeightUnitQualifier5(string weightUnitQualifier5, decimal weight5, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		subject.WeightUnitQualifier5 = weightUnitQualifier5;
		if (weight5 > 0)
			subject.Weight5 = weight5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier) || subject.Weight > 0)
		{
			subject.WeightUnitQualifier = "t";
			subject.Weight = 8;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier2) || !string.IsNullOrEmpty(subject.WeightUnitQualifier2) || subject.Weight2 > 0)
		{
			subject.WeightUnitQualifier2 = "2";
			subject.Weight2 = 4;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier3) || !string.IsNullOrEmpty(subject.WeightUnitQualifier3) || subject.Weight3 > 0)
		{
			subject.WeightUnitQualifier3 = "m";
			subject.Weight3 = 9;
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightUnitQualifier4) || !string.IsNullOrEmpty(subject.WeightUnitQualifier4) || subject.Weight4 > 0)
		{
			subject.WeightUnitQualifier4 = "5";
			subject.Weight4 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
