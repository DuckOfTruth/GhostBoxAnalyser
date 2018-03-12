using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GhostBoxAnalyser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
            DataContext = gb;
        }

        private void Init()
        {
            // prepare radiotypes
            RadioType[] radioTypes = new RadioType[]
            {
                new RadioType(1, "FM"),
                new RadioType(2, "AM"),
                new RadioType(3, "USB"),
                new RadioType(4, "CW"),
                new RadioType(5, "LSB"),
                new RadioType(6, "AMsync")
            };
            radioTypeCb.ItemsSource = radioTypes;
            radioTypeCb.SelectedIndex = 0; // todo: fix this
        }

        GhostBox gb = new GhostBox();
    }
}
