
using Library.Framework.Layers;
namespace Library.Framework.Interface
{
    public interface IViewEntity
    {
    }
    public interface IViewEntityId : IViewEntity
    {
        string _Id { get; set; }
    }
}
