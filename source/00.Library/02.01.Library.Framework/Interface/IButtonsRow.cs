using Library.Framework.MVP;

namespace Library.Framework.Interface
{
    public interface IButtonsRow
    {
        PresenterRow Presenter { set; }

        void Buttons();
        bool Execute(string paramAction);
    }
}
