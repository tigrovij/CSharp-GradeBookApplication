using GradeBook.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var orderedStudents = Students.OrderByDescending(x => x.AverageGrade).ToList();
            var groupSize = (int)Math.Round((double)Students.Count / 5);
            for(int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade == averageGrade)
                {
                    if (i < groupSize) return 'A';
                    if (i < groupSize * 2) return 'B';
                    if (i < groupSize * 3) return 'C';
                    if (i < groupSize * 4) return 'D';
                }
            }
            return 'F';
        }
    }
}
