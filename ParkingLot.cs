using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingLot
{
    private List<ParkingSlot> slots;

    public ParkingLot(int size)
    {
        slots = new List<ParkingSlot>(size);
        for (int i = 1; i <= size; i++)
        {
            slots.Add(new ParkingSlot { SlotNumber = i });
        }
    }

    public void Park(Vehicle vehicle)
    {
        var slot = slots.FirstOrDefault(s => s.IsAvailable);
        if (slot == null)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }
        slot.Vehicle = vehicle;
        Console.WriteLine($"Allocated slot number: {slot.SlotNumber}");
    }

    public void Leave(int slotNumber)
    {
        var slot = slots.FirstOrDefault(s => s.SlotNumber == slotNumber);
        if (slot != null && slot.Vehicle != null)
        {
            slot.Vehicle = null;
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
        foreach (var slot in slots.Where(s => !s.IsAvailable))
        {
            var vehicle = slot.Vehicle;
            if (vehicle != null)
            {
                Console.WriteLine($"{slot.SlotNumber}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.RegistrationNumber}\t{vehicle.Color}");
            }
        }
    }

    public void ReportVehicleCountByType(string type)
    {
        var count = slots.Count(s => s.Vehicle?.Type == type);
        Console.WriteLine(count);
    }

   public void ReportVehicleNumbersByPlateType(bool odd)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var vehicles = slots
            .Where(s => s.Vehicle != null && IsOddPlate(s.Vehicle.RegistrationNumber) == odd)
            .Select(s => s.Vehicle.RegistrationNumber);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        Console.WriteLine(string.Join(", ", vehicles));
    }

    public void ReportVehicleNumbersByColor(string color)
    {
        var vehicles = slots
            .Where(s => s.Vehicle != null && s.Vehicle.Color == color)
            .Select(s => s.Vehicle?.RegistrationNumber);

        Console.WriteLine(string.Join(", ", vehicles));
    }

    public void ReportSlotNumbersByColor(string color)
    {
        var slotsWithColor = slots
            .Where(s => s.Vehicle != null && s.Vehicle.Color == color)
            .Select(s => s.SlotNumber);

        Console.WriteLine(string.Join(", ", slotsWithColor));
    }

    public void ReportSlotNumberByRegistration(string registrationNumber)
    {
        var slot = slots.FirstOrDefault(s => s.Vehicle?.RegistrationNumber == registrationNumber);
        if (slot == null)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(slot.SlotNumber);
        }
    }

    private bool IsOddPlate(string? registrationNumber)
    {
        if (string.IsNullOrEmpty(registrationNumber))
        {
            return false; // Default to false if the registration number is null or empty
        }

        var numberPart = new string(registrationNumber.Where(char.IsDigit).ToArray());
        if (numberPart.Length == 0)
        {
            return false;
        }
        
        var lastDigit = int.Parse(numberPart.Last().ToString());
        return lastDigit % 2 != 0;
    }
}
