using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpreadsheetLight;
using StepaExcelReporter.Components;

namespace StepaExcelReporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class InternalDataContext
        {
            public Uri? ExcelFilePath { get; set; }
            public string XpsTempFIleName { get; set; }
            public InternalDataContext() {
                XpsTempFIleName = "tempXpsFile";
            }
        }
        private readonly InternalDataContext _internalDataContext;
        public MainWindow()
        {
            InitializeComponent();
            _internalDataContext = new InternalDataContext();
            this.DataContext = new InternalDataContext();
        }

        private void mw_explore_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".xlsx"; // Default file extension
            dialog.Filter = "Excel Files (.xlsx)|*.xlsx";
            //"Text documents (.txt)|*.txt"
            bool? result = dialog.ShowDialog();

            if (result == true) {
                _internalDataContext.ExcelFilePath= new Uri(dialog.FileName);
                string filename = dialog.FileName;
                using (SLDocument Doc = new SLDocument(filename))
                {
                    bool sheetExists = Doc.SelectWorksheet("excel");

                    if (sheetExists == true)
                    {
                        var selectedString = Doc.GetCellValueAsString("A2");
                    }

                }
                //mw_docview.Path = dialog.FileName;
            }
        }
    }
}