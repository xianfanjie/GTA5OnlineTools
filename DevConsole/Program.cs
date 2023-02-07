using System;

namespace DevConsole;

internal class Program
{
    static void Main(string[] args)
    {
        // 2023/02/07   793
        var vehicles = Enum.GetValues(typeof(VehicleHash));
        Console.WriteLine($"载具数量：{vehicles.Length}");

        foreach (VehicleHash vEnum in vehicles)
        {
            //Console.WriteLine($"{vEnum} 0x{Joaat(vEnum.ToString()):X8}");
            //Console.WriteLine($"{vEnum}");
            //Console.WriteLine($"0x{Joaat(vEnum.ToString()):X8}");

            Console.WriteLine($"{vEnum.ToString().ToUpper()} = 0x{Joaat(vEnum.ToString()):X8},");
        }

        Console.WriteLine("操作结束，按任意键继续！");
        Console.ReadLine();
    }

    static uint Joaat(string input)
    {
        uint num1 = 0U;
        input = input.ToLower();
        foreach (char c in input)
        {
            uint num2 = num1 + c;
            uint num3 = num2 + (num2 << 10);
            num1 = num3 ^ num3 >> 6;
        }
        uint num4 = num1 + (num1 << 3);
        uint num5 = num4 ^ num4 >> 11;

        return num5 + (num5 << 15);
    }
}