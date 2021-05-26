﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students
                .OrderByDescending(x => x.AverageGrade)
                .Select(x => x.AverageGrade)
                .ToList();

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[threshold * 2] <= averageGrade)
                return 'B';
            else if (grades[threshold * 4] <= averageGrade)
                return 'C';
            else if (grades[threshold * 6] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
