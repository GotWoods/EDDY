using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models
{
	[Segment("SDQ")]
	public class SDQ_DestinationQuantity : EdiX12Segment
	{
		[Position(01)]
		public string UnitOrBasisForMeasurementCode { get; set; }

		[Position(02)]
		public string IdentificationCodeQualifier { get; set; }

		[Position(03)]
		public string IdentificationCode { get; set; }

		[Position(04)]
		public decimal? Quantity { get; set; }

		[Position(05)]
		public string IdentificationCode2 { get; set; }

		[Position(06)]
		public decimal? Quantity2 { get; set; }

		[Position(07)]
		public string IdentificationCode3 { get; set; }

		[Position(08)]
		public decimal? Quantity3 { get; set; }

		[Position(09)]
		public string IdentificationCode4 { get; set; }

		[Position(10)]
		public decimal? Quantity4 { get; set; }

		[Position(11)]
		public string IdentificationCode5 { get; set; }

		[Position(12)]
		public decimal? Quantity5 { get; set; }

		[Position(13)]
		public string IdentificationCode6 { get; set; }

		[Position(14)]
		public decimal? Quantity6 { get; set; }

		[Position(15)]
		public string IdentificationCode7 { get; set; }

		[Position(16)]
		public decimal? Quantity7 { get; set; }

		[Position(17)]
		public string IdentificationCode8 { get; set; }

		[Position(18)]
		public decimal? Quantity8 { get; set; }

		[Position(19)]
		public string IdentificationCode9 { get; set; }

		[Position(20)]
		public decimal? Quantity9 { get; set; }

		[Position(21)]
		public string IdentificationCode10 { get; set; }

		[Position(22)]
		public decimal? Quantity10 { get; set; }

		[Position(23)]
		public string LocationIdentifier { get; set; }

		public override ValidationResult Validate()
		{
			var validator = new BasicValidator<SDQ_DestinationQuantity>(this);
			validator.Required(x => x.UnitOrBasisForMeasurementCode);
			validator.Required(x => x.IdentificationCode);
			validator.Required(x => x.Quantity);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode2, x => x.Quantity2);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode3, x => x.Quantity3);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode4, x => x.Quantity4);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode5, x => x.Quantity5);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode6, x => x.Quantity6);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode7, x => x.Quantity7);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode8, x => x.Quantity8);
			validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode9, x => x.Quantity9);
            validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCode10, x => x.Quantity10);

			validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
			validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
			validator.Length(x => x.IdentificationCode, 2, 80);
			validator.Length(x => x.Quantity, 1, 15);
			validator.Length(x => x.IdentificationCode2, 2, 80);
			validator.Length(x => x.Quantity2, 1, 15);
			validator.Length(x => x.IdentificationCode3, 2, 80);
			validator.Length(x => x.Quantity3, 1, 15);
			validator.Length(x => x.IdentificationCode4, 2, 80);
			validator.Length(x => x.Quantity4, 1, 15);
			validator.Length(x => x.IdentificationCode5, 2, 80);
			validator.Length(x => x.Quantity5, 1, 15);
			validator.Length(x => x.IdentificationCode6, 2, 80);
			validator.Length(x => x.Quantity6, 1, 15);
			validator.Length(x => x.IdentificationCode7, 2, 80);
			validator.Length(x => x.Quantity7, 1, 15);
			validator.Length(x => x.IdentificationCode8, 2, 80);
			validator.Length(x => x.Quantity8, 1, 15);
			validator.Length(x => x.IdentificationCode9, 2, 80);
			validator.Length(x => x.Quantity9, 1, 15);
			validator.Length(x => x.IdentificationCode10, 2, 80);
			validator.Length(x => x.Quantity10, 1, 15);
			validator.Length(x => x.LocationIdentifier, 1, 30);
			return validator.Results;
		}
	}

}