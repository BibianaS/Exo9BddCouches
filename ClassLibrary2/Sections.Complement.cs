using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDAO
{
    public partial class Sections
    {
        /// <summary>
        /// Constructeur de la section
        /// </summary>
        public Sections(Int32 unIdSection, String unNomSection, DateTime uneDateDebut, DateTime uneDateFin, ICollection<Stagiaires> uneCollectionStagiaires )
        {
            this.IdSection = unIdSection;
            this.NomSection = unNomSection;
            this.DateDebut = uneDateDebut;
            this.DateFin = uneDateFin;
            this.Stagiaires = uneCollectionStagiaires;
        }
    }
}
