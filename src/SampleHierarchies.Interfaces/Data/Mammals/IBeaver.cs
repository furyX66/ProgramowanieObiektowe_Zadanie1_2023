using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting an orangutan.
/// </summary>
public interface IBeaver : IMammal
{
    #region Interface Members
    /// <summary>
    /// Is dam builder (yes or no) 
    /// Beaver's color 
    /// Beaver's favorite food
    /// Length of beaver's tail
    /// </summary>
    bool IsDamBuilder { get; set; }
    string Color { get; set; }
    string FavoriteFood { get; set; }
    int TailLength { get; set; }
    #endregion // Interface Members
}
