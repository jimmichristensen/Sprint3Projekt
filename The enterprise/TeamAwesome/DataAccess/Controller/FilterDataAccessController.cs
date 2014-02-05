﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using DataAccess.Helpers;
using Model.DomainModel;

namespace DataAccess.Controller
{
    class FilterDataAccessController
    {
        BinaryHelper<Filter> binaryHelper = new BinaryHelper<Filter>();

        public Filter Load(FilterType filterType)
        {
            try
            {               
                if (!binaryHelper.FileExists(getFilename(filterType)))
                {
                    return new Filter(){Type = filterType};
                }
                return binaryHelper.LoadObject(getFilename(filterType));
                //return binaryHelper.LoadObject(getSyncFilename(filterType));
            }
            catch (BimaryException ex)
            {
                return new Filter();
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
        }

        public void Save(Filter filter)
        {
            binaryHelper.SaveObject( filter , getFilename(filter.Type) );
        }

        public void Find()
        {
            // Hent filter arkiv filen og søge efter filnavne

        }

        private string getFilename(FilterType filterType)
        {

            string folder = "templates/";

            switch (filterType)
            {
                case FilterType.TestTemplate:
                {
                    return folder+"TestTemplate.bin";
                }
                case FilterType.EnglishTemplate:
                {
                    return folder+"EnglishTemplate.bin";
                }
                case FilterType.DanishTemplate:
                {
                    return folder+"DanishTemplate.bin";
                }
                case FilterType.DeutschTemplate:
                {
                    return folder + "DeutschTemplate.bin";
                }
            }

            throw new Exception("Forkert filter type");
        }
        private string getSyncFilename(FilterType filterType)
        {

            string folder = @"C:\simatek\";

            switch (filterType)
            {
                case FilterType.TestTemplate:
                    {
                        return folder + "TestTemplate.bin";
                    }
                case FilterType.EnglishTemplate:
                    {
                        return folder + "EnglishTemplate.bin";
                    }
                case FilterType.DanishTemplate:
                    {
                        return folder + "DanishTemplate.bin";
                    }
                case FilterType.DeutschTemplate:
                    {
                        return folder + "DeutschTemplate.bin";
                    }
            }

            throw new Exception("Forkert filter type");
        }

    }
}
