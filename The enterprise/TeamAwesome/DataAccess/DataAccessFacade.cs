﻿using DataAccess.Controller;
using System.Runtime.CompilerServices;
using Model.DomainModel;

namespace DataAccess
{
    public class DataAccessFacade
    {
        FilterDataAccessController dataAccessController = new FilterDataAccessController();
        PrintDataAccessController printController = new PrintDataAccessController();

        public Filter Load(FilterType filterType)
        {
           return dataAccessController.Load(filterType);
        }

        public void Save(Filter filter)
        {
            dataAccessController.Save(filter);
        }

        public void Find()
        {
            // Skal finde et gammelt filter
        }

        public void CreatePrintFile(Filter filter)
        {
            printController.CreatePrintFile(filter);
        }
    }
}