using System.Reflection;

namespace OilProductionChart
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

#if ANDROID || IOS
            HorizontalStackLayout horizontalStackLayout = new HorizontalStackLayout();

            Image image = new Image
            {
                Source = "oil.png",
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
            };

            Label title = new Label
            {
                Text = "The World's Biggest Oil Producers in 2023",
                TextColor = Colors.Black,
                FontFamily = "centurygothic",
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
            };
            horizontalStackLayout.Children.Add(image);
            horizontalStackLayout.Children.Add(title);
            chart.Title = horizontalStackLayout;
#endif
        }

    }

}
