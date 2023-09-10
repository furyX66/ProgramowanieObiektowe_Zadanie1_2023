using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    public List<IAfricanElephant> AfricanElephants { get; set; }
    public List<IOrangutan> Orangutans { get; set; }
    public List<IBeaver> Beavers { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        AfricanElephants = new List<IAfricanElephant>();
        Orangutans = new List<IOrangutan>();
        Beavers = new List<IBeaver>();
    }

    #endregion // Ctors
}
