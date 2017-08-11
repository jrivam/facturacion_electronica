
namespace Library.Framework.Interface
{
    public interface IResultMessage
    {
        void ShowError(string paramMessage, string paramTitle);
        void ShowInformation(string paramMessage, string paramTitle);

        void ClearMessage();
    }
}
