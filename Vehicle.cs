public abstract class Vehicle
{
    public string? RegistrationNumber { get; set; }
    public string? Color { get; set; }
    public abstract string Type { get; }
}

public class Car : Vehicle
{
    public override string Type => "Mobil";
}

public class Motorcycle : Vehicle
{
    public override string Type => "Motor";
}
