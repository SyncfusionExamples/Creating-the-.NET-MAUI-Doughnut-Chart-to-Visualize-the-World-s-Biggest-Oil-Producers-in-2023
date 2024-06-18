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
                //new SolidColorBrush(Color.FromArgb("#583101")),
                //new SolidColorBrush(Color.FromArgb("#603808")),
                //new SolidColorBrush(Color.FromArgb("#6f4518")),
                //new SolidColorBrush(Color.FromArgb("#8b5e34")),
                //new SolidColorBrush(Color.FromArgb("#a47148")),
                //new SolidColorBrush(Color.FromArgb("#bc8a5f")),
                //new SolidColorBrush(Color.FromArgb("#d4a276")),
                //new SolidColorBrush(Color.FromArgb("#e7bc91")),
                //new SolidColorBrush(Color.FromArgb("#f3d5b5")),
                //new SolidColorBrush(Color.FromArgb("#FFEDD8"))

                //new SolidColorBrush(Color.FromArgb("#797D62")),
                //new SolidColorBrush(Color.FromArgb("#9B9B7A")),
                //new SolidColorBrush(Color.FromArgb("#BAA587")),
                //new SolidColorBrush(Color.FromArgb("#D9AE94")),
                //new SolidColorBrush(Color.FromArgb("#F1DCA7")),
                //new SolidColorBrush(Color.FromArgb("#FFCB69")),
                //new SolidColorBrush(Color.FromArgb("#E8AC65")),
                //new SolidColorBrush(Color.FromArgb("#D08C60")),
                //new SolidColorBrush(Color.FromArgb("#B58463")),
                //new SolidColorBrush(Color.FromArgb("#997B66"))

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
