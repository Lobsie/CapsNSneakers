using Imi.Project.Api.Wpf.ApiModels.Caps;
using Imi.Project.Api.Wpf.Services.ApiService.Caps;
using System.Windows;

namespace Imi.Project.Api.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICapApiService _capService;

        public MainWindow(ICapApiService capService)
        {
            InitializeComponent();
            _capService = capService;
        }

        private async void PopulateCapsInListbox()
        {
            lstCaps.Items.Clear();

            var caps = await _capService.GetAllCaps();

            foreach (var cap in caps.Data)
            {
                lstCaps.Items.Add(cap);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCapsInListbox();
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstCaps.SelectedItem is null)
                MessageBox.Show("Please select a cap to delete");

            if (lstCaps.SelectedItem is CapResponseModel cap)
            {
                await _capService.DeleteCap(cap.Id);
                PopulateCapsInListbox();
            }
        }

        private void LstCaps_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            GetCapDetail();
        }

        private async void GetCapDetail()
        {
            if (lstCaps.SelectedItem is null)
                MessageBox.Show("Please select a cap to get details for");

            if (lstCaps.SelectedItem is CapResponseModel cap)
            {
                var response = await _capService.GetCap(cap.Id);

                txtName.Text = response.Name;
                txtColorway.Text = response.Colorway;
                txtMaterial.Text = response.Material;
            }
        }
    }
}