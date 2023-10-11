namespace cs_labs.lab3;

using System;

enum VUZ
{
    KGU,
    KAI,
    KHTI
}

// Определение структуры работника
struct Worker
{
    public string Name;
    public VUZ University;
}


class Task{
    public static void T1() {
        Worker worker1 = new Worker
        {
            Name = "Иван",
            University = VUZ.KGU
        };

        Worker worker2 = new Worker
        {
            Name = "Мария",
            University = VUZ.KAI
        };

        Worker worker3 = new Worker
        {
            Name = "Петр",
            University = VUZ.KHTI
        };

        // Печать данных о работниках
        Console.WriteLine("Имя работника: " + worker1.Name + ", ВУЗ: " + worker1.University);
        Console.WriteLine("Имя работника: " + worker2.Name + ", ВУЗ: " + worker2.University);
        Console.WriteLine("Имя работника: " + worker3.Name + ", ВУЗ: " + worker3.University);
    }
}