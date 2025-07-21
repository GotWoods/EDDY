using Eddy.Core.DocumentStructure;
using Eddy.x12.DomainModels.Transportation.v4010;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests;

public class StructureTests
{
    [Fact]
    public void GetStructure()
    {
        // [SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
        // [SectionPosition(2)] public B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage BeginningSegmentForTransportationCarrierShipmentStatusMessage { get; set; } = new();
        // [SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
        // [SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
        // [SectionPosition(5)] public List<K1_Remarks> Remarks { get; set; } = new();
        // [SectionPosition(6)] public List<L0100> L0100 { get; set; } = new();
        /*
         *	    [SectionPosition(1)] public N1_Name Name { get; set; } = new();
                [SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
                [SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
                [SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
                [SectionPosition(5)] public G61_Contact? Contact { get; set; }
                [SectionPosition(6)] public G62_DateTime? DateTime { get; set; }
                [SectionPosition(7)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
         */
        // [SectionPosition(7)] public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();
        // [SectionPosition(8)] public List<L0200> L0200 { get; set; } = new();
        /*
               [SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
               [SectionPosition(2)] public List<L0200_L0205> L0205 {get;set;} = new();
                    [SectionPosition(1)] public AT7_ShipmentStatusDetails ShipmentStatusDetails { get; set; } = new();
                    [SectionPosition(2)] public MS1_EquipmentShipmentOrRealPropertyLocation? EquipmentShipmentOrRealPropertyLocation { get; set; }
                    [SectionPosition(3)] public MS2_EquipmentOrContainerOwnerAndType? EquipmentOrContainerOwnerAndType { get; set; }
               [SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
               [SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
               [SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
               [SectionPosition(6)] public List<K1_Remarks> Remarks { get; set; } = new();
               [SectionPosition(7)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
               [SectionPosition(8)] public List<AT8_ShipmentWeightPackagingAndQuantityData> ShipmentWeightPackagingAndQuantityData { get; set; } = new();
               [SectionPosition(9)] public List<L0200_L0210> L0210 {get;set;} = new();
                   [SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
                   [SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
                   [SectionPosition(3)] public List<L0200__L0210_L0215> L0215 {get;set;} = new();
                   [SectionPosition(4)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
                   [SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
                   [SectionPosition(6)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
                   [SectionPosition(7)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
                   [SectionPosition(8)] public List<L0200__L0210_L0220> L0220 {get;set;} = new();
               [SectionPosition(10)] public List<L0200_L0230> L0230 {get;set;} = new();
               [SectionPosition(11)] public List<L0200_L0250> L0250 {get;set;} = new();
               [SectionPosition(12)] public List<L0200_L0260> L0260 {get;set;} = new();
         */
        // [SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

        var map = Structure.Of<Edi214_TransportationCarrierShipmentStatusMessage>();

        VerifySection("ST", "TransactionSetHeader", SectionType.Segment, map[0]);
        VerifySection("B10", "BeginningSegmentForTransportationCarrierShipmentStatusMessage", SectionType.Segment,map[1]);
        VerifySection("L11", "BusinessInstructionsAndReferenceNumber", SectionType.RepeatingSegment,map[2]);
        
        VerifySegment("ReferenceIdentification", 1, map[2].Segments[0]);
        VerifySegment("ReferenceIdentificationQualifier", 2, map[2].Segments[1]);
        VerifySegment("Description", 3, map[2].Segments[2]);
        
        VerifySection("MAN", "MarksAndNumbers", SectionType.RepeatingSegment, map[3]);
        VerifySection("K1", "Remarks", SectionType.RepeatingSegment, map[4]);
        #region L0100
        var l0100 = map[5];
        VerifySection("L0100", "L0100", SectionType.RepeatingComplexType, l0100);
        VerifySection("N1", "Name", SectionType.Segment,l0100.Sections[0]);
        VerifySection("N2", "AdditionalNameInformation", SectionType.Segment, l0100.Sections[1]);
        VerifySection("N3", "AddressInformation", SectionType.RepeatingSegment, l0100.Sections[2]);
        VerifySection("N4", "GeographicLocation", SectionType.Segment,l0100.Sections[3]);
        VerifySection("G61", "Contact", SectionType.Segment, l0100.Sections[4]);
        VerifySection("G62", "DateTime", SectionType.Segment, l0100.Sections[5]);
        VerifySection("L11", "BusinessInstructionsAndReferenceNumber", SectionType.RepeatingSegment, l0100.Sections[6]);
        #endregion L0100
        
        VerifySection("MS3", "InterlineInformation", SectionType.RepeatingSegment, map[6]);

        #region L0200
        var l0200 = map[7];
        VerifySection("L0200", "L0200", SectionType.RepeatingComplexType, l0200);
        VerifySection("LX", "AssignedNumber", SectionType.Segment,l0200.Sections[0]);
        VerifySection("L0200_L0205", "L0200_L0205", SectionType.RepeatingComplexType, l0200.Sections[1]);

        #region l0200_L0205
        var l0200_L0205 = l0200.Sections[1];
        VerifySection("AT7", "ShipmentStatusDetails", SectionType.Segment,l0200_L0205.Sections[0]);

        var segment = l0200_L0205.Sections[0].Segments; //get the parts from the AT7 line
        VerifySegment("ShipmentStatusCode", 1, segment[0]);
        VerifySegment("ShipmentStatusOrAppointmentReasonCode", 2, segment[1]);
        VerifySegment("ShipmentAppointmentStatusCode", 3, segment[2]);
        VerifySegment("ShipmentStatusOrAppointmentReasonCode2", 4, segment[3]);
        VerifySegment("Date", 5, segment[4]);
        VerifySegment("Time", 6, segment[5]);
        VerifySegment("TimeCode", 7, segment[6]);

        VerifySection("MS1", "EquipmentShipmentOrRealPropertyLocation", SectionType.Segment, l0200_L0205.Sections[1]);
        VerifySection("MS2", "EquipmentOrContainerOwnerAndType", SectionType.Segment, l0200_L0205.Sections[2]);
        #endregion l0200_L0205

        VerifySection("L11", "BusinessInstructionsAndReferenceNumber", SectionType.RepeatingSegment, l0200.Sections[2]);
        VerifySection("MAN", "MarksAndNumbers", SectionType.RepeatingSegment, l0200.Sections[3]);
        VerifySection("Q7", "LadingExceptionCode", SectionType.RepeatingSegment, l0200.Sections[4]);
        VerifySection("K1", "Remarks", SectionType.RepeatingSegment, l0200.Sections[5]);
        VerifySection("AT5", "BillOfLadingHandlingRequirements", SectionType.RepeatingSegment, l0200.Sections[6]);
        VerifySection("AT8", "ShipmentWeightPackagingAndQuantityData", SectionType.RepeatingSegment, l0200.Sections[7]);
        VerifySection("L0200_L0210", "L0200_L0210", SectionType.RepeatingComplexType, l0200.Sections[8]);

        #region l0200_L0210
        var l0200_L0210 = l0200.Sections[8];
        VerifySection("CD3", "CartonPackageDetail", SectionType.Segment, l0200_L0210.Sections[0]);
        VerifySection("L11", "BusinessInstructionsAndReferenceNumber", SectionType.RepeatingSegment, l0200_L0210.Sections[1]);
        VerifySection("L0200__L0210_L0215", "L0200__L0210_L0215", SectionType.RepeatingComplexType, l0200_L0210.Sections[2]);
        VerifySection("NM1", "IndividualOrOrganizationalName", SectionType.Segment, l0200_L0210.Sections[3]);
        VerifySection("Q7", "LadingExceptionCode", SectionType.RepeatingSegment, l0200_L0210.Sections[4]);
        VerifySection("AT8", "ShipmentWeightPackagingAndQuantityData", SectionType.Segment, l0200_L0210.Sections[5]);
        VerifySection("MAN", "MarksAndNumbers", SectionType.RepeatingSegment, l0200_L0210.Sections[6]);
        VerifySection("L0200__L0210_L0220", "L0200__L0210_L0220", SectionType.RepeatingComplexType, l0200_L0210.Sections[7]);
        #endregion l0200_L0210

        VerifySection("L0200_L0230", "L0200_L0230", SectionType.RepeatingComplexType, l0200.Sections[9]);
        VerifySection("L0200_L0250", "L0200_L0250", SectionType.RepeatingComplexType, l0200.Sections[10]);
        VerifySection("L0200_L0260", "L0200_L0260", SectionType.RepeatingComplexType, l0200.Sections[11]);
        #endregion L0200

        VerifySection("SE", "TransactionSetTrailer", SectionType.Segment, map[8]);
    }

    private void VerifySection(string code, string name, SectionType sectionType, Eddy.Core.DocumentStructure.Section item)
    {
        Assert.Equal(code, item.Code);
        Assert.Equal(name, item.Name);
        Assert.Equal(sectionType, item.SectionType);
    }

    [Fact]
    public void SegmentParser()
    {
        var segment = Structure.GetSegments(typeof(AT7_ShipmentStatusDetails));
        VerifySegment("ShipmentStatusCode", 1, segment[0]);
        VerifySegment("ShipmentStatusOrAppointmentReasonCode", 2, segment[1]);
        VerifySegment("ShipmentAppointmentStatusCode", 3, segment[2]);
        VerifySegment("ShipmentStatusOrAppointmentReasonCode2", 4, segment[3]);
        VerifySegment("Date", 5, segment[4]);
        VerifySegment("Time", 6, segment[5]);
        VerifySegment("TimeCode", 7, segment[6]);
    }

    private void VerifySegment(string name, int position, Eddy.Core.DocumentStructure.Segment item)
    {
        Assert.Equal(name, item.Name);
        Assert.Equal(position, item.Position);
    }
}