using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System.Xml.Linq;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic african elephant class.
/// </summary>
public class Beaver : MammalBase, IBeaver
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am a beaver. My color is: {Color}, my favorite food: {FavoriteFood}, my tail length: {TailLength}. I can build a dam: {IsDamBuilder}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IBeaver ad)
        {
            base.Copy(animal);
            Color = ad.Color;
            FavoriteFood = ad.FavoriteFood;
            TailLength = ad.TailLength;
            IsDamBuilder = ad.IsDamBuilder;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Color { get; set; }
    public string FavoriteFood { get; set; }
    public int TailLength { get; set; }
    public bool IsDamBuilder { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="color">Color</param>
    /// <param name="favoriteFood">Favorite food</param>  
    /// <param name="tailLength">Tail length</param>
    /// <param name="isDamBuilder">Is dam builder</param>
    public Beaver(string name, int age, string color, string favoriteFood, int tailLength, bool isDamBuilder) : base (name, age, MammalSpecies.Beaver) 
    {
        Color = color;
        FavoriteFood = favoriteFood;
        TailLength = tailLength;
        IsDamBuilder = isDamBuilder;
    }

    #endregion // Ctors And Properties
}
