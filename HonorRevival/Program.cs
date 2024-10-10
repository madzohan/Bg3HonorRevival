using LSLib.LS;
using LSLib.LS.Enums;

namespace HonorRevival;

class Program
{

    static void Main(string[] args)
    {
        /*
         * 0 step backup original C:\Users\madzohan\AppData\Local\Larian Studios\Baldur's Gate 3\PlayerProfiles\Public\profile8.lsf
         * to ...\profile8.lsf.original
         * 
         * 1 step lsf -> lsx
         * C:\Users\madzohan\AppData\Local\Larian Studios\Baldur's Gate 3\PlayerProfiles\Public\profile8.lsf
         * C:\Users\madzohan\AppData\Local\Larian Studios\Baldur's Gate 3\PlayerProfiles\Public\profile8.lsx
         * 
         * while writing LSX file skip node if
         * node.Name == "DisabledSingleSaveSessions" && node.Parent.Name == "DisabledSingleSaveSessions"
         * 
         * 2 step lsx -> lsf
         * C:\Users\madzohan\AppData\Local\Larian Studios\Baldur's Gate 3\PlayerProfiles\Public\profile8.lsx
         * C:\Users\madzohan\AppData\Local\Larian Studios\Baldur's Gate 3\PlayerProfiles\Public\profile8.lsf
         */

        const string ProfileDirPath = @"%USERPROFILE%\AppData\Local\Larian Studios\Baldur's Gate 3\PlayerProfiles\Public";
        var expandedProfileDirPath = Environment.ExpandEnvironmentVariables(ProfileDirPath);
        var originLsfPath = Path.Combine(expandedProfileDirPath, "profile8.lsf");
        var convertedLsxPath = Path.Combine(expandedProfileDirPath, "profile8.lsx");
        var convertedLsfPath = originLsfPath;
        var loadParams = ResourceLoadParameters.FromGameVersion(Game.BaldursGate3);
        var conversionParams = ResourceConversionParameters.FromGameVersion(Game.BaldursGate3);

        // begin of step 0 --------------------------------------------------------------------------------------------------
        var originLsfPathBackup = Path.Combine(expandedProfileDirPath, "profile8.lsf.original");
        try
        {
            File.Copy(originLsfPath, originLsfPathBackup, true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("step 0/2: profile8.lsf backuped to profile8.lsf.original successfully.");
            Console.ResetColor();
        }
        catch (Exception exc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"step 0/2: Internal error!{Environment.NewLine}{Environment.NewLine}{exc}", "Backup Failed");
            Environment.Exit(1);
        }
        // end of step 0 ----------------------------------------------------------------------------------------------------

        // begin of step 1 --------------------------------------------------------------------------------------------------
        try
        {
            var originLsfResource = ResourceUtils.LoadResource(originLsfPath, loadParams);
            ResourceUtils.SaveResource(originLsfResource, convertedLsxPath, ResourceFormat.LSX, conversionParams);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("step 1/2: profile8.lsx saved successfully.");
            Console.ResetColor();
        }
        catch (InvalidDataException exc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"step 1/2: Unable to convert resource.{
                Environment.NewLine}{Environment.NewLine}{exc.Message}", "Conversion Failed");
            Environment.Exit(1);
        }
        catch (Exception exc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"step 1/2: Internal error!{
                Environment.NewLine}{Environment.NewLine}{exc}", "Conversion Failed");
            Environment.Exit(1);
        }
        // end of step 1 --------------------------------------------------------------------------------------------------

        // begin of step 2 ------------------------------------------------------------------------------------------------
        try
        {
            var convertedLsfResource = ResourceUtils.LoadResource(convertedLsxPath, loadParams);
            ResourceUtils.SaveResource(convertedLsfResource, convertedLsfPath, ResourceFormat.LSF, conversionParams);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("step 2/2: profile8.lsf saved successfully.");
            Console.ResetColor();
        }
        catch (InvalidDataException exc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"step 2/2: Unable to convert resource.{
                Environment.NewLine}{Environment.NewLine}{exc.Message}", "Conversion Failed");
            Environment.Exit(1);
        }
        catch (Exception exc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"step 2/2: Internal error!{Environment.NewLine}{Environment.NewLine}{exc}", "Conversion Failed");
            Environment.Exit(1);
        }
        // end of step 2 --------------------------------------------------------------------------------------------------

        Console.WriteLine("Press any key to exit ...");
        Console.ReadKey();
    }
}
