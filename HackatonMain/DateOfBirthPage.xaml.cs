﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace HackatonMain
{
    /// <summary>
    /// Logique d'interaction pour DateOfBirthPage.xaml
    /// </summary>
    public partial class DateOfBirthPage : Page
    {
        DateOfBirthVm Vm { get => DataContext as DateOfBirthVm; set => DataContext = value; }
        public DateOfBirthPage()
        {
            InitializeComponent();
            DataContext = new DateOfBirthVm();
        }

        private void Add11Days(object sender, RoutedEventArgs e)
        {
            DateOfBirthVm vm = DataContext as DateOfBirthVm;
            vm.Date = vm.Date.AddDays(11);
            DataContext = vm;
            UpdateTargets();
        }
        private void Remove7Days(object sender, RoutedEventArgs e)
        {
            DateOfBirthVm vm = DataContext as DateOfBirthVm;
            vm.Date = vm.Date.AddDays(-7);
            DataContext = vm;
            UpdateTargets();
        }
        private void Add25Years(object sender, RoutedEventArgs e)
        {
            DateOfBirthVm vm = DataContext as DateOfBirthVm;
            vm.Date = vm.Date.AddYears(25);
            DataContext = vm;
            UpdateTargets();
        }
        private void Remove13Years(object sender, RoutedEventArgs e)
        {
            DateOfBirthVm vm = DataContext as DateOfBirthVm;
            vm.Date = vm.Date.AddYears(-13);
            DataContext = vm;
            UpdateTargets();
        }
        private void Add1Month(object sender, RoutedEventArgs e)
        {
            DateOfBirthVm vm = DataContext as DateOfBirthVm;
            vm.Date = vm.Date.AddMonths(1);
            DataContext = vm;
            UpdateTargets();
        }
        private void Remonve3Months(object sender, RoutedEventArgs e)
        {
            DateOfBirthVm vm = DataContext as DateOfBirthVm;
            vm.Date = vm.Date.AddMonths(-3);
            DataContext = vm;
            UpdateTargets();
        }
        private void UpdateTargets()
        {
            InputDay.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            InputMonth.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            InputYear.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(String.Format("That day was a {0}, right ?", Vm.Date.AddDays(new Random().Next(0, 6)).DayOfWeek.ToString()), "Confirmation",MessageBoxButton.YesNo) == MessageBoxResult.Yes
                || MessageBox.Show(String.Format("Really ? Hmm... Would you like to confirm anyways ? (May lead to issues down the line. Consider yourself warned)"), "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                MainWindowVM vm = mainWindow.DataContext as MainWindowVM;
                vm.DateOfBirth = Vm.Date;
                mainWindow._main.Navigate(new PhoneNumberPage());                
            }

        }
    }
    public class DateOfBirthVm
    {
        public DateTime Date { get; set; }

        public string Day { get => Date.Day.ToString("N2"); }
        public DateOfBirthVm()
        {
            Random rng = new Random();
            Date = new DateTime(1970 + rng.Next(-30, 38), rng.Next(1, 11), rng.Next(1, 28));
        }
    }
}
