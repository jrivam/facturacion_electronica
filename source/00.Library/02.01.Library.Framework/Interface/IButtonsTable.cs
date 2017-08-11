using Library.Framework.MVP;

namespace Library.Framework.Interface
{
    public interface IButtonsTable
    {
        PresenterTable Presenter { set; }

        void Buttons();
        bool Execute(string paramAction);
    }
}
