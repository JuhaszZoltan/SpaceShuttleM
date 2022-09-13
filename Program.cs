using SpaceShuttleM;
using System.Text;

internal class Program
{
    static List<Mission> missions = new();
    private static void Main()
    {
        //load
        using StreamReader sr = new(@"..\..\..\res\kuldetesek.csv", Encoding.UTF8);
        while (!sr.EndOfStream) missions.Add(new Mission(sr.ReadLine()));
        //e3
        Console.WriteLine(
            $"3. feladat:\n\t" +
            $"Összesen {missions.Count} alkalommal indítottak űrhajót.");
        //e4
        int nop = missions.Sum(x => x.NOCrew);
        Console.WriteLine(
            $"4. feladat:\n\t" +
            $"{nop} utas indult az űrbe összesen.");
        //e5
        int l5p = missions.Count(x => x.NOCrew < 5);
        Console.WriteLine(
            $"5. feladat:\n\t" +
            $"Összesen {l5p} alkalommal küldtek kevesebb, mint 5 embert az űrbe.");
        //e6
        int lcmc = missions
            .Where(x => x.ShuttleName == "Columbia")
            .OrderBy(x => x.LaunchDate)
            .LastOrDefault().NOCrew;
        Console.WriteLine(
            $"6. feladat:\n\t" +
            $"{lcmc} asztronauta volt a Columbia fedélzetén annak utolsó útján.");
        //e7
        var lm = missions.OrderBy(x => x.TotalSpaceHours).LastOrDefault();
        Console.WriteLine(
            $"7. feladat:\n\t" +
            $"A leghosszabb ideig a {lm.ShuttleName} volt az űrben " +
            $"a(z) {lm.Code} küldetés során.\n" +
            $"Összesen {lm.TotalSpaceHours} órát volt távol a Földtől.");
        //e8
        Console.Write("8. feladat:\n\tÉvszám: ");
        int year = int.Parse(Console.ReadLine());
        var nom = missions.Count(x => x.LaunchDate.Year == year);
        Console.WriteLine($"\tEbben az évben {nom} küldetés volt.");
        //e9
        int noKl = missions.Count(x => x.LandingAirbase == "Kennedy");
        Console.WriteLine(
            $"9. feladat:\n\t" +
            $"A köldetések {noKl/(float)missions.Count*100:0.00}%-a fejeződött be a Kennedy űrközpontban");
        //e10
        using StreamWriter sw = new(@"ursiklok.txt", false, Encoding.UTF8);
        var shg = missions.GroupBy(x => x.ShuttleName);
        foreach (var item in shg)
            sw.WriteLine($"{item.Key}\t{item.Sum(x => x.TotalSpaceHours)/24F:0.00}");



    }
}