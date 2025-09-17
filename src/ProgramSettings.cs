/// <summary>
/// Common settings for the program
/// <summary>
public class ProgramSettings
{
    public enum WordSources
    {
        FromFile,
        SpecificWord
    }

    public WordSources WordSource { get; set; }
    /// <summary>
    /// Can contain the file name or the specific word based on WordSource
    /// <summary>
    public string WordSourceValue { get; set; }

    public ProgramSettings()
    {
        WordSource = WordSources.FromFile;
        WordSourceValue = "Words.txt";
    }
}
