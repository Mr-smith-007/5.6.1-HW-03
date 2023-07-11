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
        while (ControlAge(age, out User.Age));


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
                while (ControlPF(pet, out User.PetNum));
                Console.WriteLine("Как зовут вашего питомца(ев)?");
                User.PetNames = Mass(User.PetNum);
                break;

            default:
                User.Pet = false;
                break;
        }


        string acolor;
        do
        {
            Console.Write("Сколько у вас любимых цветов?(введите цифрами): ");
            acolor = Console.ReadLine();
        }
        while (ControlPF(acolor, out User.ColorsNum));
        if (User.ColorsNum != 0)
        {
            Console.WriteLine("Введите ваши любимые цвета:");
            User.Favcolors = Mass(User.ColorsNum);
        }
        return User;
    }


    static bool ControlAge(string number, out int prchislo)
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


    static bool ControlPF(string number, out int prchislo)
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


    public static void Main(string[] args)
    {
        EnterUser();
        Console.ReadKey();



    }
}