using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;
using Eddy.x12.DomainModels.Transportation.v8020._437;

namespace Eddy.x12.DomainModels.Transportation.v8020;

public class Edi437_RailroadJunctionsAndInterchangesActivity {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BJF_BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public JCT_RailroadJunctionInformation? RailroadJunctionInformation { get; set; }
	[SectionPosition(5)] public List<LJS> LJS {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi437_RailroadJunctionsAndInterchangesActivity>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentRailroadJunctionsAndInterchangesUpdateActivity);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LJS, 0, 2);
		foreach (var item in LJS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
