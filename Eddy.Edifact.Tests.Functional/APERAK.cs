using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08A;

namespace Eddy.Edifact.Tests.Functional;


public class APERAK {
	//[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(1)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public FTX_FreeText FreeText { get; set; } = new();
	[SectionPosition(4)] public CNT_ControlTotal ControlTotal { get; set; }

	//Segment Group 1

    [SectionPosition(6)] public List<SegmentGroup1> Group1 { get; set; } = new();
    [SectionPosition(7)] public List<SegmentGroup2> Group2 { get; set; } = new();
    [SectionPosition(8)] public List<SegmentGroup3> Group3 { get; set; } = new();
    [SectionPosition(9)] public List<SegmentGroup4> Group4 { get; set; } = new();
    [SectionPosition(10)] public List<SegmentGroup5> Group5 { get; set; } = new();
  //  [SectionPosition(11)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();
	


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<APERAK>(this);
		// validator.Required(x => x.TransactionSetHeader);
		// validator.Required(x => x.BeginningSegmentForShipmentInformationTransaction);
		// validator.Required(x => x.SetPurpose);
		// validator.CollectionSize(x => x.Authentication, 0, 4);
		// validator.CollectionSize(x => x.ReferenceIdentification, 0, 300);
		// validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		// validator.CollectionSize(x => x.DateTime, 0, 6);
		// validator.CollectionSize(x => x.RouteInformationMotor, 0, 12);
		// validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		// validator.CollectionSize(x => x.SpecialServices, 0, 6);
		// validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		// validator.CollectionSize(x => x.Remarks, 0, 10);
		//
		//
		// validator.CollectionSize(x => x.L0100, 0, 10);
		// validator.CollectionSize(x => x.L0200, 0, 10);
		// validator.CollectionSize(x => x.L0250, 0, 999999);
		// foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		// foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		// foreach (var item in L0250) validator.Results.AddRange(item.Validate().Errors);
		//
		//
		// validator.CollectionSize(x => x.L0300, 0, 999);
		// validator.CollectionSize(x => x.L0400, 0, 9999);
		// foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		// foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		// validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}


    public class SegmentGroup1
    {
        [SectionPosition(1)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
        [SectionPosition(2)] public List<DTM_DateTimePeriod> DAteTimePeriod { get; set; } = new();
    }

    public class SegmentGroup2
    {
        [SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
        [SectionPosition(2)] public List<DTM_DateTimePeriod> DAteTimePeriod { get; set; } = new();
    }

    public class SegmentGroup3
    {
        [SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
        [SectionPosition(2)] public List<CTA_ContactInformation> ContactInformation { get; set; } = new();
        [SectionPosition(2)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
    }

    public class SegmentGroup4
    {
        [SectionPosition(1)] public ERC_ApplicationErrorInformation ApplicationErrorInformation { get; set; } = new();
        [SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
    }

    public class SegmentGroup5
    {
        [SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
        [SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
    }
}
