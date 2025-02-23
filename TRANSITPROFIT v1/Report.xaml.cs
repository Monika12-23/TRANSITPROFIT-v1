using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
namespace TRANSITPROFIT_v1;

public partial class Report : ContentPage
{
    public ObservableCollection<ReportModel> ReportData { get; set; }
    public ObservableCollection<ReportModel> FilteredReportData { get; set; }

    public Report()
    {
        InitializeComponent();
        LoadReportData();
        BindingContext = this;
    }
    private void LoadReportData()
    {
        ReportData = new ObservableCollection<ReportModel>
            {
                new ReportModel { Date = "2024/03/12", Name = "DRIVER 1", Type = "Fare Collection", Description = "Recorded fare collection data for FIRST TRIP." },
                new ReportModel { Date = "2024/03/12", Name = "DRIVER 2", Type = "Maintenance Report", Description = "Reported vehicle issue (brake system) and requested maintenance." },
                new ReportModel { Date = "2024/03/12", Name = "DRIVER 3", Type = "Fueling", Description = "Logged refueling details: 40 liters of diesel for Unit EURO-03." },
                new ReportModel { Date = "2024/03/12", Name = "DRIVER 4", Type = "Fare Collection", Description = "Recorded fare collection data for FIRST TRIP." },
                new ReportModel { Date = "2024/03/12", Name = "DRIVER 5", Type = "Fare Collection", Description = "Recorded fare collection data for FIRST TRIP." },
                new ReportModel { Date = "2024/03/12", Name = "DRIVER 3", Type = "Fueling", Description = "Logged refueling details: 40 liters of diesel for Unit EURO-03." }
            };

        FilteredReportData = new ObservableCollection<ReportModel>(ReportData);
        ReportCollectionView.ItemsSource = FilteredReportData;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue.ToLower();
        FilteredReportData.Clear();

        foreach (var item in ReportData.Where(r =>
            r.Name.ToLower().Contains(searchText) ||
            r.Type.ToLower().Contains(searchText) ||
            r.Description.ToLower().Contains(searchText)))
        {
            FilteredReportData.Add(item);
        }
    }
}

public class ReportModel
{
    public string Date { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}
