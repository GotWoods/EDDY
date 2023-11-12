using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCT*h*qKo*7*b*1*1*7*9*6*u*2*H";

		var expected = new LCT_LogisticsContainerTrackingInformation()
		{
			ReferenceIdentification = "h",
			PackagingFormCode = "qKo",
			Description = "7",
			WeightUnitCode = "b",
			UnitWeight = 1,
			MeasurementUnitQualifier = "1",
			Length = 7,
			Width = 9,
			Height = 6,
			VolumeUnitQualifier = "u",
			Volume = 2,
			PalletExchangeCode = "H",
		};

		var actual = Map.MapObject<LCT_LogisticsContainerTrackingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.PackagingFormCode = "qKo";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "b";
			subject.UnitWeight = 1;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "u";
			subject.Volume = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "1";
			subject.Length = 7;
			subject.Width = 9;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qKo", true)]
	public void Validation_RequiredPackagingFormCode(string packagingFormCode, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "h";
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "b";
			subject.UnitWeight = 1;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "u";
			subject.Volume = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "1";
			subject.Length = 7;
			subject.Width = 9;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("b", 1, true)]
	[InlineData("b", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal unitWeight, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.PackagingFormCode = "qKo";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "u";
			subject.Volume = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "1";
			subject.Length = 7;
			subject.Width = 9;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("1", 7, 9, 6, true)]
	[InlineData("1", 0, 0, 0, false)]
	[InlineData("", 7, 9, 6, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MeasurementUnitQualifier(string measurementUnitQualifier, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.PackagingFormCode = "qKo";
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
			subject.MeasurementUnitQualifier = "1";
		if (width > 0)
			subject.MeasurementUnitQualifier = "1";
		if (height > 0)
			subject.MeasurementUnitQualifier = "1";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "b";
			subject.UnitWeight = 1;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "u";
			subject.Volume = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "1", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "1", true)]
	public void Validation_ARequiresBLength(decimal length, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.PackagingFormCode = "qKo";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "b";
			subject.UnitWeight = 1;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "u";
			subject.Volume = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Width > 0 || subject.Height > 0)
		{
			subject.Width = 9;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "1", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "1", true)]
	public void Validation_ARequiresBWidth(decimal width, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.PackagingFormCode = "qKo";
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "b";
			subject.UnitWeight = 1;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "u";
			subject.Volume = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Height > 0)
		{
			subject.Length = 7;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "1", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "1", true)]
	public void Validation_ARequiresBHeight(decimal height, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.PackagingFormCode = "qKo";
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "b";
			subject.UnitWeight = 1;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "u";
			subject.Volume = 2;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0)
		{
			subject.Length = 7;
			subject.Width = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("u", 2, true)]
	[InlineData("u", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new LCT_LogisticsContainerTrackingInformation();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.PackagingFormCode = "qKo";
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.UnitWeight > 0)
		{
			subject.WeightUnitCode = "b";
			subject.UnitWeight = 1;
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || !string.IsNullOrEmpty(subject.MeasurementUnitQualifier) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.MeasurementUnitQualifier = "1";
			subject.Length = 7;
			subject.Width = 9;
			subject.Height = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
