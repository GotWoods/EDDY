using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.DomainModels
{
    public class Edi214_TransportationCarrierShipmentStatusMessage
    {
        public DateTime CreationDate { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public List<Entity> Entities { get; set; } = new();
        //
        // public string AlternatePickupCarrierSCAC { get; set; }
        // public string BOL { get; set; }
        // public string CarrierInvoiceNumber { get; set; }
        // public string CarrierSCAC { get; set; }
        // public string CommercialInvoice { get; set; }
        // public string CorrelationId { get; set; }
        // public string ControlVersionID { get; set; }
        // public string DeliverySignatureName { get; set; }
        // public EdiCheckCallStatusUpdates EDICheckCallStatusUpdates { get; set; }
        // public string EquipmentType { get; set; }
        // public string LoadID { get; set; }
        // public string MessageDate { get; set; }
        // public string MessageID { get; set; }
        // public string MessageTime { get; set; }
        // public string PackingSlipNumber { get; set; }
        // public string ProNumber { get; set; }
        // public string PurchaseOrderNumber { get; set; }
        // public string ReceiverID { get; set; }
        // public string ReleaseNumber { get; set; }
        // public string SenderID { get; set; }
        // public string ShipFromAddress1 { get; set; }
        // public string ShipFromAddress2 { get; set; }
        // public string ShipFromCity { get; set; }
        // public string ShipFromCountry { get; set; }
        // public string ShipFromEntityName { get; set; }
        // public string ShipFromExternalEntityID { get; set; }
        // public string ShipFromPostalCode { get; set; }
        // public string ShipFromStateProvince { get; set; }
        // public string ShipToAddress1 { get; set; }
        // public string ShipToAddress2 { get; set; }
        // public string ShipToCity { get; set; }
        // public string ShipToCountry { get; set; }
        // public string ShipToEntityName { get; set; }
        // public string ShipToExternalEntityID { get; set; }
        // public string ShipToPostalCode { get; set; }
        // public string ShipToStateProvince { get; set; }
        // public string TotalCubicFeet { get; set; }
        // public string TotalCubicMeters { get; set; }
        // public string TotalKGSWeight { get; set; }
        // public string TotalLBSWeight { get; set; }
        // public string TotalQuantity { get; set; }
        // public string TrackNumber { get; set; }
        // public string TrailerNumber { get; set; }
        // public string TransportationMode { get; set; }
        // public string WeightQualifier { get; set; }
        public void Interpret(x12Document document)
        {
            //this.CreationDate = document.IsaInterchangeControlHeader.CreationDate;
            this.Sender = document.IsaInterchangeControlHeader.InterchangeSenderId;
            this.Receiver = document.IsaInterchangeControlHeader.InterchangeReceiverId;
            //document.IsaInterchangeControlHeader.
            // var equipmentLocation = document.Sections[0].Segments.Where(x => x.GetType() == typeof(MS1_EquipmentShipmentOrRealPropertyLocation));
            // var weight = document.Sections[0].Segments.Where(x => x.GetType() == typeof(AT8_ShipmentWeightPackagingAndQuantityData));

            var section = document.Sections[0]; //it is possible a document contains multiple instructions

            for (var rowIndex = 0; rowIndex < section.Segments.Count; rowIndex++)
            {
                var currentSegment = section.Segments[rowIndex];
                switch (currentSegment)
                {
                    case LX_TransactionSetLineNumber lx:
                        break;
                    case B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage b10:
                        break;
                    case MS3_InterlineInformation ms3:
                        break;
                    case N1_PartyIdentification n1:
                        var (contact, skipToRow) = ParseContact(section.Segments, rowIndex);
                        rowIndex = skipToRow;
                        Entities.Add(contact);
                        break;
                    case  AT7_ShipmentStatusDetails:
//AT7 loops 

                        break;
                }
            }
        }

        private (Entity entity, int index) ParseContact(List<EdiX12Segment> sectionSegments, int rowIndex)
        {
            var entity = new Entity();

            //start at the first N1
            for (var i = rowIndex; i < sectionSegments.Count; i++)
                switch (sectionSegments[i])
                {
                    case N1_PartyIdentification n1:
                        entity.EntityIdentifierCode = n1.EntityIdentifierCode;
                        entity.Name = n1.Name;
                        //n1 has more information in it but not sure if required
                        break;
                    case N2_AdditionalNameInformation n2:
                        //additional name is this used?
                        break;
                    case N3_PartyLocation n3: //n3 can be here twice so maybe an address3/address4?
                        entity.Address1 = n3.AddressInformation;
                        entity.Address2 = n3.AddressInformation2;
                        break;
                    case N4_GeographicLocation n4:
                        entity.City = n4.CityName;
                        entity.ProvinceState = n4.StateOrProvinceCode;
                        entity.Country = n4.CountryCode;
                        entity.PostalZip = n4.PostalCode;
                        break;
                    case L11_BusinessInstructionsAndReferenceNumber l11:
                        //TODO
                        break;
                    case G61_Contact g61: //there can be 3 of these
                        entity.AddContact(g61);
                        break;
                    default:
                        return (entity, i);
                }

            return (entity, rowIndex);
        }

        private (Entity entity, int index) ParseShipmentStatusDetails(List<EdiX12Segment> sectionSegments, int rowIndex)
        {
            var entity = new Entity();

            for (var i = rowIndex; i < sectionSegments.Count; i++)
                switch (sectionSegments[i])
                {
                    case AT7_ShipmentStatusDetails at7:
                        break;
                    case MS1_EquipmentShipmentOrRealPropertyLocation ms1:
                        break;
                    case MS2_EquipmentOrContainerOwnerAndType ms2: //there can be 2 of these
                        break;
                    case K1_Remarks k1:
                        break;
                    case M7_SealNumbers l11:
                        break;
                    default:
                        return (entity, i);
                }

            return (entity, rowIndex);
        }
    }
}
