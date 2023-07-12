using System;
using System.Drawing;

class Programm
{
    static (string Name, string LName, int Age, bool Pet, int PetNum, string[] PetNames, int ColorsNum, string[] Favcolors) EnterUser()
    {
        (string Name, string LName, int Age, bool Pet, int PetNum, string[] PetNames, int ColorsNum, string[] Favcolors) User;


        Console.Write("Введите имя: ");
        User.Name = Console.ReadLine();


        Console.Write("Введите фамилию: ");
        User.LName = Console.ReadLine();


        string age;
        do
        {
            Console.WriteLine("Введите возраст цифрами: ");
            age = Console.ReadLine();
        }
        while (ControlAgePet(age, out User.Age));


        Console.Write("Есть ли у вас животные? (да/нет): ");
        string apet = Console.ReadLine();
        switch (apet)
        {
            case "да":
                User.Pet = true;
                string pet;
                do
                {
                    Console.Write("Сколько у Вас питомцев? (введите цифрами): ");
                    pet = Console.ReadLine();
                }
                while (ControlAgePet(pet, out User.PetNum));
                Console.WriteLine("Как зовут вашего питомца(ев)?");
                User.PetNames = Mass(User.PetNum);
                break;

            default:
                User.Pet = false;
                User.PetNum = 0;
                User.PetNames = Mass(0);
                break;
        }


        string acolor;
        do
        {
            Console.Write("Сколько у вас любимых цветов?(введите цифрами): ");
            acolor = Console.ReadLine();
        }
        while (ControlColor(acolor, out User.ColorsNum));
        if (User.ColorsNum != 0)
        {
            Console.WriteLine("Введите ваши любимые цвета:");
            User.Favcolors = Mass(User.ColorsNum);
        }
        else
        {
            User.ColorsNum = 0;
            User.Favcolors = Mass(0);

        }
        return User;
    }


    static bool ControlAgePet(string number, out int prchislo)
    {
        bool ok = int.TryParse(number, out int chislo);
        if (ok)
        {
            if (chislo > 0)
            {
                prchislo = chislo;
                return false;
            }
        }
        Console.WriteLine("Введено некорректное значение!");
        prchislo = 0;
        return true;
    }


    static bool ControlColor(string number, out int prchislo)
    {
        bool ok = int.TryParse(number, out int chislo);
        if (ok)
        {
            if (chislo >= 0)
            {
                prchislo = chislo;
                return false;
            }
        }
        Console.WriteLine("Введено некорректное значение!");
        prchislo = 0;
        return true;
    }


    static string[] Mass(int num)
    {
        string[] arr = new string[num];
        for (int i = 0; i < num; i++)
            arr[i] = Console.ReadLine();
        return arr;
    }


    static void PrintUser((string Name, string LName, int Age, bool Pet, int PetNum, string[] PetNames, int ColorsNum, string[] Favcolors) User)
    {
        Console.WriteLine($"Вас зовут: {User.Name}");
        Console.WriteLine($"Ваша фамилия: {User.LName}");
        Console.WriteLine($"Ваш возраст: {User.Age}");
        if (User.Pet)
        {
            Console.WriteLine("Ваших питомцев зовут:");
            foreach (string x in User.PetNames)
                Console.WriteLine(x);
        }
        else
        {
            Console.WriteLine("У вас нет питомцев");
        }
        if (User.ColorsNum > 0)
        {
            Console.WriteLine("Ваши любимые цвета:");
            foreach (string x in User.Favcolors)
                Console.WriteLine(x);
        }
        else
            Console.WriteLine("У вас нет любимых цветов");

    }

    public static void Main(string[] args)
    {
        PrintUser(EnterUser());
        Console.ReadKey();



    }
}