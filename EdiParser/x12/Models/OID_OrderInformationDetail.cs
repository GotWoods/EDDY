using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models
{
	[Segment("OID")]
	public class OID_OrderInformationDetail : EdiX12Segment
	{
		[Position(01)]
		public string ReferenceIdentification { get; set; }

		[Position(02)]
		public string PurchaseOrderNumber { get; set; }

		[Position(03)]
		public string ReferenceIdentification2 { get; set; }

		[Position(04)]
		public string PackagingFormCode { get; set; }

		[Position(05)]
		public decimal? Quantity { get; set; }

		[Position(06)]
		public string WeightUnitCode { get; set; }

		[Position(07)]
		public decimal? Weight { get; set; }

		[Position(08)]
		public string VolumeUnitQualifier { get; set; }

		[Position(09)]
		public decimal? Volume { get; set; }

		[Position(10)]
		public string ApplicationErrorConditionCode { get; set; }

		[Position(11)]
		public string ReferenceIdentification3 { get; set; }

		[Position(12)]
		public string PackagingFormCode2 { get; set; }

		[Position(13)]
		public decimal? Quantity2 { get; set; }

		public override ValidationResult Validate()
		{
			var validator = new BasicValidator<OID_OrderInformationDetail>(this);
			validator.AtLeastOneIsRequired(x => x.ReferenceIdentification, x => x.PurchaseOrderNumber);
			validator.ARequiresB(x => x.ReferenceIdentification2, x => x.PurchaseOrderNumber);
			validator.IfOneIsFilled_AllAreRequired(x => x.PackagingFormCode, x => x.Quantity);
			validator.IfOneIsFilled_AllAreRequired(x => x.WeightUnitCode, x => x.Weight);
			validator.IfOneIsFilled_AllAreRequired(x => x.VolumeUnitQualifier, x => x.Volume);
			validator.IfOneIsFilled_AllAreRequired(x => x.PackagingFormCode2, x => x.Quantity2);
			validator.Length(x => x.ReferenceIdentification, 1, 80);
			validator.Length(x => x.PurchaseOrderNumber, 1, 22);
			validator.Length(x => x.ReferenceIdentification2, 1, 80);
			validator.Length(x => x.PackagingFormCode, 3);
			validator.Length(x => x.Quantity, 1, 15);
			validator.Length(x => x.WeightUnitCode, 1);
			validator.Length(x => x.Weight, 1, 10);
			validator.Length(x => x.VolumeUnitQualifier, 1);
			validator.Length(x => x.Volume, 1, 8);
			validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
			validator.Length(x => x.ReferenceIdentification3, 1, 80);
			validator.Length(x => x.PackagingFormCode2, 3);
			validator.Length(x => x.Quantity2, 1, 15);
			return validator.Results;
		}
	}
}
