using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDAO
{
    public partial class Stagiaires
    {
        /// <summary>
        /// constructeur d'initialisation utilise par les classes DAO
        /// </summary>
        /// <param name="unNumOsia"></param>
        /// <param name="unNom"></param>
        /// <param name="unPrenom"></param>
        /// <param name="uneReue"></param>
        /// <param name="uneVille"></param>
        /// <param name="unCodePostal"></param>
        /// <param name="unNombreNotes"></param>
        /// <param name="unPointsNotes"></param>
        /// <param name="unstage"></param>
        public Stagiaires (Int32 unNumOsia, String unNom, String unPrenom, String uneRue, String uneVille,String unCodePostal, Int32? unNombreNotes, Int32? unPointsNotes, Sections unStage)
        {
            this.NumOsia = unNumOsia;
            this.NomStagiaire = unNom;
            this.PrenomStagiaire = unPrenom;
            this.rueStagiare = uneRue;
            this.VilleStagiaire = uneVille;
            this.CodePostalStagiaire = unCodePostal;
            this.NbreNotes = unNombreNotes;
            this.PointsNotes = unPointsNotes;
            this.Sections = unStage;
        }

        /// <summary>
        /// Constructeur par defaut nécessaire pour EF
        /// </summary>
        public Stagiaires()
        {
        }

    }
}
