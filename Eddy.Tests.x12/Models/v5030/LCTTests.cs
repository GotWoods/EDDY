using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCT*L*XBW*Y*2*8*m*7*3*3*F*6*e";

		var expected = new LCT_LogisticsContainerTrackingInformation()
		{
			ReferenceIdentification = "L",
			PackagingFormCode = "XBW",
			Description = "Y",
			WeightUnitCode = "2",
			UnitWeight = 8,
			MeasurementUnitQualifier = "m",
			Length = 7,
			Width = 3,
			Height = 3,
			VolumeUnitQualifier = "F",
			Volume = 6,
			PalletExchangeCode = "e",
		};

		var actual = Map.MapObject<LCT_LogisticsContainerTrackingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.PackagingFormCode = "XBW";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "2";
			subject.UnitWeight = 8;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "F";
			subject.Volume = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "m";
			subject.Length = 7;
			subject.Width = 3;
			subject.Height = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XBW", true)]
	public void Validation_RequiredPackagingFormCode(string packagingFormCode, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "L";
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "2";
			subject.UnitWeight = 8;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "F";
			subject.Volume = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "m";
			subject.Length = 7;
			subject.Width = 3;
			subject.Height = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 8, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal unitWeight, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "L";
		subject.PackagingFormCode = "XBW";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "F";
			subject.Volume = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "m";
			subject.Length = 7;
			subject.Width = 3;
			subject.Height = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("m", 7, 3, 3, true)]
	[InlineData("m", 0, 0, 0, false)]
	[InlineData("", 7, 3, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MeasurementUnitQualifier(string measurementUnitQualifier, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "L";
		subject.PackagingFormCode = "XBW";
		//Test Parameters
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		if (length > 0) 
			subject.Length = length;
		if (width > 0) 
			subject.Width = width;
		if (height > 0) 
			subject.Height = height;
		//A Requires B
		if (length > 0)
			subject.MeasurementUnitQualifier = "m";
		if (width > 0)
			subject.MeasurementUnitQualifier = "m";
		if (height > 0)
			subject.MeasurementUnitQualifier = "m";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "2";
			subject.UnitWeight = 8;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "F";
			subject.Volume = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "m", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "m", true)]
	public void Validation_ARequiresBLength(decimal length, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "L";
		subject.PackagingFormCode = "XBW";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "2";
			subject.UnitWeight = 8;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "F";
			subject.Volume = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 3;
			subject.Height = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "m", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "m", true)]
	public void Validation_ARequiresBWidth(decimal width, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "L";
		subject.PackagingFormCode = "XBW";
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "2";
			subject.UnitWeight = 8;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "F";
			subject.Volume = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 7;
			subject.Height = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "m", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "m", true)]
	public void Validation_ARequiresBHeight(decimal height, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "L";
		subject.PackagingFormCode = "XBW";
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "2";
			subject.UnitWeight = 8;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "F";
			subject.Volume = 6;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 7;
			subject.Width = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("F", 6, true)]
	[InlineData("F", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "L";
		subject.PackagingFormCode = "XBW";
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "2";
			subject.UnitWeight = 8;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "m";
			subject.Length = 7;
			subject.Width = 3;
			subject.Height = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
