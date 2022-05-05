namespace projeto_integrador.Configuration
{
    public class AppSettings
    {
        public static AppSettings Current { get; private set; }

        public AppSettings()
        {
            Current = this;
        }


    }
}
