namespace My214Parser;

public class Generic214
{
    public string From { get; set; }
    public string To { get; set; }
    public string ReferenceIdentification { get; set; }
    public string ShipmentId { get; set; }
        
    //possible to have reference#s here
    public List<Transaction> Transactions { get; set; } = new();

    public DateTime ReceivedOn { get; set; }
        
}

public class Transaction
{
    public List<Pair> ReferenceNumbers { get; set; } = new();
    public List<Pair> MarksAndNumbers { get; set; } = new();
    public List<Update> Updates { get; set; } = new();
    public List<ShipmentWeightPackagingAndQuantityData> ShipmentWeightPackagingAndQuantityData { get; set; } = new();

    //weight/quantity here too

}

public class ShipmentWeightPackagingAndQuantityData
{
    public ItemWithQualifier<decimal?>? Weight { get; set; }
    public ItemWithQualifier<decimal?>? Volume { get; set; }
    public ItemWithQualifier<int?>? Quantity { get; set; }
}

public class ItemWithQualifier<T>
{
    public T Item { get; set; }
    public string Qualifier { get; set; }

    public ItemWithQualifier(T item, string qualifier)
    {
        Item = item;
        Qualifier = qualifier;
    }
}

public class Update
{
    public string StatusCode { get; set; }
    public string AppointmentCode { get; set; }
    public DateTime EventDate { get; set; }

    public Location? Location { get; set; }
    public string EquipmentNumber { get; set; }
}

public class Location
{
    public string City { get; set; }
    public string StateProvinceCode { get; set; }
    public string CountryCode { get; set; }
}