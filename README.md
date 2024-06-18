# Creating-the-.NET-MAUI-Pie-Chart-to-Visualize-the-World-s-Biggest-Oil-Producers-in-2023
This sample demonstrates how to create a .NET MAUI Doughnut Chart to Visualize The World's Biggest Oil Producers in 2023

## Doughnut chart
Doughnut chart is used to show the relationship between parts of data and whole data. To render a [DoughnutSeries](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.DoughnutSeries.html) in circular chart, create an instance of the DoughnutSeries and add it to the Series collection property of [SfCircularChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCircularChart.html).

## Customize the doughnut chart
we customize the doughnut segment color, border, and width and group the data points less than the specific value using the [PaletteBrushes](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_PaletteBrushes), [Stroke](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.CircularSeries.html#Syncfusion_Maui_Charts_CircularSeries_Stroke), and [StrokeWidth](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.CircularSeries.html#Syncfusion_Maui_Charts_CircularSeries_StrokeWidth) properties, respectively.

We can also modify the start and end positions of a segment in the chart using the StartAngle and EndAngle properties.

Customize the CenterView
Any view can be added to the center of the doughnut chart using the [CenterView](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.DoughnutSeries.html#Syncfusion_Maui_Charts_DoughnutSeries_CenterView) property of [DoughnutSeries](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.DoughnutSeries.html). The view placed in the center of the doughnut chart is useful for sharing additional information about the doughnut chart. The binding context of the CenterView will be the respective doughnut series.

## Output

![DoughnutChartOutput](https://github.com/essential-studio/maui-charts/assets/126754274/9ef45c42-6da6-4fd3-87e8-29cf1b6564a8)