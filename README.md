# Console Parking System

A simple console-based parking system built using .NET 5. This application manages parking slots for cars and motorcycles. Each slot can hold either a car or a motorcycle, and each person is allowed one slot.

## Features

- Create a parking lot with a specified number of slots.
- Park a car or motorcycle in an available slot.
- Remove a vehicle from a slot, making it available for others.
- View the current status of all parking slots.
- Generate reports on:
  - Number of vehicles by type.
  - Number of vehicles with odd or even registration plates.
  - Number of vehicles by color.
  - Slot numbers by vehicle color.
  - Slot number for a specific registration number.

## Commands

### Create a Parking Lot

Create a parking lot with a specified number of slots.

```sh
create_parking_lot <number_of_slots>

```

### Example

```sh
$ create_parking_lot 6
Created a parking lot with 6 slots

$ park B-1234-XYZ Putih Mobil
Allocated slot number: 1

$ park B-9999-XYZ Putih Motor
Allocated slot number: 2

$ park D-0001-HIJ Hitam Mobil
Allocated slot number: 3

$ leave 2
Slot number 2 is free

$ status
Slot   No.          Type     Registration No   Colour
1      B-1234-XYZ   Mobil    B-1234-XYZ        Putih
3      D-0001-HIJ   Mobil    D-0001-HIJ        Hitam

$ type_of_vehicles Mobil
4

$ registration_numbers_for_vehicles_with_ood_plate
B-1234-XYZ, D-0001-HIJ

$ registration_numbers_for_vehicles_with_event_plate
B-9999-XYZ

$ registration_numbers_for_vehicles_with_colour Putih
B-1234-XYZ

$ slot_numbers_for_vehicles_with_colour Hitam
3

$ slot_number_for_registration_number B-1234-XYZ
1

$ exit

```

