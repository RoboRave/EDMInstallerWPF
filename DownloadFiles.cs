using System;
using System.IO;
using System.Net;
using System.Windows;

namespace EDMInstallerWPF
{
    internal class DownloadFiles
    {
        public static void downloadEDM()
        {
            if (File.Exists(Application.Current.StartupUri.AbsolutePath+ "/EDM.jar"))
            {
                MessageBox.Show("Hey, You Already Downloaded it. Moving file.");
            }
            else
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://addons-origin.cursecdn.com/files/2237/271/[1.7.10]EDM-4.1.0-Universal.jar", "EDM.jar");
                }
            }
        }

        public static void DownloadForge()
        {
            if (File.Exists(Application.Current.StartupUri.AbsolutePath + "/forge.exe"))
            {
                Console.WriteLine("Already Downloaded Forge, going to install.");
            }
            else
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://files.minecraftforge.net/maven/net/minecraftforge/forge/1.7.10-10.13.2.1291/forge-1.7.10-10.13.2.1291-installer-win.exe", "forge.exe");
                    Console.WriteLine("Downloaded Forge");
                }
            }
        }
    }
}