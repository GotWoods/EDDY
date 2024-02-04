using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;
using Eddy.x12.DomainModels.Transportation.v8040._431;

namespace Eddy.x12.DomainModels.Transportation.v8040;

public class Edi431_RailroadStationMasterFile {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public SMB_BeginningSegmentForRailroadStationMasterFile BeginningSegmentForRailroadStationMasterFile { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public SMS_StationCodesSegment StationCodesSegment { get; set; } = new();
	[SectionPosition(7)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(8)] public List<SMR_CrossReference> CrossReference { get; set; } = new();
	[SectionPosition(9)] public List<SMO_OperationalServices> OperationalServices { get; set; } = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi431_RailroadStationMasterFile>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForRailroadStationMasterFile);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.CollectionSize(x => x.GeographicLocation, 1, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.Required(x => x.StationCodesSegment);
		validator.CollectionSize(x => x.PartyIdentification, 0, 10);
		validator.CollectionSize(x => x.CrossReference, 0, 10);
		validator.CollectionSize(x => x.OperationalServices, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
