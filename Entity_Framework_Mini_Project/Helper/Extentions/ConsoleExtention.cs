namespace Entity_Framework_Mini_Project.Helper.Extentions
{
    public static class ConsoleExtention
    {
        public static void WriteConsole(this ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
