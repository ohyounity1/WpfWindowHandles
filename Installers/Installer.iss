; -- CodeDll.iss --
;
; This script shows how to call functions in external DLLs (like Windows API functions)
; at runtime and how to perform direct callbacks from these functions to functions
; in the script.

[Setup]
AppName=WindowHandleDemo
AppVersion=0.5
WizardStyle=modern
DefaultDirName={autopf}\WindowHandleDemo
DisableProgramGroupPage=yes
DisableWelcomePage=no
UninstallDisplayIcon={app}\UninstallWindowHandleDemo.exe
OutputDir=userdocs:Inno Setup Examples Output

[Files]
Source: "WpfApp1.exe"; DestDir: "{app}"
Source: "WpfApp1.exe.config"; DestDir: "{app}"
Source: "*.dll"; DestDir: "{app}"
Source: "*.xml"; DestDir: "{app}"
Source: "*.pdb"; DestDir: "{app}"