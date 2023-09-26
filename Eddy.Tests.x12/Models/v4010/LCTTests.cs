using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCT*0*rdP*H*y*5*p*7*6*4*f*7*u";

		var expected = new LCT_LogisticsContainerTrackingInformation()
		{
			ReferenceIdentification = "0",
			PackagingFormCode = "rdP",
			Description = "H",
			WeightUnitCode = "y",
			UnitWeight = 5,
			MeasurementUnitQualifier = "p",
			Length = 7,
			Width = 6,
			Height = 4,
			VolumeUnitQualifier = "f",
			Volume = 7,
			PalletExchangeCode = "u",
		};

		var actual = Map.MapObject<LCT_LogisticsContainerTrackingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.PackagingFormCode = "rdP";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "y";
			subject.UnitWeight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "f";
			subject.Volume = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "p";
			subject.Length = 7;
			subject.Width = 6;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rdP", true)]
	public void Validation_RequiredPackagingFormCode(string packagingFormCode, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "y";
			subject.UnitWeight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "f";
			subject.Volume = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "p";
			subject.Length = 7;
			subject.Width = 6;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("y", 5, true)]
	[InlineData("y", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal unitWeight, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.PackagingFormCode = "rdP";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "f";
			subject.Volume = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "p";
			subject.Length = 7;
			subject.Width = 6;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("p", 7, 6, 4, true)]
	[InlineData("p", 0, 0, 0, false)]
	[InlineData("", 7, 6, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MeasurementUnitQualifier(string measurementUnitQualifier, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.PackagingFormCode = "rdP";
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
			subject.MeasurementUnitQualifier = "p";
		if (width > 0)
			subject.MeasurementUnitQualifier = "p";
		if (height > 0)
			subject.MeasurementUnitQualifier = "p";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "y";
			subject.UnitWeight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "f";
			subject.Volume = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "p", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "p", true)]
	public void Validation_ARequiresBLength(decimal length, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.PackagingFormCode = "rdP";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "y";
			subject.UnitWeight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "f";
			subject.Volume = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 6;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "p", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "p", true)]
	public void Validation_ARequiresBWidth(decimal width, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.PackagingFormCode = "rdP";
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "y";
			subject.UnitWeight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "f";
			subject.Volume = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 7;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "p", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "p", true)]
	public void Validation_ARequiresBHeight(decimal height, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.PackagingFormCode = "rdP";
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "y";
			subject.UnitWeight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "f";
			subject.Volume = 7;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 7;
			subject.Width = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("f", 7, true)]
	[InlineData("f", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.PackagingFormCode = "rdP";
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "y";
			subject.UnitWeight = 5;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "p";
			subject.Length = 7;
			subject.Width = 6;
			subject.Height = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
