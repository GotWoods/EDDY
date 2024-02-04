using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._431;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi431_RailroadStationMasterFile {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public SMB_BeginningSegmentForRailroadStationMasterFile BeginningSegmentForRailroadStationMasterFile { get; set; } = new();
	[SectionPosition(3)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	[SectionPosition(4)] public SMS_StationCodesSegment? StationCodesSegment { get; set; }
	[SectionPosition(5)] public List<SMA_StationAddress> StationAddress { get; set; } = new();
	[SectionPosition(6)] public List<SMR_CrossReference> CrossReference { get; set; } = new();
	[SectionPosition(7)] public SMO_OperationalServices? OperationalServices { get; set; }
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi431_RailroadStationMasterFile>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForRailroadStationMasterFile);
		validator.CollectionSize(x => x.GeographicLocation, 1, 10);
		validator.CollectionSize(x => x.StationAddress, 0, 10);
		validator.CollectionSize(x => x.CrossReference, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
