using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisir
{
    internal interface ISprav
    {
        Form parentForm { get; set; }
        void AddEditDelButtonsEnable();
        void AddEditDelButtonsDisable();
        void ShowAddForm();
        void AddFormOkay();
        void AddFormCancel();

    }
}
