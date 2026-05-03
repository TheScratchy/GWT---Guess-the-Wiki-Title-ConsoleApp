namespace GWT_ConsoleApp.Helpers
{
    public static class ConsoleEx
    {
        public static bool HasTrueConsole =>
            !Console.IsOutputRedirected &&
            !Console.IsErrorRedirected &&
            !Console.IsInputRedirected;
        public static void ClearScreen()
        {
            if (!HasTrueConsole)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                return;
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth * Console.WindowHeight));
            Console.SetCursorPosition(0, 0);
        }
    }
}