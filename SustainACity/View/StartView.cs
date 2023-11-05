namespace SustainACity.View;

public class StartView
{
    private int _currentSelection = 0; // 0 for start, 1 for exit
    private readonly string[] _menuItems = { "Start", "Exit" };
    private readonly string _logo = "███████╗██╗   ██╗███████╗████████╗ █████╗ ██╗███╗   ███╗     █████╗      ██████╗██╗████████╗██╗   ██╗\n" +
                                     "██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔══██╗██║██╔██╗ ██╔╝    ██╔══██╗    ██╔════╝██║╚══██╔══╝╚██╗ ██╔╝\n" +
                                     "███████╗██║   ██║███████╗   ██║   ███████║██║██║╚██╗██║     ███████║    ██║     ██║   ██║    ╚████╔╝ \n" +
                                     "╚════██║██║   ██║╚════██║   ██║   ██╔══██║██║██║ ╚████║     ██╔══██║    ██║     ██║   ██║     ╚██╔╝  \n" +
                                     "███████║╚██████╔╝███████║   ██║   ██║  ██║██║██║  ╚███║     ██║  ██║    ╚██████╗██║   ██║      ██║   \n" +
                                     "╚══════╝ ╚═════╝ ╚══════╝   ╚═╝   ╚═╝  ╚═╝╚═╝╚═╝   ╚══╝     ╚═╝  ╚═╝     ╚═════╝╚═╝   ╚═╝      ╚═╝   \n";

    public void Show()
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.Clear();
            CenterText(_logo + "\n\n");
            DrawMenu();
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    _currentSelection--;
                    if (_currentSelection < 0) _currentSelection = _menuItems.Length - 1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    _currentSelection++;
                    if (_currentSelection > _menuItems.Length - 1) _currentSelection = 0;
                    break;
                case ConsoleKey.Enter:
                    ExecuteSelectedItem();
                    return; // Exit the Show method after executing an item.
            }

        } while (keyInfo.Key != ConsoleKey.Escape);

        Environment.Exit(0); // Exit the application if Escape is pressed.
    }

    private void DrawMenu()
    {
        for (int i = 0; i < _menuItems.Length; i++)
        {
            if (i == _currentSelection)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            // Get the centered position based on the longest line of the logo
            int centerPosition = (Console.WindowWidth / 2) - (_menuItems[i].Length / 2);
            Console.SetCursorPosition(centerPosition, Console.CursorTop);
            Console.WriteLine(_menuItems[i]);
            Console.ResetColor();
        }
    }

    private void ExecuteSelectedItem()
    {
        switch (_currentSelection)
        {
            case 0: // Start game
                Console.Clear();
                break;
            case 1: // Exit
                Environment.Exit(0);
                break;
        }
    }

    private void CenterText(string text)
    {
        string[] lines = text.Split('\n');
        int longestLine = lines.Max(line => line.Length);
        int verticalStart = (Console.WindowHeight - lines.Length) / 2;
        int verticalPosition = verticalStart;

        foreach (string line in lines)
        {
            Console.SetCursorPosition((Console.WindowWidth - longestLine) / 2, verticalPosition++);
            Console.WriteLine(line);
        }
    }
}