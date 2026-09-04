using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Views.Design;

/// <summary>
/// Builds a realistic, hand-made <see cref="DocumentViewModel"/> without running the real Eddy
/// parser. Used for XAML design-time data (<see cref="DesignData"/>) and for the headless render
/// test, so the view layer can be exercised without depending on the (separately implemented)
/// <see cref="DocumentLoader"/>.
/// </summary>
public sealed class DesignDocumentLoader : IDocumentLoader
{
    public DocumentViewModel Load(string text, string displayName, string? filePath)
    {
        var document = new DocumentViewModel(displayName, filePath, "X12 004010", RawText);

        var rawLines = new List<RawLineViewModel>();
        foreach (var (number, lineText) in RawSegmentLines)
            rawLines.Add(new RawLineViewModel(number, lineText));
        document.RawLines = rawLines;

        RawLineViewModel Line(int number) => rawLines[number - 1];

        // --- Interchange (ISA) --------------------------------------------------------------
        var isaNode = new DocumentNodeViewModel(
            NodeKind.Interchange, "ISA", "ISA 000003438", "01 ABCDEFGHIJKLMNO -> 123456789012345",
            1, null)
        {
            Elements = IsaElements,
        };
        Line(1).Node = isaNode;

        // --- Functional group (GS) ----------------------------------------------------------
        var gsNode = new DocumentNodeViewModel(
            NodeKind.FunctionalGroup, "GS", "GS SM", "4405197800 -> 999999999 · 004010",
            2, null)
        {
            Elements = GsElements,
        };
        Line(2).Node = gsNode;
        isaNode.Children.Add(gsNode);

        // --- Transaction set (ST 204) ---------------------------------------------------------
        var stNode = new DocumentNodeViewModel(
            NodeKind.TransactionSet, "204", "ST 204 Motor Carrier Load Tender", "0001 · 10 segments",
            3, null);
        Line(3).Node = stNode;
        gsNode.Children.Add(stNode);

        // --- Segments --------------------------------------------------------------------------
        var b2 = MakeSegment("B2", "B2 Beginning Segment for Shipment Information Transaction",
            "XXXX 9999955559", 4, B2Elements);
        var b2a = MakeSegment("B2A", "B2A Set Purpose", "04 - Cancellation", 5, B2AElements);
        var l11a = MakeSegment("L11", "L11 Business Instructions and Reference Number",
            "NONPRIMARY OK", 6, L11Elements);
        var ms3 = MakeSegment("MS3", "MS3 Interline Information", "XXXX B M", 7, Ms3Elements);
        var nte = MakeSegment("NTE", "NTE Note/Special Instruction", "FROZEN GOODS SET TO -10d F", 8, NteElements);
        var n1 = MakeSegment("N1", "N1 Name", "PF XYZ CORP", 9, N1Elements);
        var n3 = MakeSegment("N3", "N3 Address Information", "31875 SOLON RD", 10, N3Elements);
        var n4 = MakeSegment("N4", "N4 Geographic Location", "SOLON OH 44139", 11, N4Elements);
        var n7 = MakeSegment("N7", "N7 Equipment Details", "FF 5300", 12, N7Elements, hasErrorElement: true);
        var s5 = MakeSegment("S5", "S5 Stop-off Details", "1 CL 27800", 13, S5Elements);

        foreach (var segment in new[] { b2, b2a, l11a, ms3, nte, n1, n3, n4, n7, s5 })
        {
            stNode.Children.Add(segment);
            Line(segment.LineNumber!.Value).Node = segment;
        }

        document.Nodes.Add(isaNode);

        // --- Diagnostics -------------------------------------------------------------------
        var equipmentDiagnostic = new DiagnosticViewModel(
            DiagnosticSeverity.Error, 12, "N7", "EquipmentDescriptionCode is required")
        {
            Node = n7,
        };
        n7.Diagnostics.Add(equipmentDiagnostic);
        Line(12).HasError = true;
        document.Diagnostics.Add(equipmentDiagnostic);

        var setPurposeDiagnostic = new DiagnosticViewModel(
            DiagnosticSeverity.Warning, 5, "B2A", "SetPurposeCode '04' is not a commonly used code for this transaction")
        {
            Node = b2a,
        };
        b2a.Diagnostics.Add(setPurposeDiagnostic);
        Line(5).HasError = true;
        document.Diagnostics.Add(setPurposeDiagnostic);

        document.Summary = "ISA 000003438 · GS SM 4405197800 -> 999999999 · 1 transaction set · 1 error · 1 warning";

        // Pick a node with something interesting (an error and a composite element) so the
        // element grid isn't empty when this document is shown for the first time.
        document.SelectedNode = n7;
        document.SelectedRawLine = Line(12);

        return document;
    }

    private static DocumentNodeViewModel MakeSegment(
        string code, string title, string subtitle, int lineNumber, IReadOnlyList<ElementViewModel> elements,
        bool hasErrorElement = false)
    {
        var node = new DocumentNodeViewModel(NodeKind.Segment, code, title, subtitle, lineNumber, null)
        {
            Elements = elements,
        };
        _ = hasErrorElement; // error flag is carried on the individual ElementViewModel already.
        return node;
    }

    private static readonly (int Number, string Text)[] RawSegmentLines =
    {
        (1, "ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00400*000003438*0*P*>"),
        (2, "GS*SM*4405197800*999999999*20111219*1747*2100*X*004010"),
        (3, "ST*204*0001"),
        (4, "B2**XXXX**9999955559**PP"),
        (5, "B2A*04"),
        (6, "L11*NONPRIMARY*OK"),
        (7, "MS3*XXXX*B**M"),
        (8, "NTE**FROZEN GOODS SET TO -10d F"),
        (9, "N1*PF*XYZ CORP*9*9995555500000"),
        (10, "N3*31875 SOLON RD"),
        (11, "N4*SOLON*OH*44139"),
        (12, "N7**NONE*********FF****5300"),
        (13, "S5*1*CL*27800*L*2444*CA*1016*E"),
        (14, "SE*12*0001"),
        (15, "GE*1*2100"),
        (16, "IEA*1*000003438"),
    };

    private static readonly string RawText = string.Join('\n', RawSegmentLines.Select(l => l.Text));

    private static ElementViewModel E(string reference, int position, string name, string propertyName, string? value) =>
        new(reference, position, name, propertyName, value);

    private static readonly IReadOnlyList<ElementViewModel> IsaElements = new[]
    {
        E("ISA01", 1, "Authorization Information Qualifier", "AuthorizationInformationQualifier", "01"),
        E("ISA02", 2, "Authorization Information", "AuthorizationInformation", "0000000000"),
        E("ISA03", 3, "Security Information Qualifier", "SecurityInformationQualifier", "01"),
        E("ISA04", 4, "Security Information", "SecurityInformation", "0000000000"),
        E("ISA05", 5, "Interchange ID Qualifier", "InterchangeIdQualifier", "ZZ"),
        E("ISA06", 6, "Interchange Sender ID", "InterchangeSenderId", "ABCDEFGHIJKLMNO"),
        E("ISA07", 7, "Interchange ID Qualifier", "InterchangeIdQualifier2", "ZZ"),
        E("ISA08", 8, "Interchange Receiver ID", "InterchangeReceiverId", "123456789012345"),
        E("ISA09", 9, "Interchange Date", "InterchangeDate", "101127"),
        E("ISA10", 10, "Interchange Time", "InterchangeTime", "1719"),
        E("ISA11", 11, "Interchange Control Standards ID", "InterchangeControlStandardsId", "U"),
        E("ISA12", 12, "Interchange Control Version Number", "InterchangeControlVersionNumber", "00400"),
        E("ISA13", 13, "Interchange Control Number", "InterchangeControlNumber", "000003438"),
        E("ISA14", 14, "Acknowledgment Requested", "AcknowledgmentRequested", "0"),
        E("ISA15", 15, "Usage Indicator", "UsageIndicator", "P"),
        E("ISA16", 16, "Component Element Separator", "ComponentElementSeparator", ">"),
    };

    private static readonly IReadOnlyList<ElementViewModel> GsElements = new[]
    {
        E("GS01", 1, "Functional Identifier Code", "FunctionalIdentifierCode", "SM"),
        E("GS02", 2, "Application Sender's Code", "ApplicationSendersCode", "4405197800"),
        E("GS03", 3, "Application Receiver's Code", "ApplicationReceiversCode", "999999999"),
        E("GS04", 4, "Date", "Date", "20111219"),
        E("GS05", 5, "Time", "Time", "1747"),
        E("GS06", 6, "Group Control Number", "GroupControlNumber", "2100"),
        E("GS07", 7, "Responsible Agency Code", "ResponsibleAgencyCode", "X"),
        E("GS08", 8, "Version / Release / Industry Identifier Code", "VersionReleaseIndustryIdentifierCode", "004010"),
    };

    private static readonly IReadOnlyList<ElementViewModel> B2Elements = new[]
    {
        E("B201", 1, "Tariff Service Code", "TariffServiceCode", null),
        E("B202", 2, "Standard Carrier Alpha Code", "StandardCarrierAlphaCode", "XXXX"),
        E("B203", 3, "Standard Point Location Code", "StandardPointLocationCode", null),
        E("B204", 4, "Shipment Identification Number", "ShipmentIdentificationNumber", "9999955559"),
        E("B205", 5, "Weight Unit Code", "WeightUnitCode", null),
        E("B206", 6, "Shipment Method Of Payment", "ShipmentMethodOfPayment", "PP"),
        E("B207", 7, "Shipment Qualifier", "ShipmentQualifier", null),
        E("B208", 8, "Total Equipment", "TotalEquipment", null),
        E("B209", 9, "Shipment Weight Code", "ShipmentWeightCode", null),
        E("B210", 10, "Customs Documentation Handling Code", "CustomsDocumentationHandlingCode", null),
        E("B211", 11, "Transportation Terms Code", "TransportationTermsCode", null),
        E("B212", 12, "Payment Method Code", "PaymentMethodCode", null),
    };

    private static readonly IReadOnlyList<ElementViewModel> B2AElements = new[]
    {
        E("B2A01", 1, "Set Purpose Code", "SetPurposeCode", "04"),
    };

    private static readonly IReadOnlyList<ElementViewModel> L11Elements = new[]
    {
        E("L1101", 1, "Reference Identification", "ReferenceIdentification", "NONPRIMARY"),
        E("L1102", 2, "Reference Identification Qualifier", "ReferenceIdentificationQualifier", "OK"),
        E("L1103", 3, "Description", "Description", null),
    };

    private static readonly IReadOnlyList<ElementViewModel> Ms3Elements = new[]
    {
        E("MS301", 1, "Standard Carrier Alpha Code", "StandardCarrierAlphaCode", "XXXX"),
        E("MS302", 2, "Routing Sequence Code", "RoutingSequenceCode", "B"),
        E("MS303", 3, "City Name", "CityName", null),
        E("MS304", 4, "Transportation Method Type Code", "TransportationMethodTypeCode", "M"),
        E("MS305", 5, "State Or Province Code", "StateOrProvinceCode", null),
    };

    private static readonly IReadOnlyList<ElementViewModel> NteElements = new[]
    {
        E("NTE01", 1, "Note Reference Code", "NoteReferenceCode", null),
        E("NTE02", 2, "Description", "Description", "FROZEN GOODS SET TO -10d F"),
    };

    // Populated with plausible metadata-pack-style values (DE numbers, formal types, requirement, code
    // meaning) so the element grid's new columns have something realistic to show in design/headless mode,
    // without depending on a real pack (X12 has none bundled; see docs/metadata-packs.md).
    private static readonly IReadOnlyList<ElementViewModel> N1Elements = new[]
    {
        new ElementViewModel("N101", 1, "Entity Identifier Code", "EntityIdentifierCode", "PF")
        {
            DataElementNumber = "98", DataTypeLabel = "ID 2..3", Requirement = "M", CodeDescription = "Party to receive shipment", Origin = "derived",
        },
        new ElementViewModel("N102", 2, "Name", "Name", "XYZ CORP")
        {
            DataElementNumber = "93", DataTypeLabel = "AN 1..60", Requirement = "C", Origin = "derived",
        },
        new ElementViewModel("N103", 3, "Identification Code Qualifier", "IdentificationCodeQualifier", "9")
        {
            DataElementNumber = "66", DataTypeLabel = "ID 1..2", Requirement = "C", CodeDescription = "D-U-N-S Number", Origin = "derived",
        },
        new ElementViewModel("N104", 4, "Identification Code", "IdentificationCode", "9995555500000")
        {
            DataElementNumber = "67", DataTypeLabel = "AN 2..80", Requirement = "C", Origin = "derived",
        },
        new ElementViewModel("N105", 5, "Entity Relationship Code", "EntityRelationshipCode", null)
        {
            DataElementNumber = "706", DataTypeLabel = "ID 2..2", Requirement = "O", Origin = "derived",
        },
        new ElementViewModel("N106", 6, "Entity Identifier Code 2", "EntityIdentifierCode2", null)
        {
            DataElementNumber = "98", DataTypeLabel = "ID 2..3", Requirement = "O", Origin = "derived",
        },
    };

    private static readonly IReadOnlyList<ElementViewModel> N3Elements = new[]
    {
        E("N301", 1, "Address Information", "AddressInformation", "31875 SOLON RD"),
        E("N302", 2, "Address Information 2", "AddressInformation2", null),
    };

    private static readonly IReadOnlyList<ElementViewModel> N4Elements = new[]
    {
        E("N401", 1, "City Name", "CityName", "SOLON"),
        E("N402", 2, "State Or Province Code", "StateOrProvinceCode", "OH"),
        E("N403", 3, "Postal Code", "PostalCode", "44139"),
        E("N404", 4, "Country Code", "CountryCode", null),
        E("N405", 5, "Location Qualifier", "LocationQualifier", null),
        E("N406", 6, "Location Identifier", "LocationIdentifier", null),
    };

    private static readonly IReadOnlyList<ElementViewModel> N7Elements = new[]
    {
        E("N701", 1, "Equipment Initial", "EquipmentInitial", null),
        E("N702", 2, "Equipment Number", "EquipmentNumber", null),
        E("N703", 3, "Weight", "Weight", null),
        E("N704", 4, "Weight Qualifier", "WeightQualifier", null),
        E("N705", 5, "Tare Weight", "TareWeight", null),
        E("N706", 6, "Weight Allowance", "WeightAllowance", null),
        E("N707", 7, "Dunnage", "Dunnage", null),
        E("N708", 8, "Volume", "Volume", null),
        E("N709", 9, "Volume Unit Qualifier", "VolumeUnitQualifier", null),
        E("N710", 10, "Ownership Code", "OwnershipCode", null),
        new("N711", 11, "Equipment Description Code", "EquipmentDescriptionCode", null) { HasError = true },
        E("N712", 12, "Standard Carrier Alpha Code", "StandardCarrierAlphaCode", "FF"),
        E("N713", 13, "Temperature Control", "TemperatureControl", null),
        E("N714", 14, "Position", "Position", null),
        E("N715", 15, "Equipment Length", "EquipmentLength", null),
        E("N716", 16, "Tare Qualifier Code", "TareQualifierCode", null),
        new("N7-C1", 17, "Weight Unit Code (composite demo)", "WeightUnitComposite", "5300#L") // demonstrates a composite element in the grid.
        {
            Components = new[]
            {
                E("N7-C1-1", 1, "Weight Unit Code", "WeightUnitCode", "5300"),
                E("N7-C1-2", 2, "Unit Qualifier", "UnitQualifier", "L"),
            },
        },
    };

    private static readonly IReadOnlyList<ElementViewModel> S5Elements = new[]
    {
        E("S501", 1, "Stop Sequence Number", "StopSequenceNumber", "1"),
        E("S502", 2, "Stop Reason Code", "StopReasonCode", "CL"),
        E("S503", 3, "Weight", "Weight", "27800"),
        E("S504", 4, "Weight Unit Code", "WeightUnitCode", "L"),
        E("S505", 5, "Number Of Units Shipped", "NumberOfUnitsShipped", "2444"),
        E("S506", 6, "Unit Or Basis For Measurement Code", "UnitOrBasisForMeasurementCode", "CA"),
        E("S507", 7, "Volume", "Volume", "1016"),
        E("S508", 8, "Volume Unit Qualifier", "VolumeUnitQualifier", "E"),
        E("S509", 9, "Description", "Description", null),
        E("S510", 10, "Standard Point Location Code", "StandardPointLocationCode", null),
        E("S511", 11, "Accomplish Code", "AccomplishCode", null),
    };
}
