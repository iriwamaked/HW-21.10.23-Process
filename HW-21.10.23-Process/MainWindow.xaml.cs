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
using System.Diagnostics;
using Microsoft.Win32;

namespace HW_21._10._23_Process
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tmp = 0;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void StartChildProcessToTask1(object sender, RoutedEventArgs e)
        {
            Process p1 = new Process();
            p1.StartInfo = new ProcessStartInfo("calc.exe");
            p1.Start();
            p1.WaitForExit();

            //MessageBox.Show($"{p1.ExitCode}");

            UpdateExitCode(p1.ExitCode);
        }

        private void UpdateExitCode(int exitCode)
        {
            Dispatcher.Invoke(() => ExitCode.Text = exitCode.ToString());
        }

        private void StartChildProcess1(object sender, RoutedEventArgs e)
        {
            Process childProcess = new Process();
            childProcess.StartInfo = new ProcessStartInfo("notepad.exe");
            childProcess.Start();
            Task.Delay(500);
            try
            {
                if (MessageBox.Show("Wait for process completion?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    childProcess.WaitForExit();
                }
                else
                {
                    childProcess.Kill();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                UpdateExitCode(childProcess.ExitCode);
                childProcess.Kill();
            }

        }

        //private void UpdateExitCode()
        //{
        //    Dispatcher.Invoke(() => ExitCode1.Text = childProcess.ExitCode.ToString());
        //}

        string selectedNumber1 = "";
        string selectedNumber2 = "";
        string selectedOperation = "";
        private void ButtonNumber_Click1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            selectedNumber1 += button.Content.ToString();
            ArgumentsForString.Text = $"Выбранные числа: {selectedNumber1}";
        }
        private void ButtonNumber_Click2(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            selectedNumber2 += button.Content.ToString();
            ArgumentsForString.Text = $"Выбранные числа: {selectedNumber1} {selectedNumber2}";
        }

        private void ButtonOperation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            selectedOperation = button.Content.ToString();
            ArgumentsForString.Text = $"Выбранные числа: {selectedNumber1} {selectedNumber2}, Операция: {selectedOperation}";
        }

        private void StartChildProcess2(object sender, RoutedEventArgs e)
        {
            Process p1 = new Process();
            p1.StartInfo = new ProcessStartInfo(@"..\..\..\..\ConsoleApp1\bin\Debug\ConsoleApp1.exe");
            p1.StartInfo.Arguments = $"{selectedNumber1} {selectedNumber2} {selectedOperation}";
            p1.Start();
        }

        string path = @"..\..\..\..\ConsoleApp2\Properties\bycicle.txt.txt";
        string word = "bicycle";
        private void Button_ClickToFile(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = ".txt files (*.txt) | *.txt";
                if (d.ShowDialog() == true)
                {
                    path = d.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_ClickToFind(object sender, RoutedEventArgs e)
        {
            Process p= new Process();
            p.StartInfo = new ProcessStartInfo(@"..\..\..\..\ConsoleApp2\bin\Debug\ConsoleApp2.exe");
            p.StartInfo.Arguments = $"{path} {word}";
            p.Start();
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            word= Input.Text;
        }
    }
}
