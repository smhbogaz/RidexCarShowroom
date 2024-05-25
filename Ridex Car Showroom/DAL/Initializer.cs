namespace Ridex_Car_Showroom.DAL
{
    public class Initializer
    {


        public static IConfigurationRoot Configuration
        {
            get
            {

                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                    AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true);

                return builder.Build();
            }
        }
    }
}
