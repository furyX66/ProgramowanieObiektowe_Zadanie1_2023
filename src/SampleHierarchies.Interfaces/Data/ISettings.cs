namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    #region Interface Members

    /// <summary>
    /// Version of settings.
    /// </summary>
    public string Version { get; set; }
    public string ConsoleColor { get; set; }
    public void ReadFromJson(string menu);
    #endregion // Interface Members
}

