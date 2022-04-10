using System.Collections.Generic;

namespace MegaMarketMall.Data.Interfaces.Delete
{
    public interface IPhotoDelete
    {
        List<string> PhotosHaveToDelete { get; set; } 
    }
}