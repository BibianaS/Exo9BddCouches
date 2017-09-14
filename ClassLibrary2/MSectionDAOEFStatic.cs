
using classesMetier;
using System;



namespace ClassDAO
{
    public class MSectionDAOEFStatic
    {
        public static MSection RestituerSection(String unCodeSection)
        {
            //instancier le dbContext au besoin
            if (DonneesDAO.dbContext == null)
            {
                DonneesDAO.dbContext = new Model1Container();
            }
            
            MSection laSection;
            Int32 val = MStagiaireDAOEFStatic.recupereCode(unCodeSection);
            Sections leStage = DonneesDAO.dbContext.SectionsSet.Find(val);
            
            laSection = new MSection(leStage.IdSection.ToString(), leStage.NomSection, leStage.DateDebut, leStage.DateFin);
            return laSection;
        }
    }
}