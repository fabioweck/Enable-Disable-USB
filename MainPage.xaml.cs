using System.Management.Automation;

namespace EnableDisableUSB;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                const string enable = @"Start-Process -FilePath ""powershell"" -windowstyle Hidden -Verb RunAs -ArgumentList 'pnputil /enable-device ""USB\VID_1235`&PID_8211\Y7R5XE21C2CFAD""'";
                _ = ps.AddScript(enable);
                ps.Invoke();
            }
        }
        else
        {
            using (PowerShell ps = PowerShell.Create())
            {
                const string disable = @"Start-Process -FilePath ""powershell"" -windowstyle Hidden -Verb RunAs -ArgumentList 'pnputil /disable-device ""USB\VID_1235`&PID_8211\Y7R5XE21C2CFAD""'";
                _ = ps.AddScript(disable);
                ps.Invoke();
            }
        }
    }
}

