using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OilProductionChart
{
    public class WorldOilProduction : INotifyPropertyChanged
    {
        public List<OilProductionModel> ProductionDetails { get; set; }
        public List<Brush> PaletteBrushes { get; set; }

        private double productionValue;
        public double ProductionValue
        {
            get
            {
                return productionValue;
            }
            set
            {
                productionValue = value;
                NotifyPropertyChanged(nameof(ProductionValue));
            }

        }

        private string countryName;
        public string CountryName
        {
            get
            {
                return countryName;
            }
            set
            {
                countryName = value;
                NotifyPropertyChanged(nameof(CountryName));
            }

        }

        int explodeIndex = 1;
        public int ExplodeIndex
        {
            get
            {
                return explodeIndex;
            }
            set
            {
                explodeIndex = value;
                UpdateIndexValues(value);
                NotifyPropertyChanged(nameof(ExplodeIndex));
            }
        }

        public WorldOilProduction()
        {
            ProductionDetails = new List<OilProductionModel>(ReadCSV());

            PaletteBrushes = new List<Brush>
            {
                new SolidColorBrush(Color.FromArgb("#9b2226")),
                new SolidColorBrush(Color.FromArgb("#ae2012")),
                new SolidColorBrush(Color.FromArgb("#bb3e03")),
                new SolidColorBrush(Color.FromArgb("#ca6702")),
                new SolidColorBrush(Color.FromArgb("#ee9b00")),
                new SolidColorBrush(Color.FromArgb("#e9d8a6")),
                new SolidColorBrush(Color.FromArgb("#94d2bd")),
                new SolidColorBrush(Color.FromArgb("#0a9396")),
                new SolidColorBrush(Color.FromArgb("#005f73")),
                new SolidColorBrush(Color.FromArgb("#BF001219"))
            };
        }

        public IEnumerable<OilProductionModel> ReadCSV()
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = executingAssembly.GetManifestResourceStream("OilProductionChart.Resources.Raw.data.csv");

            string? line;
            List<string> lines = new List<string>();

            using StreamReader reader = new StreamReader(inputStream);
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                return new OilProductionModel(data[1], Convert.ToDouble(data[2]), data[3]);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateIndexValues(int value)
        {
            if (value >= 0 && value < ProductionDetails.Count)
            {
                var model = ProductionDetails[value];
                if (model != null && model.Country != null)
                {
                    ProductionValue = model.Production;
                    CountryName = model.Country;
                }
            }        
        }

    }
}
