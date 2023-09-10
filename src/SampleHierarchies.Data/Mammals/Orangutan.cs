using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic orangutan class.
/// </summary>
public class Orangutan : MammalBase, IOrangutan
{
    #region Public Methods

    /// <inheritdoc/>
    public override void MakeSound()
    {
        Console.WriteLine("My name is: {0} and I am barking", Name);
    }

    /// <inheritdoc/>
    public override void Move()
    {
        Console.WriteLine("My name is: {0} and I am running", Name);
    }

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, Arbotreal Lifestyle: {ArborealLifeStyle}, Opposable Thumbs: {OpposableThumbs}, Solitary behavior {SolitaryBehavior}, Slow Reroduction Rate: {SlowReproductiveRate}, Level of intelligence: {HighIntelligence} and I am an orangutan.");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IOrangutan ad)
        {
            base.Copy(animal);
            ArborealLifeStyle = ad.ArborealLifeStyle;
            OpposableThumbs = ad.OpposableThumbs;
            SolitaryBehavior = ad.SolitaryBehavior;
            SlowReproductiveRate = ad.SlowReproductiveRate;
            HighIntelligence = ad.HighIntelligence;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public bool ArborealLifeStyle { get; set; }
    public bool OpposableThumbs { get; set; }
    public bool SolitaryBehavior { get; set; }
    public bool SlowReproductiveRate { get; set; }
    public int HighIntelligence { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="arborealLifeStyle">ArborealLifeStyle</param>
    /// <param name="opposableThumbs">OpposableThumbs</param>  
    /// <param name="solitaryBihavior">SolitaryBihavior</param>
    /// <param name="slowReproductiveRate">Slow</param>
    /// <param name="highIntelligence">High Intelligence</param>
    public Orangutan(string name, int age, bool arborealLifeStyle, bool opposableThumbs, bool solitaryBihavior, bool slowReproductiveRate, int highIntelligence) : base(name, age, MammalSpecies.Orangutan)
    {
        Name = name;
        Age = age;
        ArborealLifeStyle = arborealLifeStyle;
        OpposableThumbs = opposableThumbs;
        SolitaryBehavior = solitaryBihavior;
        SlowReproductiveRate = slowReproductiveRate;
        HighIntelligence = highIntelligence;
    }

    #endregion // Ctors And Properties
}
