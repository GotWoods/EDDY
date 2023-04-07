using EdiParser.x12.Internals;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels;

public class Edi211_MotorCarrierBillOfLading
{

    public void LoadFrom(x12Document document)
    {
        var section = document.Sections[0]; //it is possible a document contains multiple instructions
        

         var partyRules = new GroupingRule("Parties", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation), typeof(N4_GeographicLocation), typeof(G61_Contact));
         var detailRules = new GroupingRule("Details", typeof(AT1_BillOfLadingLineItemNumber), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(AT3_BillOfLadingRatesAndCharges), typeof(AT4_BillOfLadingDescription));
         detailRules.AddSubRule("Bill Of Lading Line Item Detail", typeof(AT2_BillOfLadingLineItemDetail), typeof(MAN_MarksAndNumbersInformation), typeof(OID_OrderInformationDetail), typeof(L4_Measurement));
         detailRules.AddSubRule("TransactionSet", typeof(LX_TransactionSetLineNumber), typeof(MAN_MarksAndNumbersInformation), typeof(OID_OrderInformationDetail));
        
         var contactRule = detailRules.AddSubRule("Contacts", typeof(G61_Contact), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(LH6_HazardousCertification));
         contactRule.AddSubRule("Hazmat", typeof(LH1_HazardousIdentificationInformation), typeof(LH2_HazardousClassificationInformation), typeof(LH3_HazardousMaterialShippingNameInformation), typeof(LFH_FreeFormHazardousMaterialInformation), typeof(LEP_EPARequiredData), typeof(LH4_CanadianDangerousRequirements), typeof(LHT_TransborderHazardousRequirements), typeof(L11_BusinessInstructionsAndReferenceNumber));

         //var groupReader = new GroupedSectionReader(section);
        //    var groupedSection = groupReader.Read(partyRules, detailRules);
    }
}