using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ITreeRenderable<T> where T : ITreeRenderable<T>
    {
        int Id { get; set; }

        string Name { get; set; }

        ICollection<T> Children { get; set; }
    }
}
