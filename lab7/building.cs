namespace cs_labs.lab7;

using System;

class Building
{
    private static int lastBuildingNumber = 1000; // Последний использованный номер здания
    private int buildingNumber; // Уникальный номер здания
    private double height; // Высота здания
    private int floors; // Этажность
    private int apartmentsCount; // Количество квартир
    private int entrances; // Количество подъездов

    // Конструктор класса
    public Building(double height, int floors, int apartmentsCount, int entrances)
    {
        this.buildingNumber = GenerateBuildingNumber();
        this.height = height;
        this.floors = floors;
        this.apartmentsCount = apartmentsCount;
        this.entrances = entrances;
    }

    // Метод для генерации уникального номера здания
    private static int GenerateBuildingNumber()
    {
        lastBuildingNumber++;
        return lastBuildingNumber;
    }

    // Метод для вывода информации о здании
    public void PrintBuildingInfo()
    {
        Console.WriteLine($"Здание #{buildingNumber}");
        Console.WriteLine($"Высота: {height} м");
        Console.WriteLine($"Этажность: {floors} этажей");
        Console.WriteLine($"Количество квартир: {apartmentsCount}");
        Console.WriteLine($"Количество подъездов: {entrances}");
    }

    // Методы для вычисления различных характеристик здания
    public double CalculateFloorHeight()
    {
        return height / floors;
    }

    public int CalculateApartmentsPerEntrance()
    {
        return apartmentsCount / entrances;
    }

    public int CalculateApartmentsPerFloor()
    {
        return apartmentsCount / floors;
    }

}
