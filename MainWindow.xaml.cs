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
using Microsoft.Win32;
using System.Windows.Forms;

namespace EDMInstallerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string InstallLocation = "Install Location";

        public MainWindow()
        {
            InitializeComponent();
            Json.genDefaults();
            Json.instance.run();
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            if (Json.es.value == "true")
            {
                Console.WriteLine("It Worked!!!");
                if (!File.Exists(System.Windows.Application.Current.StartupUri.AbsolutePath + "/EDM.jar"))
                {
                    DownloadFiles.downloadEDM();
                }
                else
                {
                    System.Windows.MessageBox.Show("Already Downloaded. Moving file...");
                }

                if (!File.Exists(InstallLocation + "/mods/EDM.jar"))
                {
                   // FileSystem.MoveFile(Application.StartupPath + "/EDM.jar", InstallLocation + "/mods/EDM.jar", UIOption.AllDialogs, UICancelOption.DoNothing);
                    File.Move(System.Windows.Application.Current.StartupUri.AbsolutePath + "/EDM.jar", InstallLocation + "/mods/EDM.jar");
                }
                else
                {
                    System.Windows.MessageBox.Show("Mod is already installed");
                }
            }
            else
            {
                Console.WriteLine("Oops!! Something went wrong!! " + Json.es.name.ToString() + " was not vaild or the config was tampered with, so no install happened.");
            }

            if (Json.config.value == "true")
            {
                DownloadFiles.DownloadForge();
                System.Diagnostics.Process.Start(System.Windows.Application.Current.StartupUri.AbsolutePath + "/forge.exe");
            }
            else
            {
                Console.WriteLine("Oops!! Something went wrong!!");
            }
        }

        private void EDMInstall_Checked(object sender, EventArgs e)
        {
            if (EDMInstall.IsChecked==true)
            {
                Json.es.value = "true";
                Json.instance.run();
                Console.WriteLine(Json.es.value.ToString());
            }
            else
            {
                Json.es.value = "false";
                Json.instance.run();
                Console.WriteLine(Json.es.value.ToString());
            }
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog s = new FolderBrowserDialog();
            s.RootFolder = Environment.SpecialFolder.ApplicationData;
            // Show the FolderBrowserDialog
            DialogResult result = s.ShowDialog();
           
               OutputTextBlock.Text = s.SelectedPath;
                InstallLocation = s.SelectedPath;
           
        }
    
    }
}
