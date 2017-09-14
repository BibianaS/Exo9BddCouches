using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDAO
{
    public partial class StagiaireCIF
    {
        public StagiaireCIF(Int32 unNumOsia, String unNom, String unPrenom, String uneRue, String uneVille, String unCodePostal, Int32? unNombreNotes, Int32? unPointsNotes, Sections unStage, String unType, String unFongeCIF) : base (unNumOsia, unNom, unPrenom, uneRue, uneVille, unCodePostal, unNombreNotes, unPointsNotes, unStage)
        {
            this.FongeCif = unFongeCIF;
            this.TypeCif = unType;
        }

        public StagiaireCIF()
        {
        }

    }
}
