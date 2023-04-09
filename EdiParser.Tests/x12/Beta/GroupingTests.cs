using System.Text.Json;
using System.Xml.Serialization;
using EdiParser.x12;
using EdiParser.x12.Internals.Beta;
using EdiParser.x12.Models;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace EdiParser.Tests.x12.Beta;

public class GroupingTests
{

    private readonly GroupingRule _entityInfoGroupRules;
    private readonly GroupingRule _transactionSetGroupingRule;
    private ITestOutputHelper _output;

    public GroupingTests(ITestOutputHelper output)
    {
        _output = output;
        Logging.LoggerFactory = new XUnitLoggingFactory(output);

        _entityInfoGroupRules = new GroupingRule("EntityInfo", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation));
        _transactionSetGroupingRule = new GroupingRule("Transaction Set", typeof(LX_TransactionSetLineNumber), typeof(H1_HazardousMaterial));
        _transactionSetGroupingRule.AddSubRule(new GroupingRule("Order Detail", typeof(OID_OrderInformationDetail), typeof(SDQ_DestinationQuantity)));
    }

    [Fact]
    public void ThreeRootElementsInARow()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N3_PartyLocation());

        //group2
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N3_PartyLocation());

        //group3
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N3_PartyLocation());

        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, _transactionSetGroupingRule
        });
        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();


        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[1].Segments.Add(new N1_PartyIdentification());
        expected.Children[1].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[2].Segments.Add(new N1_PartyIdentification());
        expected.Children[2].Segments.Add(new N3_PartyLocation());

        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true);
        Assert.Equivalent(expected.Children[1].Segments, actual.Children[1].Segments, true);
        Assert.Equivalent(expected.Children[2].Segments, actual.Children[2].Segments, true);
    }

    [Fact]
    public void NoGroupShouldKeepData()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

       

        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, _transactionSetGroupingRule
        });
        var subject = new GroupedSectionReader(section, root);
        var actual =  subject.Read();

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        Assert.Equivalent(expected.Segments, actual.Segments, false);
    }

    [Fact]
    public void OnlyOneItemToGroup()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N3_PartyLocation());


        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules
        });
        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();
        
        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        Assert.Equivalent(expected.Segments, actual.Segments, true);
    }

    [Fact]
    public void TwoGroupsWithSameStarting()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N3_PartyLocation());

        //group2
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());

        

        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, _transactionSetGroupingRule
        });

        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();
        

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[1].Segments.Add(new N1_PartyIdentification());
        expected.Children[1].Segments.Add(new N2_AdditionalNameInformation());
        expected.Children[1].Segments.Add(new N3_PartyLocation());

        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true);
        Assert.Equivalent(expected.Children[1].Segments, actual.Children[1].Segments, true);

        //        Assert.Equivalent(expected, actual, true);
    }

    [Fact]
    public void TwoDifferentTypesOfGroups()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N3_PartyLocation());

        //group2
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());

        //group3
        section.Segments.Add(new LX_TransactionSetLineNumber());
        section.Segments.Add(new H1_HazardousMaterial());
        //subgroup of group3
        //section.Segments.Add(new OID_OrderInformationDetail());



        //g2.SubGroups.Add(new GroupingRule(typeof(OID_OrderInformationDetail), typeof(SDQ_DestinationQuantity)));

        
        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, _transactionSetGroupingRule
        });
        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[1].Segments.Add(new N1_PartyIdentification());
        expected.Children[1].Segments.Add(new N2_AdditionalNameInformation());
        expected.Children[1].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[2].Segments.Add(new LX_TransactionSetLineNumber());
        expected.Children[2].Segments.Add(new H1_HazardousMaterial());

        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true);
        Assert.Equivalent(expected.Children[1].Segments, actual.Children[1].Segments, true);
        Assert.Equivalent(expected.Children[2].Segments, actual.Children[2].Segments, true);

        //Assert.Equivalent(expected, actual, true);
    }

    [Fact]
    public void SubGroup()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new LX_TransactionSetLineNumber());
        section.Segments.Add(new H1_HazardousMaterial());
        //subgroup
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new SDQ_DestinationQuantity());



        

        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _transactionSetGroupingRule
        });

        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new LX_TransactionSetLineNumber());
        expected.Children[0].Segments.Add(new H1_HazardousMaterial());
        expected.Children[0].AddChild(new Group());
        expected.Children[0].Children[0].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[0].Children[0].Segments.Add(new SDQ_DestinationQuantity());

        Assert.Equivalent(expected.Children[0].Children[0].Segments, actual.Children[0].Children[0].Segments, false);
        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, false);

        //Assert.Equivalent(expected, actual, false);
    }

    [Fact]
    public void RepeatingSubGroups()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());

        //group2
        section.Segments.Add(new LX_TransactionSetLineNumber());
        section.Segments.Add(new H1_HazardousMaterial());

        //subgroup1
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new SDQ_DestinationQuantity());

        //subgroup1 repeats
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new SDQ_DestinationQuantity());

        
        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, _transactionSetGroupingRule
        });
        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N2_AdditionalNameInformation());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[1].Segments.Add(new LX_TransactionSetLineNumber());
        expected.Children[1].Segments.Add(new H1_HazardousMaterial());
        expected.Children[1].AddChild(new Group());
        expected.Children[1].Children[0].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[1].Children[0].Segments.Add(new SDQ_DestinationQuantity());
        expected.Children[1].AddChild(new Group());
        expected.Children[1].Children[1].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[1].Children[1].Segments.Add(new SDQ_DestinationQuantity());

        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true);
        Assert.Equivalent(expected.Children[1].Children[0].Segments, actual.Children[1].Children[0].Segments, true);
        Assert.Equivalent(expected.Children[1].Children[1].Segments, actual.Children[1].Children[1].Segments, true);
        Assert.Equivalent(expected.Children[1].Segments, actual.Children[1].Segments, true);

//        Assert.Equivalent(expected, actual, true);
    }

    [Fact]
    public void N1ExistsAtRootAndSubGroup()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());

        //subgroup1
        section.Segments.Add(new S5_StopOffDetails());
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N3_PartyLocation());

        

        var stopDetailsRules = new GroupingRule("StopOffDetails", typeof(S5_StopOffDetails), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(G62_DateTime), typeof(AT8_ShipmentWeightPackagingAndQuantityData), typeof(LAD_LadingDetail));
        stopDetailsRules.AddSubRule("Stop Parties", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation), typeof(N4_GeographicLocation), typeof(G61_Contact));

        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, stopDetailsRules
        });
        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N2_AdditionalNameInformation());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[1].Segments.Add(new S5_StopOffDetails());
        expected.Children[1].AddChild(new Group());
        expected.Children[1].Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[1].Children[0].Segments.Add(new N3_PartyLocation());

        Assert.Equal(2, expected.Children.Count);
        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true); //n1 group
        Assert.Equivalent(expected.Children[1].Segments, actual.Children[1].Segments, true); //s5Group
        Assert.Equivalent(expected.Children[1].Children[0].Segments, actual.Children[1].Children[0].Segments, true); //s5Group.n1Group

    }

    [Fact ]
    public void TwoItemsInSubGroup()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());

        //group2
        section.Segments.Add(new S5_StopOffDetails());
        //subgroup1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());
        //subgroup2
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new OID_OrderInformationDetail());

        //section.Segments.Add(new L9_ChargeDetail());

        var stopsRules = new GroupingRule("Stops", typeof(S5_StopOffDetails));
        stopsRules.AddSubRule("Stop Entity", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation));
        stopsRules.AddSubRule("OID rule", typeof(OID_OrderInformationDetail));

        
        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, stopsRules
        });
        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N2_AdditionalNameInformation());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        //group2 (stop)
        expected.AddChild(new Group());
        expected.Children[1].Segments.Add(new S5_StopOffDetails());
        expected.Children[1].AddChild(new Group()); //name on stop
        expected.Children[1].Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[1].Children[0].Segments.Add(new N2_AdditionalNameInformation());
        expected.Children[1].Children[0].Segments.Add(new N3_PartyLocation());
        expected.Children[1].AddChild(new Group()); //OID on stop
        expected.Children[1].Children[1].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[1].AddChild(new Group()); //OID on stop
        expected.Children[1].Children[2].Segments.Add(new OID_OrderInformationDetail());

        Assert.Equal(expected.Children.Count, actual.Children.Count);
        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true); //name
        Assert.Equivalent(expected.Children[1].Segments, actual.Children[1].Segments, true); //stops
        
        Assert.Equal(expected.Children[1].Children.Count, actual.Children[1].Children.Count);
        Assert.Equivalent(expected.Children[1].Children[0].Segments, actual.Children[1].Children[0].Segments, true); //name on stop
        Assert.Equivalent(expected.Children[1].Children[1].Segments, actual.Children[1].Children[1].Segments, true); //OID1
        Assert.Equivalent(expected.Children[1].Children[2].Segments, actual.Children[1].Children[2].Segments, true); //OID2
        

    }

    [Fact]
    public void SubGroupNesting()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());

        //group2
        section.Segments.Add(new S5_StopOffDetails() { AccomplishCode = "ABC" });
        //subgroup1
        section.Segments.Add(new N1_PartyIdentification() { Name = "Name" });
        section.Segments.Add(new N2_AdditionalNameInformation() { Name = "More Name" });
        section.Segments.Add(new N3_PartyLocation() { AddressInformation = "123 street" });
        //subgroup2
        section.Segments.Add(new OID_OrderInformationDetail() { ReferenceIdentification = "OID1" });
        section.Segments.Add(new LAD_LadingDetail());
        section.Segments.Add(new L5_DescriptionMarksAndNumbers());
        //subgroup3
        section.Segments.Add(new OID_OrderInformationDetail() { ReferenceIdentification = "OID2" });
        section.Segments.Add(new LAD_LadingDetail());
        section.Segments.Add(new L5_DescriptionMarksAndNumbers());


        var stopsRules = new GroupingRule("Stops", typeof(S5_StopOffDetails));
        stopsRules.AddSubRule("Stop Entity", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation));
        var oidRule = stopsRules.AddSubRule("OID rule", typeof(OID_OrderInformationDetail), typeof(LAD_LadingDetail));
        oidRule.AddSubRule("L5 Rule", typeof(L5_DescriptionMarksAndNumbers));

        
        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, stopsRules
        });
        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();
        

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        expected.AddChild(new Group()
        {
            Segments = new List<EdiX12Segment>()
            {
                new N1_PartyIdentification(),
                new N2_AdditionalNameInformation(),
                new N3_PartyLocation(), 
            }
        });

        //group2 (stop)
        expected.AddChild(new Group()
        {
            Segments = new List<EdiX12Segment>() { new S5_StopOffDetails() {AccomplishCode = "ABC"} },
        });

        //stop entities
        var expectedStop = expected.Children[1];
        expectedStop.AddChild(new Group() //name on stop1
        {
            Segments = new List<EdiX12Segment>()
            {
                new N1_PartyIdentification() {Name = "Name"},
                new N2_AdditionalNameInformation() { Name="More Name"},
                new N3_PartyLocation() {AddressInformation = "123 street"}
            }
        }); 

        expectedStop.AddChild(new Group() //OID on stop1
        {
            Segments = new List<EdiX12Segment>()
            {
                new OID_OrderInformationDetail() {ReferenceIdentification = "OID1"},
                new LAD_LadingDetail(),
            },
        });
        expectedStop.AddChild(new Group() //OID on stop2
        {
            Segments = new List<EdiX12Segment>()
            {
                new OID_OrderInformationDetail() {ReferenceIdentification = "OID2"},
                new LAD_LadingDetail()
            }
        });

        var oid1 = expectedStop.Children[0];
        var oid2 = expectedStop.Children[1];

        oid1.AddChild(new Group() //L5 on OID on Stop1
        {
            Segments = new List<EdiX12Segment>()
            {
                new L5_DescriptionMarksAndNumbers()
            }
            });

        
        oid2.AddChild(new Group() //L5 on OID on Stop2
        {
            Segments = new List<EdiX12Segment>()
            {
                new L5_DescriptionMarksAndNumbers()
            }
        });


        LogGroup(actual);
        //Logging.Logger<GroupingTests>().LogDebug(SerializeObject(actual));

        Assert.Equal("EntityInfo", actual.Children[0].Name);
        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true);

        var actualStops = actual.Children[1];
        Assert.Equal("Stops", actualStops.Name);
        Assert.Equivalent(expectedStop.Segments, actualStops.Segments, true);



        Assert.Equal("Stops.Stop Entity", actualStops.Children[0].Name);
        Assert.Equivalent(expectedStop.Children[0].Segments, actualStops.Children[0].Segments, true); //name on stop

        Assert.Equal("Stops.OID rule", actualStops.Children[1].Name);
        Assert.Equivalent(expectedStop.Children[1].Segments, actualStops.Children[1].Segments, true); //OID1

        Assert.Equal("Stops.OID rule", actualStops.Children[2].Name);
        Assert.Equivalent(expectedStop.Children[2].Segments, actualStops.Children[2].Segments, true); //OID2


    }

    [Fact]
    public void RepeatingNesting()
    {
        var section = new Section();
        //core data
        section.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        //group1
        section.Segments.Add(new N1_PartyIdentification());
        section.Segments.Add(new N2_AdditionalNameInformation());
        section.Segments.Add(new N3_PartyLocation());

        //group2
        section.Segments.Add(new LX_TransactionSetLineNumber());
        section.Segments.Add(new H1_HazardousMaterial());

        //subgroup1
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new SDQ_DestinationQuantity());

        //subgroup1 repeats
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new SDQ_DestinationQuantity());

        //group3
        section.Segments.Add(new LX_TransactionSetLineNumber());
        section.Segments.Add(new H1_HazardousMaterial());

        //subgroup1
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new SDQ_DestinationQuantity());

        //subgroup1 repeats
        section.Segments.Add(new OID_OrderInformationDetail());
        section.Segments.Add(new SDQ_DestinationQuantity());


        
        var root = new GroupingRule("Root", new[] { "B3" }, new List<GroupingRule>()
        {
            _entityInfoGroupRules, _transactionSetGroupingRule
        });

        var subject = new GroupedSectionReader(section, root);
        var actual = subject.Read();

        var expected = new Group();
        expected.Segments.Add(new B3_BeginningSegmentForCarriersInvoice());

        expected.AddChild(new Group());
        expected.Children[0].Segments.Add(new N1_PartyIdentification());
        expected.Children[0].Segments.Add(new N2_AdditionalNameInformation());
        expected.Children[0].Segments.Add(new N3_PartyLocation());

        expected.AddChild(new Group());
        expected.Children[1].Segments.Add(new LX_TransactionSetLineNumber());
        expected.Children[1].Segments.Add(new H1_HazardousMaterial());
        expected.Children[1].AddChild(new Group());
        expected.Children[1].Children[0].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[1].Children[0].Segments.Add(new SDQ_DestinationQuantity());
        expected.Children[1].AddChild(new Group());
        expected.Children[1].Children[1].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[1].Children[1].Segments.Add(new SDQ_DestinationQuantity());

        expected.AddChild(new Group());
        expected.Children[2].Segments.Add(new LX_TransactionSetLineNumber());
        expected.Children[2].Segments.Add(new H1_HazardousMaterial());
        expected.Children[2].AddChild(new Group());
        expected.Children[2].Children[0].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[2].Children[0].Segments.Add(new SDQ_DestinationQuantity());
        expected.Children[2].AddChild(new Group());
        expected.Children[2].Children[1].Segments.Add(new OID_OrderInformationDetail());
        expected.Children[2].Children[1].Segments.Add(new SDQ_DestinationQuantity());

        Assert.Equivalent(expected.Children[0].Segments, actual.Children[0].Segments, true);
        Assert.Equivalent(expected.Children[1].Children[0].Segments, actual.Children[1].Children[0].Segments, true);
        Assert.Equivalent(expected.Children[1].Children[1].Segments, actual.Children[1].Children[1].Segments, true);
        Assert.Equivalent(expected.Children[1].Segments, actual.Children[1].Segments, true);

        Assert.Equivalent(expected.Children[2].Children[0].Segments, actual.Children[1].Children[0].Segments, true);
        Assert.Equivalent(expected.Children[2].Children[1].Segments, actual.Children[1].Children[1].Segments, true);
        Assert.Equivalent(expected.Children[2].Segments, actual.Children[1].Segments, true);

        //        Assert.Equivalent(expected, actual, true);
    }

    private int groupDepth = 0;
    public void LogGroup(Group group)
    {
        if (group.Rule != null)
            _output.WriteLine("".PadLeft(groupDepth, ' ') + "+" + group.Rule.Name);
        foreach (var segment in group.Segments)
        {
            _output.WriteLine("".PadLeft(groupDepth, ' ') + "  " + segment.GetType());
        }

        if (group.Children.Count > 0)
        {
          
            groupDepth++;
            foreach (var child in group.Children)
            {
                LogGroup(child);
            }
            
            groupDepth--;
        }
    }
}


