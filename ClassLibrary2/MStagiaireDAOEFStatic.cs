
using classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDAO
{
    public class MStagiaireDAOEFStatic
    {

        public static void InstanceStagiairesSection(MSection laSection)
        {

            //instanciation du dbContext si null
            if (DonneesDAO.dbContext == null) DonneesDAO.dbContext = new Model1Container();


            Int32 leCodeSection = MStagiaireDAOEFStatic.recupereCode(laSection.CodeSection);

            //Requette Linq pour lire la BDD
            var query = from a in DonneesDAO.dbContext.StagiairesSet
                        where a.Sections.IdSection == leCodeSection
                        select a;

            //ref de l'objet
            MStagiaire leStagiaire;

            //parcourir les lignes de la requette
            foreach (Stagiaires item in query)
            {
                //instancie et renseigne l'onjet MStagiaire spécialisé
                if (item is StagiaireCIF)
                {
                    leStagiaire = new MStagiaireCIF(
                        item.NumOsia,
                        item.NomStagiaire,
                        item.PrenomStagiaire,
                        item.rueStagiare,
                        item.VilleStagiaire,
                        item.CodePostalStagiaire,
                        ((StagiaireCIF)item).FongeCif,
                        ((StagiaireCIF)item).TypeCif.Trim());
                }
                else
                {
                    leStagiaire = new MStagiaireDE(
                        item.NumOsia,
                        item.NomStagiaire,
                        item.PrenomStagiaire,
                        item.rueStagiare,
                        item.VilleStagiaire,
                        item.CodePostalStagiaire,
                        ((StagiaireDE)item).RemuAfpa);
                }

                //affecter les points et notes
                //seulement si le demandeur est de type MStagiaireDAOEFStatic
                leStagiaire.SetPoints(Convert.ToInt32(item.PointsNotes),
                    (int)item.NbreNotes,
                    typeof(MStagiaireDAOEFStatic).ToString());

                //ajoute le stagiaire a la collecion de la section
                laSection.Ajouter(leStagiaire);
            }


        }

        public static void InsereStagiaire(MStagiaire unStagiaire, MSection uneSection)
        {

            //instanciation du dbcontext
            if (DonneesDAO.dbContext == null)
            {
                DonneesDAO.dbContext = new Model1Container();

            }
            Int32 leCodeSection = MStagiaireDAOEFStatic.recupereCode(uneSection.CodeSection);
            //rechercher l'entity section
            Sections laSection = DonneesDAO.dbContext.SectionsSet.Find(leCodeSection);

            //instancier un entity et la reindeigner 
            Stagiaires unStagiaireEF = null;

            if (unStagiaire is MStagiaireCIF)
            {
                unStagiaireEF = new StagiaireCIF(
                    unStagiaire.NumOsia,
                    unStagiaire.Nom,
                    unStagiaire.Prenom,
                    unStagiaire.Rue,
                    unStagiaire.Ville,
                    unStagiaire.CodePostal,
                    null,
                    null,
                    laSection,
                    ((MStagiaireCIF)unStagiaire).Fongecif,
                    ((MStagiaireCIF)unStagiaire).TypeCif);
            }
            else
            {
                unStagiaireEF = new StagiaireDE(
                unStagiaire.NumOsia,
                    unStagiaire.Nom,
                    unStagiaire.Prenom,
                    unStagiaire.Rue,
                    unStagiaire.Ville,
                    unStagiaire.CodePostal,
                    null,
                    null,
                    laSection,
                    ((MStagiaireDE)unStagiaire).RemuAfpa);
            }
            try
            {
                //ajoute l'entity au dbset du dbContext
                DonneesDAO.dbContext.SaveChanges();
            }
            //erreurs possibles. En cas de doublons, ou erreur acces à la bdd
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static int recupereCode(String laSection)
        {
            Int32 leCodeSection;
            if (laSection == "CDI")
            {
                leCodeSection = 1;
            }
            else
            {
                leCodeSection = 2;
            }
            return leCodeSection;
        }

        public static void SupprimerStagiaire(Int32 uneCleStagiare)
        {
            //instancier le dbContext
            if (DonneesDAO.dbContext == null)
            {
                DonneesDAO.dbContext = new Model1Container();
            }

            //recherche l'entity correspondant à la clé stagiare fournie
            Stagiaires leStagiare = DonneesDAO.dbContext.StagiairesSet.Find(uneCleStagiare);
            DonneesDAO.dbContext.StagiairesSet.Remove(leStagiare);

            //Declenche la MAJ sur SQL Szerver par le dbContext
            DonneesDAO.dbContext.SaveChanges();
        }

        public static void ModifieStagiare(MStagiaire monStagiare)
        {
            MStagiaire unStagiaireRec = monStagiare;
            Stagiaires monStagiaireBdd;
            if (DonneesDAO.dbContext == null)
            {
                DonneesDAO.dbContext = new Model1Container();
            }

            monStagiaireBdd = DonneesDAO.dbContext.StagiairesSet.Find(unStagiaireRec.NumOsia);
            monStagiaireBdd.NumOsia = monStagiaireBdd.NumOsia;
            monStagiaireBdd.NomStagiaire = unStagiaireRec.Nom;
            monStagiaireBdd.PrenomStagiaire = unStagiaireRec.Prenom;
            monStagiaireBdd.rueStagiare = unStagiaireRec.Rue;
            monStagiaireBdd.VilleStagiaire = unStagiaireRec.Ville;
            monStagiaireBdd.CodePostalStagiaire = unStagiaireRec.CodePostal;
            DonneesDAO.dbContext.SaveChanges();
        }

        public static void ModifieNotesStagiaire(MStagiaire monStagiaire)
        {
            MStagiaire unStagiaireRec = monStagiaire;
            Stagiaires monStagiaireBdd = DonneesDAO.dbContext.StagiairesSet.Find(unStagiaireRec.NumOsia);

            monStagiaireBdd.PointsNotes = unStagiaireRec.GetPoints(typeof(MStagiaireDAOEFStatic).ToString());
            monStagiaireBdd.NbreNotes = unStagiaireRec.GetNotes(typeof(MStagiaireDAOEFStatic).ToString());
            DonneesDAO.dbContext.SaveChanges();
        }

    }
}
