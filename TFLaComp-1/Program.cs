namespace TFLaComp_1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ParserForm());
            //RegExCardParser cardParser = new RegExCardParser();
            //string text = "1234lkdfg 2222 2333 4444 5555 2222";
            //List<CardDTO> list = cardParser.Parse(text);
        }
    }
}