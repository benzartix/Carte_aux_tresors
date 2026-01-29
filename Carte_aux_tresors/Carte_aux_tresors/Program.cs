using Carte_aux_tresors.Utilis;
using Core.Domain;
using Core.Service;
using Core.Utilis;
using Core.Utilis.Core.Utilis;
using System.Configuration;

// chemin output
var rootPath = ConfigurationManager.AppSettings["rootPath"];

// creation Dossiers output
string projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
string inputFolder = Path.Combine(projectRoot, "Files", "Input");
string outputFolder = Path.Combine(rootPath, "Output");
Directory.CreateDirectory(rootPath);
Directory.CreateDirectory(outputFolder);

// Récupération des fichiers Input*.txt
var inputFiles = Directory.GetFiles(inputFolder, "Input*.txt");


//tester su les intputs existe
if (!inputFiles.Any())
{
    Console.WriteLine("Aucun fichier Input trouvé.");
    return;
}

// Traitement 
foreach (var inputPath in inputFiles)
{
    string inputName = Path.GetFileNameWithoutExtension(inputPath);

    // Input1 -> Output1.txt 2 3 ect..
    string index = inputName.Replace("Input", "", StringComparison.OrdinalIgnoreCase);
    string outputFileName = $"Output{index}.txt";
    string outputPath = Path.Combine(outputFolder, outputFileName);

    var parser = new InputParser();
    var parsed = parser.Parse(inputPath);

    var map = parsed.Map;
    var adventurer = parsed.aventurier;

    var movementService = new MovementService(map);
    var actionService = new ActionService(movementService);

    while (adventurer.HasActions())
    {
        actionService.ExecuteNextAction(adventurer);
    }

    var writer = new OutputWriter();
    writer.Write(outputPath, map, adventurer);
}

Console.WriteLine("Traitement terminé.");

Console.ReadLine();