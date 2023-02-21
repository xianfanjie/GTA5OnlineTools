using System;
using System.IO;
using System.Collections.Generic;

namespace TestConsole;

internal class Program
{
    static void Main(string[] args)
    {
        //var process = Process.GetProcessById(12312);

        Console.WriteLine("操作结束，按任意键继续！");
        Console.ReadLine();
    }

    void Func()
    {
        // 2023/02/07   793
        var vehicles = Enum.GetValues(typeof(VehicleHash));
        Console.WriteLine($"载具数量：{vehicles.Length}");

        var path = "E:\\GTA5\\GTA5图片数据\\Vehicles\\20230205";
        var imgNames = new List<string>();
        foreach (var imgFile in Directory.GetFiles(path))
        {
            imgNames.Add(Path.GetFileNameWithoutExtension(imgFile));
        }

        foreach (var imgName in imgNames)
        {
            //Console.WriteLine(imgName);
        }

        foreach (VehicleHash vEnum in vehicles)
        {
            Console.WriteLine($"{vEnum} 0x{Joaat(vEnum.ToString()):X8}");
            //Console.WriteLine($"{vEnum}");
            //Console.WriteLine($"0x{Joaat(vEnum.ToString()):X8}");

            //Console.WriteLine($"{vEnum.ToString().ToUpper()} = 0x{Joaat(vEnum.ToString()):X8},");

            //var index = imgNames.IndexOf(vEnum.ToString());
            //if (index == -1)
            //{
            //    Console.WriteLine($"{vEnum}");
            //}
            //else
            //{
            //    Console.WriteLine($"{vEnum} {imgNames[index]}");
            //}
        }
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