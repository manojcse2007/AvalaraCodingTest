using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEQualificationTest
{
    class Program
    {
        private class Picture
        {
            public int Id { get; set; }
            public char Direction { get; set; }
            public int TagCount { get; set; }
            public List<string> Tags { get; set; }
        }

        class PictureCollection
        {
            public int Count { get; set; }
            public List<Picture> Pictures { get; set; }
        }

        static void Main(string[] args)
        {
            List<string> lines = System.IO.File.ReadAllLines(@"C:\Users\manoj_patel\source\repos\SEQualificationTest\SEQualificationTest\InputFile.txt", Encoding.ASCII).ToList();

            int count = 0;
            var inputData = new PictureCollection { Count = 0, Pictures = new List<Picture>() };
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                if (count == 0)
                {
                    inputData.Count = Convert.ToInt32(line);
                    count++;
                    continue;
                }

                var lineArray = line.Split(null);
                var picture = new Picture
                {
                    Id = count - 1,
                    Direction = char.Parse(lineArray[0]),
                    TagCount = int.Parse(lineArray[1]),
                    Tags = new List<string>()
                };

                int index = 2;
                while (index < picture.TagCount + 2)
                {
                    picture.Tags.Add(lineArray[index]);
                    index++;
                }
                count++;
            }
        }
    }
}
