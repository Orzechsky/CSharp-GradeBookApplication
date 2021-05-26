using System;
using System.Collections.Generic;
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
                throw new InvalidOperationException();
            }

            int position = 0;

            foreach (var student in Students)
            {
                if (averageGrade > student.AverageGrade)
                {
                    position++;
                }
            }

            var percent = position / Students.Count;

            if (percent > 0.8)
                return 'A';
            else if (percent > 0.6)
                return 'B';
            else if (percent > 0.4)
                return 'C';
            else if (percent > 0.2)
                return 'D';
            else
                return 'F';
        }
    }
}
