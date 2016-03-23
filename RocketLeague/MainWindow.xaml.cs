using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using RocketLeague.utils;

namespace RocketLeague
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public int headerSize;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ReplayParser parser = new ReplayParser();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                headerSize = ConvertTo.GetIntFromStream(fs);

                ConvertTo.GetBytesFromStream(fs, 12);

                while (parser.readedBytes < headerSize - 16)
                    parser.ParseHeader(fs);

                parser.setAll();

                fs.Close();
            }
        }
    }
}
