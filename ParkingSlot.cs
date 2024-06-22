public class ParkingSlot
{
    public int SlotNumber { get; set; }
    public Vehicle? Vehicle { get; set; }  // Vehicle can be null
    public bool IsAvailable => Vehicle == null;
}
