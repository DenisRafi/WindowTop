/*
The following example demonstrates the WindowLeft,
WindowTop, WindowWidth, WindowHeight, BufferWidth, 
BufferHeight, and CursorVisible properties;
and the SetWindowPosition, SetBufferSize, and ReadKey methods.
The example draws a grid pattern in the screen buffer 
based on the screen buffer width. Then the example moves
the console window in response to which of the UP ARROW, DOWN ARROW, LEFT ARROW,
or RIGHT ARROW console keys is pressed.
 */
using System;
using System.Text;
using System.IO;

class ByDenisRafi
{
    public static int saveBufferWidth;
    public static int saveBufferHeight;
    public static int saveWindowHeight;
    public static int saveWindowWidth;
    public static bool saveCursorVisible;
    
    public static void Main()
    {
        Console.Title = "WindowTop";
        string m1 = "1) Press the cursor keys to move the console window.\n" +
                    "2) Press any key to begin. When you're finished...\n" +
                    "3) Press the Escape key to quit.";
        string g1 = "+----";
        string g2 = "|    ";
        string grid1;
        string grid2;
        StringBuilder sbG1 = new StringBuilder();
        StringBuilder sbG2 = new StringBuilder();
        ConsoleKeyInfo cki;
        int y;       
        try
        {
            saveBufferWidth = Console.BufferWidth;
            saveBufferHeight = Console.BufferHeight;
            saveWindowHeight = Console.WindowHeight;
            saveWindowWidth = Console.WindowWidth;
            saveCursorVisible = Console.CursorVisible;

            Console.Clear();
            Console.WriteLine(m1);
            Console.ReadKey(true);
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 80);
            Console.SetWindowSize(40, 20);
            for (y = 0; y < Console.BufferWidth / g1.Length; y++)
            {
                sbG1.Append(g1);
                sbG2.Append(g2);
            }
            sbG1.Append(g1, 0, Console.BufferWidth % g1.Length);
            sbG2.Append(g2, 0, Console.BufferWidth % g2.Length);
            grid1 = sbG1.ToString();
            grid2 = sbG2.ToString();
            Console.CursorVisible = false;
            Console.Clear();
            for (y = 0; y < Console.BufferHeight - 1; y++)
            {
                if (y % 3 == 0)
                    Console.Write(grid1);
                else
                    Console.Write(grid2);
            }
            Console.SetWindowPosition(0, 0);
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (Console.WindowLeft > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft - 1, Console.WindowTop);
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.WindowTop > 0)
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                            Console.SetWindowPosition(
                                    Console.WindowLeft + 1, Console.WindowTop);
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                            Console.SetWindowPosition(
                                    Console.WindowLeft, Console.WindowTop + 1);
                        break;
                }
            }
            while (cki.Key != ConsoleKey.Escape); 
        } 
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.Clear();
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(saveBufferWidth, saveBufferHeight);
            Console.SetWindowSize(saveWindowWidth, saveWindowHeight);
            Console.CursorVisible = saveCursorVisible;
        }
    } 
} 
