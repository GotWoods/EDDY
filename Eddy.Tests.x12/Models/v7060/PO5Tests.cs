using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class PO5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO5*2*4*by*5*b*8*g3*8*dx*5*MQ*8*ht*3*1y*t*q*2**578*sc*7*v*ak*l*6*9*9*3*8*f*1*5*O*q*H";

		var expected = new PO5_ExpandedItemPhysicalDetails()
		{
			Pack = 2,
			Size = 4,
			UnitOrBasisForMeasurementCode = "by",
			Volume = 5,
			VolumeUnitQualifier = "b",
			Length = 8,
			UnitOrBasisForMeasurementCode2 = "g3",
			Width = 8,
			UnitOrBasisForMeasurementCode3 = "dx",
			Height = 5,
			UnitOrBasisForMeasurementCode4 = "MQ",
			ItemDepth = 8,
			UnitOrBasisForMeasurementCode5 = "ht",
			InnerPack = 3,
			SurfaceLayerPositionCode = "1y",
			AssignedIdentification = "t",
			AssignedIdentification2 = "q",
			Number = 2,
			CompositeProductWeightBasis = null,
			TareWeight = 578,
			UnitOrBasisForMeasurementCode6 = "sc",
			Quantity = 7,
			PegCode = "v",
			UnitOrBasisForMeasurementCode7 = "ak",
			ReferenceIdentification = "l",
			XPeg = 6,
			YPeg = 9,
			ReferenceIdentification2 = "9",
			XPeg2 = 3,
			YPeg2 = 8,
			ReferenceIdentification3 = "f",
			XPeg3 = 1,
			YPeg3 = 5,
			UnmarkedNumberOfInnerPacks = "O",
			UnmarkedNumberOfInnerPackLayers = "q",
			UnmarkedNumberOfInnerPacksPerLayer = "H",
		};

		var actual = Map.MapObject<PO5_ExpandedItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "by", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "by", false)]
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
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "b", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "b", false)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "g3", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "g3", false)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "dx", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "dx", false)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "MQ", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "MQ", false)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "ht", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "ht", false)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "t", true)]
	[InlineData("q", "", false)]
	[InlineData("", "t", true)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(578, "sc", true)]
	[InlineData(578, "", false)]
	[InlineData(0, "sc", false)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "v", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "v", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string pegCode, bool isValidExpected)
	{
		var subject = new PO5_ExpandedItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.PegCode = pegCode;

        if (subject.PegCode != "")
            subject.YPeg = 1;

		//If one filled, all required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "ak", true)]
	[InlineData("l", "", false)]
	[InlineData("", "ak", true)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("v", 9, true)]
	[InlineData("v", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredYPeg(string pegCode, decimal yPeg, bool isValidExpected)
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "ak", true)]
	[InlineData("9", "", false)]
	[InlineData("", "ak", true)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "ak", true)]
	[InlineData("f", "", false)]
	[InlineData("", "ak", true)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		if(!string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPackLayers) || !string.IsNullOrEmpty(subject.UnmarkedNumberOfInnerPacksPerLayer))
		{
			subject.UnmarkedNumberOfInnerPackLayers = "q";
			subject.UnmarkedNumberOfInnerPacksPerLayer = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "H", true)]
	[InlineData("q", "", false)]
	[InlineData("", "H", false)]
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
			subject.Size = 4;
			subject.UnitOrBasisForMeasurementCode = "by";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 5;
			subject.VolumeUnitQualifier = "b";
		}
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Length = 8;
			subject.UnitOrBasisForMeasurementCode2 = "g3";
		}
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Width = 8;
			subject.UnitOrBasisForMeasurementCode3 = "dx";
		}
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode4))
		{
			subject.Height = 5;
			subject.UnitOrBasisForMeasurementCode4 = "MQ";
		}
		if(subject.ItemDepth > 0 || subject.ItemDepth > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode5))
		{
			subject.ItemDepth = 8;
			subject.UnitOrBasisForMeasurementCode5 = "ht";
		}
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode6))
		{
			subject.TareWeight = 578;
			subject.UnitOrBasisForMeasurementCode6 = "sc";
		}
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.PegCode))
		{
			subject.Quantity = 7;
			subject.PegCode = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
