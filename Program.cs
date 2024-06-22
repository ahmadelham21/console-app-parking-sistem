using System;

public class Program
{
    static void Main(string[] args)
    {
        ParkingLot? parkingLot = null;

        while (true)
        {
            var input = Console.ReadLine();
            if (input == null) continue;

            var command = input.Split(' ');
            switch (command[0])
            {
                case "create_parking_lot":
                    int size = int.Parse(command[1]);
                    parkingLot = new ParkingLot(size);
                    Console.WriteLine($"Created a parking lot with {size} slots");
                    break;

                case "park":
                    if (parkingLot == null) break;

                    string registrationNumber = command[1];
                    string color = command[2];
                    string type = command[3];

                    Vehicle? vehicle = type switch
                    {
                        "Mobil" => new Car { RegistrationNumber = registrationNumber, Color = color },
                        "Motor" => new Motorcycle { RegistrationNumber = registrationNumber, Color = color },
                        _ => null
                    };

                    if (vehicle != null)
                    {
                        parkingLot.Park(vehicle);
                    }
                    break;

                case "leave":
                    if (parkingLot == null) break;

                    int slotNumber = int.Parse(command[1]);
                    parkingLot.Leave(slotNumber);
                    break;

                case "status":
                    if (parkingLot == null) break;
                    parkingLot.Status();
                    break;

                case "type_of_vehicles":
                    if (parkingLot == null) break;
                    parkingLot.ReportVehicleCountByType(command[1]);
                    break;

                case "registration_numbers_for_vehicles_with_ood_plate":
                    if (parkingLot == null) break;
                    parkingLot.ReportVehicleNumbersByPlateType(true);
                    break;

                case "registration_numbers_for_vehicles_with_event_plate":
                    if (parkingLot == null) break;
                    parkingLot.ReportVehicleNumbersByPlateType(false);
                    break;

                case "registration_numbers_for_vehicles_with_colour":
                    if (parkingLot == null) break;
                    parkingLot.ReportVehicleNumbersByColor(command[1]);
                    break;

                case "slot_numbers_for_vehicles_with_colour":
                    if (parkingLot == null) break;
                    parkingLot.ReportSlotNumbersByColor(command[1]);
                    break;

                case "slot_number_for_registration_number":
                    if (parkingLot == null) break;
                    parkingLot.ReportSlotNumberByRegistration(command[1]);
                    break;

                case "exit":
                    return;
            }
        }
    }
}
