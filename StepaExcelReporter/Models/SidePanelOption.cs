using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StepaExcelReporter.Models
{
    public class SidePanelOption
    {
        public string Title {  get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        SidePanelOption() { }
    }
    public class OptionsCollection : ObservableCollection<SidePanelOption> { }
}
