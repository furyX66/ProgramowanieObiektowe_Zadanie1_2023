using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic african elephant class.
/// </summary>
public class AfricanElephant : MammalBase, IAfricanElephant
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am an african elephant. My height is {Height} cm and my weight is {Weight} kg. My tusk length is {TuskLength} cm and i can live for {LongLifespan} years. {SocialBehavior}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IAfricanElephant ad)
        {
            base.Copy(animal);
            Height = ad.Height;
            Weight = ad.Weight;
            TuskLength = ad.TuskLength;
            LongLifespan = ad.LongLifespan;
            SocialBehavior = ad.SocialBehavior; 
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public float Height { get; set; }
    public float Weight { get; set; }
    public float TuskLength { get; set; }
    public int LongLifespan { get; set; }
    public string SocialBehavior { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="height">Height</param>
    /// <param name="weight">Weight</param>  
    /// <param name="longLifespan">Long lifespan</param>
    /// <param name="socialBehavior">Social behavior</param>
    /// <param name="tuskLength">Tusk lenght</param>
    public AfricanElephant(string name, int age, float height, float weight, float tuskLength, int longLifespan, string socialBehavior) : base(name, age, MammalSpecies.AfricanElephant)
    {
        Height = height;
        Weight = weight;
        TuskLength = tuskLength;
        LongLifespan = longLifespan;
        SocialBehavior = socialBehavior;
    }

    #endregion // Ctors And Properties
}
