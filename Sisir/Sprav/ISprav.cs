using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        void ShowHelperSprav<T>() where T : Form, ISprav, new();

    }
}
