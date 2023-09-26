using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class PO7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO7*wab**3*aK*3*yn*1*Tv*1*Wh*H";

		var expected = new PO7_GiftContainerPhysicalDetails()
		{
			PackagingCode = "wab",
			CompositeProductWeightBasis = null,
			Length = 3,
			UnitOrBasisForMeasurementCode = "aK",
			Width = 3,
			UnitOrBasisForMeasurementCode2 = "yn",
			Height = 1,
			UnitOrBasisForMeasurementCode3 = "Tv",
			ItemDepth = 1,
			UnitOrBasisForMeasurementCode4 = "Wh",
			Description = "H",
		};

		var actual = Map.MapObject<PO7_GiftContainerPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "aK", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "aK", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOrBasisForMeasurementCode2 = "yn";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Tv";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.ItemDepth = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Wh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(3, 1, false)]
	[InlineData(3, 0, true)]
	[InlineData(0, 1, true)]
	public void Validation_OnlyOneOfLength(decimal length, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
        //If one filled, all required

        if (subject.Length > 0)
            subject.UnitOrBasisForMeasurementCode = "AB";


        if (subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOrBasisForMeasurementCode2 = "yn";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Tv";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.ItemDepth = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Wh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "yn", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "yn", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Length = 3;
			subject.UnitOrBasisForMeasurementCode = "aK";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Tv";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.ItemDepth = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Wh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Tv", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Tv", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Length = 3;
			subject.UnitOrBasisForMeasurementCode = "aK";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOrBasisForMeasurementCode2 = "yn";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.ItemDepth = 1;
			subject.UnitOrBasisForMeasurementCode4 = "Wh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Wh", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Wh", false)]
	public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		//Required fields
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Length = 3;
			subject.UnitOrBasisForMeasurementCode = "aK";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOrBasisForMeasurementCode2 = "yn";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Height = 1;
			subject.UnitOrBasisForMeasurementCode3 = "Tv";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
