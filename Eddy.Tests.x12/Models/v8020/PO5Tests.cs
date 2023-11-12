using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class PO5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO5*4*1*59*2*Z*1*g6*8*dR*8*YU*5*dM*2*1M*1*R*4**237*Tt*4*4*yv*2*7*9*U*3*6*I*8*9*5*d*5";

		var expected = new PO5_ExpandedItemPhysicalDetails()
		{
			Pack = 4,
			Size = 1,
			UnitOrBasisForMeasurementCode = "59",
			Volume = 2,
			VolumeUnitQualifier = "Z",
			Length = 1,
			UnitOrBasisForMeasurementCode2 = "g6",
			Width = 8,
			UnitOrBasisForMeasurementCode3 = "dR",
			Height = 8,
			UnitOrBasisForMeasurementCode4 = "YU",
			ItemDepth = 5,
			UnitOrBasisForMeasurementCode5 = "dM",
			InnerPack = 2,
			SurfaceLayerPositionCode = "1M",
			AssignedIdentification = "1",
			AssignedIdentification2 = "R",
			Number = 4,
			CompositeProductWeightBasis = null,
			TareWeight = 237,
			UnitOrBasisForMeasurementCode6 = "Tt",
			Quantity = 4,
			PegCode = "4",
			UnitOrBasisForMeasurementCode7 = "yv",
			ReferenceIdentification = "2",
			XPeg = 7,
			YPeg = 9,
			ReferenceIdentification2 = "U",
			XPeg2 = 3,
			YPeg2 = 6,
			ReferenceIdentification3 = "I",
			XPeg3 = 8,
			YPeg3 = 9,
			UnmarkedNumberOfInnerPacks = "5",
			UnmarkedNumberOfInnerPackLayers = "d",
			UnmarkedNumberOfInnerPacksPerLayer = "5",
		};

		var actual = Map.MapObject<PO5_ExpandedItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "59", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "59", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (size > 0) 
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Z", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Z", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "g6", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "g6", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 5, false)]
	[InlineData(1, 0, true)]
	[InlineData(0, 5, true)]
	public void Validation_OnlyOneOfLength(decimal length, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;

        if (subject.Length > 0)
            subject.UnitOrBasisForMeasurementCode2 = "AB";


        //If one filled, all required
        if (subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "dR", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "dR", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "YU", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "YU", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "dM", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "dM", false)]
	public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode5, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (itemDepth > 0) 
			subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "1", true)]
	[InlineData("R", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBAssignedIdentification2(string assignedIdentification2, string assignedIdentification, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification2 = assignedIdentification2;
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(237, "Tt", true)]
	[InlineData(237, "", false)]
	[InlineData(0, "Tt", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string unitOrBasisForMeasurementCode6, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (tareWeight > 0) 
			subject.TareWeight = tareWeight;
		subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "4", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "4", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string pegCode, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.PegCode = pegCode;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4", 9, true)]
	[InlineData("4", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredPegCode(string pegCode, decimal yPeg, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.PegCode = pegCode;
		if (yPeg > 0) 
			subject.YPeg = yPeg;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "yv", true)]
	[InlineData("2", "", false)]
	[InlineData("", "yv", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string unitOrBasisForMeasurementCode7, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.UnitOrBasisForMeasurementCode7 = unitOrBasisForMeasurementCode7;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "yv", true)]
	[InlineData("U", "", false)]
	[InlineData("", "yv", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string unitOrBasisForMeasurementCode7, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.UnitOrBasisForMeasurementCode7 = unitOrBasisForMeasurementCode7;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "yv", true)]
	[InlineData("I", "", false)]
	[InlineData("", "yv", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string unitOrBasisForMeasurementCode7, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.UnitOrBasisForMeasurementCode7 = unitOrBasisForMeasurementCode7;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "d";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "5", true)]
	[InlineData("d", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredUnmarkedNumberOfInnerPackLayers(string unmarkedNumberOfInnerPackLayers, string unmarkedNumberOfInnerPacksPerLayer, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.UnmarkedNumberOfInnerPackLayers = unmarkedNumberOfInnerPackLayers;
		subject.UnmarkedNumberOfInnerPacksPerLayer = unmarkedNumberOfInnerPacksPerLayer;
		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 1;
			subject.UnitOrBasisForMeasurementCode = "59";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 2;
			subject.VolumeUnitQualifier = "Z";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 1;
			subject.UnitOrBasisForMeasurementCode2 = "g6";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dR";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 8;
			subject.UnitOrBasisForMeasurementCode4 = "YU";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 5;
			subject.UnitOrBasisForMeasurementCode5 = "dM";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 237;
			subject.UnitOrBasisForMeasurementCode6 = "Tt";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 4;
			subject.PegCode = "4";
		}
		if(!string.IsNullOrEmpty(subject.PegCode) || !string.IsNullOrEmpty(subject.PegCode) || subject.YPeg > 0)
		{
			subject.PegCode = "4";
			subject.YPeg = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
