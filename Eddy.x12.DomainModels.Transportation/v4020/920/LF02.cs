using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._920;

public class LF02 {
	[SectionPosition(1)] public F02_IdentificationOfShipment IdentificationOfShipment { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(4)] public F05_AllowanceChargeClaim? AllowanceChargeClaim { get; set; }
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	[SectionPosition(7)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(8)] public List<LF02_LF09> LF09 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LF02>(this);
		validator.Required(x => x.IdentificationOfShipment);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 99);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		validator.CollectionSize(x => x.DateTime, 0, 30);
		validator.CollectionSize(x => x.LadingExceptionCode, 0, 10);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.LF09, 0, 100);
		foreach (var item in LF09) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
