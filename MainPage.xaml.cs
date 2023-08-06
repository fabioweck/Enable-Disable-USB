using System.Management.Automation;

namespace EnableDisableUSB;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        //Reads if the button is toggled and performs the command
        if (e.Value)
        {

            using (PowerShell ps = PowerShell.Create())
            {

                /* Here the string enable contains all the instructions to the powershell
                   -windowstyle Hidden runs the code without creating a window
                   RunAs determines to run as administrator
                   the last path was obtained in Windows CMD and contains the "&" symbol
                   It must be escaped with "`" or "'" in order to be read correctly by the PowerShell
                */


                const string enable = @"Start-Process -FilePath ""powershell"" -windowstyle Hidden -Verb RunAs -ArgumentList 'pnputil /enable-device ""USB\VID_1235`&PID_8211\Y7R5XE21C2CFAD""'";
                _ = ps.AddScript(enable);
                ps.Invoke();
            }
        }
        else
        {
            //Basically the same command but with "disable-device" instructions
            using (PowerShell ps = PowerShell.Create())
            {
                const string disable = @"Start-Process -FilePath ""powershell"" -windowstyle Hidden -Verb RunAs -ArgumentList 'pnputil /disable-device ""USB\VID_1235`&PID_8211\Y7R5XE21C2CFAD""'";
                _ = ps.AddScript(disable);
                ps.Invoke();
            }
        }
    }
}

