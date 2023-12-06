using System.Globalization;
// sistema de gerenciamento do escritório Tech Advocacia
namespace P004;
class Program {
    static void Main(string[] args) {
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        App.Menu();     
    }
}
