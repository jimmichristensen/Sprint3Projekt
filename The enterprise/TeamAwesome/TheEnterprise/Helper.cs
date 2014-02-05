﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using Model.DomainModel;
using System.Diagnostics;
using System.Windows.Documents;
using System;

namespace TheEnterprise
{
    public static class Helper
    {
        public static decimal DecimalParse(string d)
        {
            decimal parsedValue;
            if (decimal.TryParse(d, out parsedValue))
            {
                return parsedValue;
            }
            throw new Exception(d + " Er ikke et tal");
        }

        // ProjectOnly
        public static void QuestionGroupRankAvailable(decimal rank,List<QuestionGroup> questionGroups)
        {
            foreach (QuestionGroup questionGroup in questionGroups)
            {
                if (questionGroup.Rank == rank)
                {
                    throw new Exception("Rank er allerede valgt");
                }
            }
        }
        public static void QuestionRankAvailable(decimal rank, QuestionGroup questionGroup, int id)
        {
            foreach (Question question in questionGroup.Questions)
                {
                    if (question.Rank == rank)
                    {
                        if (question.Id != id)
                        {
                            throw new Exception("Rank allerede valgt");
                        }
                    }
                }
        }
        public static void AnswerRankAvailable(decimal rank, List<QuestionGroup> questionGroups, int id)
        {
            foreach (QuestionGroup questionGroup in questionGroups)
            {
                foreach (Question question in questionGroup.Questions)
                {
                    foreach (Answer answer in question.Answers)
                    {
                        if (answer.Rank == rank)
                        {
                            if (answer.Id != id)
                            {
                                throw new Exception("Rank er allerede valgt");
                            }
                        }
                    }
                }
            }
        }
        
      
    }
}