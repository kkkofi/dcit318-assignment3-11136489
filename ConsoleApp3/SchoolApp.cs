using System;
using System.Collections.Generic;
using System.IO;

public class SchoolApp
{
    public void Run()
    {
        var processor = new StudentResultProcessor();
        string inputPath = "students.txt";
        string outputPath = "report.txt";

        try
        {
            var students = processor.ReadStudentsFromFile(inputPath);
            processor.WriteReportToFile(students, outputPath);

            Console.WriteLine("Report generated successfully:");
            Console.WriteLine(File.ReadAllText(outputPath));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: Input file not found.");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
