using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._214;

public class L1000 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(4)] public List<Q7_LadingExceptionStatus> LadingExceptionStatus { get; set; } = new();
	[SectionPosition(5)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(6)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(7)] public List<AT8_ShipmentWeightPackagingAndQuantityData> ShipmentWeightPackagingAndQuantityData { get; set; } = new();
	[SectionPosition(8)] public List<L1000_L1100> L1100 {get;set;} = new();
	[SectionPosition(9)] public List<L1000_L1200> L1200 {get;set;} = new();
	[SectionPosition(10)] public List<L1000_L1300> L1300 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 999);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 9999);
		validator.CollectionSize(x => x.LadingExceptionStatus, 0, 10);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 10);
		validator.CollectionSize(x => x.ShipmentWeightPackagingAndQuantityData, 0, 10);
		validator.CollectionSize(x => x.L1100, 1, 10);
		validator.CollectionSize(x => x.L1200, 0, 5);
		validator.CollectionSize(x => x.L1300, 0, 999999);
		foreach (var item in L1100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1300) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
