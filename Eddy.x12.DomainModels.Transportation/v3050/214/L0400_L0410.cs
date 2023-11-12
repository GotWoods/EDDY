using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._214;

public class L0400_L0410 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public BLR_TransportationCarrierIdentification? TransportationCarrierIdentification { get; set; }
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public TSD_TrailerShipmentDetails? TrailerShipmentDetails { get; set; }
	[SectionPosition(7)] public List<L0400__L0410_L0412> L0412 {get;set;} = new();
	[SectionPosition(8)] public List<L0400__L0410_L0414> L0414 {get;set;} = new();
}
