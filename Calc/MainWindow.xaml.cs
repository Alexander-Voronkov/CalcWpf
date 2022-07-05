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
using System.Data;

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string prev = "";
        bool flag = false;
        public MainWindow()
        {
            InitializeComponent();
            Current.Text = prev;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                string op = ((sender as Button).Content as string);
                if (prev.Length != 0 && (op == "*" || op == "/") && op == prev[prev.Length - 1].ToString())
                    return;
                if (Current.Text.Length == 0 && (op == "*" || op == "/"))
                    return;
                if (op != "CE" && op != "C" && op != "<" && op != "=")
                {
                    if (prev.Length > 0)
                    {
                        if (prev.Contains('='))
                        { 
                            prev = "";
                            Previous.Text = "";
                            Current.Text = "";
                        }
                    }
                    prev += Current.Text;
                    Current.Text = op;
                    Previous.Text = prev;
                }
                else if (op == "=")
                {
                    if (prev.Length > 0)
                    {
                        if (prev[prev.Length - 1] == '=')
                            return;
                    }
                    if (prev.Length != 0 && (op == "*" || op == "/") && (prev[prev.Length - 1].ToString()=="+"|| prev[prev.Length - 1].ToString() == "-"|| prev[prev.Length - 1].ToString() == "*"|| prev[prev.Length - 1].ToString() == "/"))
                        return;
                    prev +=Current.Text;
                    Current.Text = new DataTable().Compute(prev, "").ToString();
                    prev += "=";
                    Previous.Text = prev;
                }
                else if (op == "CE")
                {
                    prev = "";
                    Current.Text = "";
                }
                else if (op == "C")
                {
                    prev = "";
                    Current.Text = "";
                    Previous.Text = prev;
                }
                else if (op == "<")
                {
                    if (prev.Length == 0)
                        return;
                    else
                    {
                        Current.Text = prev[prev.Length - 1].ToString();
                        prev = prev.Remove(prev.Length - 1, 1);
                    }
                }
            }
        }
    }
}
