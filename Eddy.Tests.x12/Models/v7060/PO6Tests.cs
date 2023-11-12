using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class PO6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO6**1*S2*5*UR*5*LT*5*uB";

		var expected = new PO6_NonPackagedItemPhyscialDetails()
		{
			CompositeProductWeightBasis = null,
			Length = 1,
			UnitOrBasisForMeasurementCode = "S2",
			Width = 5,
			UnitOrBasisForMeasurementCode2 = "UR",
			Height = 5,
			UnitOrBasisForMeasurementCode3 = "LT",
			ItemDepth = 5,
			UnitOrBasisForMeasurementCode4 = "uB",
		};

		var actual = Map.MapObject<PO6_NonPackagedItemPhyscialDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "S2", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "S2", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO6_NonPackagedItemPhyscialDetails();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 5;
			subject.UnitOrBasisForMeasurementCode2 = "UR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode3 = "LT";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode4 = "uB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}



	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "UR", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "UR", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO6_NonPackagedItemPhyscialDetails();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode = "S2";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode3 = "LT";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode4 = "uB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "LT", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "LT", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO6_NonPackagedItemPhyscialDetails();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode = "S2";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 5;
			subject.UnitOrBasisForMeasurementCode2 = "UR";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode4 = "uB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "uB", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "uB", false)]
	public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO6_NonPackagedItemPhyscialDetails();
		//Required fields
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode = "S2";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 5;
			subject.UnitOrBasisForMeasurementCode2 = "UR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode3 = "LT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
