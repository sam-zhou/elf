namespace Elf.Common.Models
{
    public interface IOrderedResultInput
    {
        string Sort { get; set; }

        bool Ascending { get; set; }
        
    }
}
