using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisir
{
    internal interface ISprav
    {
        void AddEditDelButtonsEnable();
        void AddEditDelButtonsDisable();
        void ShowAddForm();
        void AddFormOkay();
        void AddFormCancel();

    }
}
