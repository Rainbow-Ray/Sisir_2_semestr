using System.Windows.Forms;

namespace Sisir
{
    public interface ISprav
    {
        Form parentForm { get; set; }
        void AddEditDelButtonsEnable();
        void AddEditDelButtonsDisable();
        void ShowAddForm();
        void AddFormOkay();
        void AddFormCancel();

        void UpdateDataSource();
        void ShowHelperSprav<T>() where T : Form, ISprav, new();

    }
}
