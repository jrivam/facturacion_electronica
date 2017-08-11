using Library.Framework.MVP;

namespace Library.Framework.Interface
{
    public interface IButtonsQuery
    {
        PresenterQuery Presenter { set; }

        void Buttons();
        bool Execute(string paramAction);
    }
}
