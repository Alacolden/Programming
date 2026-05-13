using System;
using System.Collections.Generic;
using Laba1;

namespace Laba1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ComputerTechnology> compTechList = new List<ComputerTechnology>();

            while (true)
            {
                Console.WriteLine("What object do you want to make?\n1 - Computer technology\n2 - Monitor\n3 - Keyboard\n" +
                    "4 - Print objects\n5 - Exit");

                int input;
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Invalid input, enter a number 1-5.");
                    continue;
                }

                try
                {
                    switch (input)
                    {
                        case 1:
                            {
                                Console.Write("Enter manufacturer: ");
                                string manufacturer = Console.ReadLine();
                                compTechList.Add(new ComputerTechnology(manufacturer));
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter manufacturer, resolution (width, height), screen size and refresh rate:");
                                Console.Write("Manufacturer: ");
                                string manufacturer = Console.ReadLine();

                                Console.Write("Width resolution: ");
                                uint.TryParse(Console.ReadLine(), out uint widthResolution);

                                Console.Write("Height resolution: ");
                                uint.TryParse(Console.ReadLine(), out uint heigthResolution);

                                Console.Write("Screen size: ");
                                float.TryParse(Console.ReadLine(), out float screenSize);

                                Console.Write("Refresh rate: ");
                                int.TryParse(Console.ReadLine(), out int refreshRate);


                                compTechList.Add(new MonitorTech(manufacturer, new List<uint> { widthResolution, heigthResolution }, screenSize, refreshRate));
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter manufacturer, color, type of keys (membrane, mechanical or optical), connection type (wired or wireless) and whether there is a backlight (1 or 0):");

                                Console.Write("Manufacturer: ");
                                string manufacturer = Console.ReadLine();

                                Console.Write("Color: ");
                                string color = Console.ReadLine();

                                Console.Write("Keys type: ");
                                string keys = Console.ReadLine();

                                Console.Write("Connection type: ");
                                string connection = Console.ReadLine();

                                Console.Write("Has backlight (1 or 0): ");
                                string inputBacklight = Console.ReadLine();

                                if (inputBacklight != "1" && inputBacklight != "0")
                                {
                                    Console.WriteLine("Error: has backlight: enter only 1 or 0.");
                                    continue;
                                }

                                bool hasBacklight = inputBacklight == "1";


                                compTechList.Add(new Keyboard(manufacturer, color, keys, connection, hasBacklight));
                                break;
                            }
                        case 4:
                            {
                                if (!compTechList.Any()) // если список пустой, то выводим сообщение об этом
                                {
                                    Console.WriteLine("The list is empty.");
                                }
                                int i = 1;
                                foreach (var item in compTechList)
                                {
                                    Console.Write($"{i++}: ");
                                    item.Print();
                                }
                                break;
                            }
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Choose 1-5.");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
        }
    }
}
