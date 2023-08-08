# Enable-Disable-USB
A single GUI made with .NET/MAUI to deactivate a USB port through Windows PowerShell command

This personal project is intended to comply with a single and unique task: deactivate a USB port in my laptop!
It automates a command by calling Windows PowerShell in background (with administrator privilegies) and running with arguments,
being the arguments the same command line the user would type in.
The command line includes "pnputil" with enable/disable instructions along with the USB path.
Inside the string invoked by PowerShell, there is a "-windowstyle" set as "Hidden" to avoid any popup window
displayed to the user.

Further improvements will include a list of ports in the machine with options to deactivate/activate each one!


![focusrite](https://github.com/fabioweck/Enable-Disable-USB/assets/115494238/b02ddb84-1037-4890-85f0-9cb8c5a08b66)
