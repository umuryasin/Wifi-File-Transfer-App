﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Collections;

namespace FileSharingApp_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string FileURL = "";
        private FileOperations.TransferMode TransferMode;
        private uint prev_timePassed = 0;
        private double _transferSpeed = 0;
        private uint mb = 1024 * 1024;
        private uint ETA = 0;
        private Thread UIUpdate_thread;
        private bool UIUpdate_Start = false;
        private int UIUpdate_Period = 100;      // in ms
        private Brush CompletedStep = Brushes.LimeGreen;
        private Brush CurrentStep = Brushes.Orange;
        private Brush UnCompletedStep = Brushes.LightBlue;
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            //declare culture info
        BitmapImage btm_checked = new BitmapImage(new Uri(@"/Icons/checked.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();

        }
        private void UpdateUI()
        {
            Stopwatch UpdateWatch = new Stopwatch();

            while (UIUpdate_Start)
            {
                UpdateWatch.Restart();
                Dispatcher.Invoke(() =>
                {
                    if (Main.FirstStep)
                    {
                        //lbl_FirstStep.Fill = CompletedStep;
                        //lbl_SecondStep.Fill = CurrentStep;
                        //lbl_ThirdStep.Fill = UnCompletedStep;
                        Img_FirstStep.Source = btm_checked;

                        border_SecondStep.IsEnabled = true;
                        btn_Confirm.IsEnabled = true;
                        Main.FirstStep = false;
                    }
                    else if (Main.SecondStep)
                    {
                        //lbl_SecondStep.Fill = CompletedStep;
                        //lbl_ThirdStep.Fill = CurrentStep;
                        Img_SecondStep.Source = btm_checked;

                        border_ThirdStep.IsEnabled = true;
                        if (TransferMode == FileOperations.TransferMode.Send) // ********************* Main içerisinde de proses tipi var biri seçilmeli
                        {
                            btn_Confirm.IsEnabled = false;
                        }
                        Main.SecondStep = false;
                        StopFlashing();
                    }
                    else if (Main.ThirdStep)
                    {
                        //lbl_ThirdStep.Fill = CompletedStep;
                        Img_ThirdStep.Source = btm_checked;
                        Main.ThirdStep = false;
                        

                    }

                    if (Main.ExportingVerification && Communication.isClientConnected)
                    {
                        string sExportingVerification = res_man.GetString("sExportingVerification", cul)+":"+Main.HostName.ToString();
                        string sConfirmation = res_man.GetString("sConfirmation", cul);
                        MessageBoxResult result = MessageBox.Show(sExportingVerification, sConfirmation, MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                            Main.TransferApproved = true;
                        Main.ExportingVerification = false;
                        
                    }


                    if (TransferMode == FileOperations.TransferMode.Send)
                        txt_IpCode.Text = Main.IpCode;
                    string MainStatus = Main.InfoMsg;
                    if (!MainStatus.Equals(""))
                        txt_StatusInfo.Text = res_man.GetString(MainStatus, cul);
                    txt_FilePath.Text = Main.URL;
                    txt_FileName.Text = Main.FileName;
                    txt_HostName.Text = Main.HostName;
                    if(Main.FileSizeType!=Communication.SizeTypes.none)
                        txt_FileSize.Text = Main.FileSize.ToString("0.00") + " " + Main.FileSizeType.ToString();
                    txt_TransferSpeed.Text = Main.TransferSpeed.ToString("0.00") + " MB/s";
                    txt_EstimatedTime.Text = Main.EstimatedMin.ToString() + " : " + Main.EstimatedSec.ToString();
                    txt_PassedTime.Text = Main.PassedMin.ToString() + " : " + Main.PassedSec.ToString();
                    pbStatus.Value = Main.CompletedPercentage;
                });

                while (UpdateWatch.ElapsedMilliseconds < UIUpdate_Period)
                {
                    Thread.Sleep(1);
                }
            }

        }

        private void btn_SendFile_Click(object sender, RoutedEventArgs e)
        {
            StopFlashing();
            string FileURL = SelectFile();
            if (FileURL == null)
            {
                string sSelectionValidFile = res_man.GetString("sSelectionValidFile", cul);
                MessageBox.Show(sSelectionValidFile);
                return;
            }
            Reset();
            TransferMode = FileOperations.TransferMode.Send;
            Main.SetFileURL(FileURL);
            FlashObject(txt_IpCode);
            System.Diagnostics.Debug.WriteLine(" FileURL = " + FileURL);
        }
        private void btn_ReceiveFile_Click(object sender, RoutedEventArgs e)
        {
            StopFlashing();
            FileURL = GetFolder();
            if (FileURL == null)
            {
                System.Diagnostics.Debug.WriteLine("File Url is null");
                return;
            }
            Reset();
            TransferMode = FileOperations.TransferMode.Receive;
            Main.FirstStep = true;
            Main.InfoMsg = "sEnterCode";
            FlashObject(txt_IpCode);
            System.Diagnostics.Debug.WriteLine(" FileURL = " + FileURL);
        }
        private void Reset()
        {
            Main.TransferApproved = false;
            Main.FirstStep = true;
            Main.SecondStep = false;
            Main.ThirdStep = false;
            Main.CompletedPercentage = 0;
            Main.PassedMin = 0;
            Main.PassedSec = 0;
            Main.EstimatedMin = 0;
            Main.EstimatedSec = 0;

            Img_FirstStep.Source = new BitmapImage(new Uri(@"/Icons/number-1.png", UriKind.Relative));
            Img_SecondStep.Source = new BitmapImage(new Uri(@"/Icons/number-2.png", UriKind.Relative));
            Img_ThirdStep.Source = new BitmapImage(new Uri(@"/Icons/number-3.png", UriKind.Relative));

            Main.Reset();
            txt_FilePath.Text = "";
            txt_FileName.Text = "";
            txt_FileSize.Text = "";
            txt_HostName.Text = "";
            txt_EstimatedTime.Text = "";
            txt_PassedTime.Text = "";
            txt_IpCode.Text = "";
            StopFlashing();
        }
        /// <summary>
        /// The address of the file to be processed is selected
        /// </summary>
        /// <returns>the address of the file in memory</returns>
        private string SelectFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Filter = " All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog1.FileName;
                return selectedFileName;
            }
            return null;
        }
        /// <summary>
        /// this function is used to select a folder on current machine and returns folder path
        /// </summary>
        /// <returns>Folder path</returns>
        private string GetFolder()
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Select Target Folder";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            dlg.DefaultDirectory = "c:\\";
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var folder = dlg.FileName;
                System.Diagnostics.Debug.WriteLine("Selected Folder: " + folder);
                return folder;
            }
            return null;
        }
        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (TransferMode == FileOperations.TransferMode.Receive)
            {
                Main.Init(false);
                string code = txt_IpCode.Text;
                bool success = Main.EnterTheCode(code);
                if (success)
                {
                    StopFlashing();
                    Main.SetFilePathToSave(FileURL);
                    string FileName = Main.FileName;
                    string fileSizeType = Main.FileSizeType.ToString();
                    string fileSize = Main.FileSize.ToString("0.00") + " " + fileSizeType;

                    string sImportingVerification = res_man.GetString("sImportingVerification", cul);
                    string sConfirmation = res_man.GetString("sConfirmation", cul);
                    MessageBoxResult result = MessageBox.Show(sImportingVerification + "\n" + FileName + " file of " + fileSize + " size?", sConfirmation, MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Yes code here  
                        Main.RespondToTransferRequest(true);
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        // No code here  
                        Main.RespondToTransferRequest(false);
                    }

                    // Gönderimin alınıp alınmaması durmu burada sorulur
                }
                else
                {
                    MessageBox.Show("Entered code is incorrect!");
                    // kodun hatalı olduğu ise burada gösterilri
                }
            }
            else if (TransferMode == FileOperations.TransferMode.Send && Communication.isClientConnected)
            {
                Main.TransferApproved = true;
                StopFlashing();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Init(true);
            UI_Init();

            res_man = new ResourceManager("FileSharingApp_Desktop.Resource.resource", Assembly.GetExecutingAssembly());
            cul = CultureInfo.CreateSpecificCulture("tr");        //create culture for english

            UIUpdate_thread = new Thread(UpdateUI);
            UIUpdate_thread.IsBackground = true;
            UIUpdate_Start = true;
            UIUpdate_thread.Start();

            combo_LanguageSelection.SelectedItem = combo_LanguageSelection.Items.GetItemAt(0);
            switch_language();
           // var t = Task.Run(() => CheckUpdate());

        }
        private void CheckUpdate()
        {
            bool isLatestVersion = AutoUpdater.UpdaterMain.CompareVersions();
            if (!isLatestVersion)
            {
               var res= MessageBox.Show("There is a new update! \n Would you like to download the new version?","Version Check",MessageBoxButton.YesNo);
                if(res==MessageBoxResult.Yes)
                {
                    AutoUpdater.UpdaterMain.BeginDownload();
                    MessageBox.Show("Download started!");
                }
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            UIUpdate_Start = false;
            Main.CloseServer();
            Environment.Exit(0);
            Thread.Sleep(10);
        }

        private void UI_Init()
        {
            border_FirstStep.IsEnabled = true;
            border_SecondStep.IsEnabled = false;
            border_ThirdStep.IsEnabled = false;

            //lbl_FirstStep.Fill = CurrentStep;
            //lbl_SecondStep.Fill = UnCompletedStep;
            //lbl_ThirdStep.Fill = UnCompletedStep;



        }

        private void switch_language()
        {
            if (res_man != null)
            {
                btn_SendFile.Content = res_man.GetString("sSendFile", cul);
                btn_ReceiveFile.Content = res_man.GetString("sReceiveFile", cul);
                btn_Confirm.Content = res_man.GetString("sConfirmation", cul);

                lbl_FilePath.Content = res_man.GetString("sFilePath", cul);
                lbl_FileName.Content = res_man.GetString("sFileName", cul);
                lbl_FileSize.Content = res_man.GetString("sFileSize", cul);
                lbl_HostName.Content = res_man.GetString("sHostName", cul);

                lbl_TransferSpeed.Content = res_man.GetString("sSpeed", cul);
                lbl_PassedTime.Content = res_man.GetString("sTimePassed", cul);
                lbl_EstimatedTime.Content = res_man.GetString("sEstimatedTime", cul);
                lbl_code.Content = res_man.GetString("sCode", cul);

                txt_IpCode.ToolTip = res_man.GetString("sstCode", cul);

            }
        }

        private void combo_LanguageSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedLanguage = ((ComboBoxItem)combo_LanguageSelection.SelectedItem).Tag.ToString();

            if (SelectedLanguage.Equals("TR"))
            {
                cul = CultureInfo.CreateSpecificCulture("tr");        //create culture for english
            }
            else if (SelectedLanguage.Equals("EN"))
            {
                cul = CultureInfo.CreateSpecificCulture("en");        //create culture for english
            }
            switch_language();
        }
        Task FlashTask;
        private void FlashObject(TextBox obj)
        {
            Brush originalBrush = obj.Background;
            isFlashing = true;
            FlashTask=Task.Run(() => Flash(obj, originalBrush));
            Debug.WriteLine("Flashing is started!");

        }
        private void StopFlashing()
        {
            isFlashing = false;
            Debug.WriteLine("Flashing is stopped!");
        }
        private bool isFlashing
        {
            get
            {
                lock (lck_isFlashing)
                    return _isFlashing;
            }
            set
            {
                lock (lck_isFlashing)
                    _isFlashing = value;
            }
        }
        private bool _isFlashing;
        private object lck_isFlashing = new object();
        private void Flash(TextBox obj, Brush origBrush)
        {
            Dispatcher.Invoke(() =>
            {
                obj.BorderBrush= Brushes.CornflowerBlue;
            });
            Thread.Sleep(500);
            Dispatcher.Invoke(() =>
            {
                obj.BorderBrush = origBrush;
            });
            Thread.Sleep(500);
            
            if (isFlashing)
                Flash(obj, origBrush);
        }
        /// <summary>
        /// This function is used to prevent the user to type more than 6 characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_IpCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = txt_IpCode.Text;
            if(text.Length>6)
            {
                txt_IpCode.Text = text.Remove(6, 1);
                txt_IpCode.CaretIndex = 6;
            }
        }
    }
}
