using System;
using WixSharp;
using System.Diagnostics;

namespace PlbInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Compiler.WixLocation = @"D:\Work\PBLService\PBLService\packages\Wix_bin\bin";

            BuildMsi("PblService", @"..\PblService\bin\Release\netcoreapp3.1\win-x64", "2ba18e26-f547-4fbf-9fa0-d718a3285016");
            BuildMsi("PblUi", @"..\PblUi\bin\Release\netcoreapp3.1\win-x64", "873d612e-7c8a-4288-aab8-f678d4dfe6c8");
        }

        private static void BuildMsi(string appName, string sourceDir, string guid)
        {
            string exeName = $"{appName}.exe";
#if DEBUG
            var prefix = "Debug-";
#else
            var prefix = "Release-";
#endif
            var version = GetVersion(sourceDir + "\\" + exeName);
            var formattedVersion = GetFormattedVersion(version.Major, version.Minor, version.Build, version.Revision);
            var mainExe = new File(exeName);
            mainExe.FirewallExceptions = new FirewallException[]
            {
                new FirewallException(exeName)
                {
                    Scope = FirewallExceptionScope.any,
                    Port = "443",
                    Protocol = FirewallExceptionProtocol.tcp,
                    Profile = FirewallExceptionProfile.all,
                    Description = "Allow PBL interact with cloud"
                }
            };
            mainExe.ServiceInstaller = new ServiceInstaller
            {
                DelayedAutoStart = true,
                Name = $"{appName}",
                StartOn = SvcEvent.Install,
                StopOn = SvcEvent.InstallUninstall_Wait,
                RemoveOn = SvcEvent.Uninstall_Wait,
                Arguments = "--win-service"
            };

            var project =
                new Project($"{appName}"
                    , new Dir($@"%ProgramFiles%\automat-service\pick-by-light\{appName}"
                        , mainExe
                        , new Files("*.dll")
                        , new Files("*.json")
                        , new Files("*.pdb")
                        , new Files("*.md")
                        , new Files("*.css")
                        , new Files("*.js")
                        , new Dir(@"Log")
                        {
                            Permissions = new DirPermission[]
                            {
                                new DirPermission("Everyone", GenericPermission.All),
                            }
                        })
                , new Dir($@"%ProgramMenu%\{appName}",
                    new ExeFileShortcut($"Uninstall {appName}", "[System64Folder]msiexec.exe", "/x [ProductCode]"),
                    new ExeFileShortcut(appName, $"[INSTALLDIR]{appName}", arguments: ""))
                )
                {
                    SourceBaseDir = sourceDir,
                    Version = version,
                    OutFileName = $"{prefix}{appName}-{formattedVersion}",
                    GUID = new Guid(guid),
                    InstallPrivileges = InstallPrivileges.elevated,
                    InstallScope = InstallScope.perMachine,
                    MajorUpgradeStrategy = MajorUpgradeStrategy.Default,
                    UI = WUI.WixUI_Minimal,
                    PreserveTempFiles = true
                };

            Compiler.BuildMsi(project);
        }

        private static Version GetVersion(string path)
        {
            return new Version(FileVersionInfo.GetVersionInfo(path).FileVersion);
        }

        private static string GetFormattedVersion(int major, int minor, int build, int revision)
        {
            return $"{major.ToString("D2")}.{minor.ToString("D3")}.{build.ToString("D3")}.{revision.ToString("D4")}";
        }
    }
}