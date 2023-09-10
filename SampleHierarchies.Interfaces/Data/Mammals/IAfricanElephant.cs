using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting an african elephant.
/// </summary>
public interface IAfricanElephant : IMammal
{
    #region Interface Members
    /// <summary>
    /// Height of elephant
    /// Weight of elephant
    /// TuskLength of elephant
    /// LongLifespan of elephant
    /// Social Behavior of elephant
    /// </summary>
    float Height { get; set; }
    float Weight { get; set; }
    float TuskLength { get; set; }
    int LongLifespan { get; set; }
    string SocialBehavior { get; set; }

    #endregion // Interface Members
}
