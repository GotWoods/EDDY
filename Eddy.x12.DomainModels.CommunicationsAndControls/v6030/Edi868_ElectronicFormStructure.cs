using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;
using Eddy.x12.DomainModels.CommunicationsAndControls.v6030._868;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v6030;

public class Edi868_ElectronicFormStructure {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public E01_ElectronicFormMainHeading ElectronicFormMainHeading { get; set; } = new();
	[SectionPosition(3)] public List<DMI_DataMaintenanceInformation> DataMaintenanceInformation { get; set; } = new();
	[SectionPosition(4)] public List<E03_InterchangeOrderOfSegments> InterchangeOrderOfSegments { get; set; } = new();
	[SectionPosition(5)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(6)] public List<LE10> LE10 {get;set;} = new();
	[SectionPosition(7)] public List<LE20> LE20 {get;set;} = new();
	[SectionPosition(8)] public List<LE41> LE41 {get;set;} = new();
	[SectionPosition(9)] public List<LE30> LE30 {get;set;} = new();
	[SectionPosition(10)] public List<LE40> LE40 {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi868_ElectronicFormStructure>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ElectronicFormMainHeading);
		validator.CollectionSize(x => x.DataMaintenanceInformation, 0, 100);
		validator.CollectionSize(x => x.InterchangeOrderOfSegments, 0, 100);
		validator.CollectionSize(x => x.MessageText, 0, 1000);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LE10, 0, 1000);
		validator.CollectionSize(x => x.LE20, 0, 1000);
		validator.CollectionSize(x => x.LE41, 0, 2000);
		validator.CollectionSize(x => x.LE30, 0, 2000);
		validator.CollectionSize(x => x.LE40, 0, 10000);
		foreach (var item in LE10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE41) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE30) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LE40) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
