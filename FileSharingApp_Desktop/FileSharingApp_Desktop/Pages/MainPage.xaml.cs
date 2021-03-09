﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FileSharingApp_Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private string DeviceIP;
        private string DeviceHostName;
        private List<string> FilePaths=new List<string>();
        public MainPage()
        {
            InitializeComponent();            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Main.OnClientRequested += Main_OnClientRequested;
            ShowFileList(false);
            if(Main.FilePaths!=null)
            {
                FilePaths = Main.FilePaths.ToList();
                ShowFileList(true);
                list_Files.ItemsSource = FilePaths;
            }
            else
            {
                FilePaths = new List<string>();
                ShowFileList(false);
            }
            if (!Parameters.DidInitParameters)
            {
                Parameters.Init();
                ScanNetwork();
            }
            NetworkScanner.GetDeviceAddress(out DeviceIP, out DeviceHostName);
            Main.FileSaveURL = Parameters.SavingPath;
            Debug.WriteLine("Save file path: " + Main.FileSaveURL);
            Dispatcher.Invoke(() =>
            {
                txt_DeviceIP.Content = DeviceIP;
                txt_DeviceName.Text = Parameters.DeviceName;
            });
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Main.OnClientRequested -= Main_OnClientRequested;
        }
        private void Main_OnClientRequested(string totalTransferSize, string deviceName)
        {
            /// Show file transfer request and ask for permission here
            Debug.WriteLine(deviceName + " wants to send you files: " + totalTransferSize + " \n Do you want to receive?");
            var result = MessageBox.Show(deviceName + " wants to send you files: " + totalTransferSize + " \n Do you want to receive?", "Transfer Request!", button: MessageBoxButton.YesNo);
            Dispatcher.Invoke(() =>
            {
                if (result == MessageBoxResult.Yes)
                {
                    Navigator.Navigate("Pages/TransferPage.xaml");
                    Main.ResponseToTransferRequest(true);
                }
                else
                    Main.ResponseToTransferRequest(false);
            });
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string[] filePaths = SelectFiles();
            AddFilesToList(filePaths);
        }
        /// <summary>
        /// The address of the file to be processed is selected
        /// </summary>
        /// <returns>the address of the file in memory</returns>
        private string[] SelectFiles()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Filter = " All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                string[] selectedFileName = openFileDialog1.FileNames;
                return selectedFileName;
            }
            return null;
        }
        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                AddFilesToList(filePaths);
            }
        }
        private void ShowFileList(bool show)
        {
            Dispatcher.Invoke(() =>
            {
                if (show)
                {
                    lbl_DragDrop.Visibility = Visibility.Hidden;
                    list_Files.Visibility = Visibility.Visible;
                    grid_AddRemove.Visibility = Visibility.Visible;
                    lbl_Info.Visibility = Visibility.Hidden;
                    list_Files.SelectedIndex = 0;
                    btn_Send.Visibility = Visibility.Visible;
                    lbl_ReceiveInfo.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl_DragDrop.Visibility = Visibility.Visible;
                    list_Files.Visibility = Visibility.Hidden;
                    grid_AddRemove.Visibility = Visibility.Hidden;
                    lbl_Info.Visibility = Visibility.Visible;
                    btn_Send.Visibility = Visibility.Hidden;
                    lbl_ReceiveInfo.Visibility = Visibility.Visible;
                }
            });
            
        }
        private void ScanNetwork()
        {
            Debug.WriteLine("Scanning Network");
           Task.Run(()=> NetworkScanner.ScanAvailableDevices());
        }
        private void AddFilesToList(string[] filePaths)
        {
            if (filePaths == null)
                return;
            for (int i = 0; i < filePaths.Length; i++)
            {
                Debug.WriteLine("file " + i + " : " + filePaths[i]);
                if(!FilePaths.Contains(filePaths[i]))
                    FilePaths.Add(filePaths[i]);
            }
            list_Files.ItemsSource = FilePaths.ToArray(); ;
            Main.SetFilePaths(FilePaths.ToArray());
            ShowFileList(true);
        }
        private void txt_DeviceName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txt_DeviceName.IsReadOnly = false;
        }
        private void txt_DeviceName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                Parameters.DeviceName = txt_DeviceName.Text;
                Parameters.Save();
            }
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate("Pages/OptionsPage.xaml");
        }

        private void list_Files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_AddFiles_Click(object sender, RoutedEventArgs e)
        {
            string[] filePaths = SelectFiles();
            AddFilesToList(filePaths);
        }

        private void btn_RemoveFiles_Click(object sender, RoutedEventArgs e)
        {
            int index = list_Files.SelectedIndex;
            if(FilePaths!=null && FilePaths.Count>0 && index<FilePaths.Count)
            {
                FilePaths.RemoveAt(index);
                Dispatcher.Invoke(() =>
                {
                    list_Files.ItemsSource = FilePaths.ToArray();
                    list_Files.SelectedIndex = Math.Min(index,FilePaths.Count-1);
                    Debug.WriteLine("index: " + list_Files.SelectedIndex);
                });
            }
        }
        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (FilePaths == null)
                return;
            if(FilePaths.Count>0)
            {
                Main.SetFilePaths(FilePaths.ToArray());
                Navigator.Navigate("Pages/DevicesPage.xaml");
            }
        }       
    }
}
