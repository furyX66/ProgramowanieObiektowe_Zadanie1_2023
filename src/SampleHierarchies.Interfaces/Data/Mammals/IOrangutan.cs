using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting an orangutan.
/// </summary>
public interface IOrangutan : IMammal
{
    #region Interface Members
    /// <summary>
    /// Lifestyle of orangutan (Arboreal or no) 
    /// Opposable thumbs (has or no)
    /// Solitarity behavior (has or no)
    /// Slow reproductive rate (has or no)
    /// Orangutan level of intelligence 
    /// </summary>
    bool ArborealLifeStyle { get; set; }
    bool OpposableThumbs { get; set; }
    bool SolitaryBehavior { get; set; }
    bool SlowReproductiveRate { get; set; }
    int HighIntelligence { get; set; }
    #endregion // Interface Members
}
